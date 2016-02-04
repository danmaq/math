using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MC.Common.Data;
using MC.Common.Data.Serializable;
using MC.Common.Utils;

using QData = System.Collections.Generic.KeyValuePair<int, MC.Common.Data.QuestionData>;

namespace MC.Core.Server
{

	/// <summary>
	/// 各種API。
	/// </summary>
	static class Api
	{
		/// <summary>URL のエントリポイント。</summary>
		private const string entryPoint = @"http://api.math.sc/v1/";

		/// <summary>クライアント。</summary>
		private static HttpClient client;

		/// <summary>
		/// 既定のハンドラで初期化します。
		/// </summary>
		/// <returns>初期化できた場合、true。既に初期化されている場合、false。</returns>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		public static bool Initialize()
		{
			HttpMessageHandler handler =
#if MOCK_SERVER
				new MockServer.MockMessageHandler();
#else
				null;
#endif
			return Initialize(handler);
		}

		/// <summary>
		/// 指定のハンドラで初期化します。
		/// </summary>
		/// <param name="handler">メッセージ ハンドラ。</param>
		/// <returns>初期化できた場合、true。既に初期化されている場合、false。</returns>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		public static bool Initialize(HttpMessageHandler handler)
		{
			var result = client == null;
			if (result)
			{
				client = new HttpClient(handler ?? new HttpClientHandler());
			}
			return result;
		}

		/// <summary>
		/// 後片付けを行います。再度初期化を行う場合も、予め呼び出す必要があります。
		/// </summary>
		public static void Dispose()
		{
			(client ?? (IDisposable)new Disposable()).Dispose();
		}

		/// <summary>
		/// ユーザ情報を取得します。
		/// </summary>
		/// <param name="userId">ユーザID。nullを設定するとユーザを作成します。</param>
		/// <returns>ユーザ情報。</returns>
		public static async Task<UserData> GetUserData(string userId = null) =>
			await (userId == null ? CreateUserData() : GetUserData(long.Parse(userId)));

		/// <summary>
		/// ユーザ情報を取得します。
		/// </summary>
		/// <param name="userId">ユーザID。</param>
		/// <returns>ユーザ情報。</returns>
		public static async Task<UserData> GetUserData(long userId)
		{
			var path = CreatePath(@"user", userId);
			var body = await RequestAsync(method: HttpMethodType.Get, path: path);
			var user = UserData.Import(StringHelper.FromJson<User>(body));
			client.DefaultRequestHeaders.Authorization =
				CreateBasicAuthHeader(id: user.UserId.ToString(), password: string.Empty);
            return user;
		}

		/// <summary>
		/// ユーザ情報を作成します。
		/// </summary>
		/// <returns>ユーザ情報。</returns>
		public static async Task<UserData> CreateUserData()
		{
			var body = await RequestAsync(method: HttpMethodType.Put, path: @"user");
			return UserData.Import(StringHelper.FromJson<User>(body));
		}

		/// <summary>
		/// 問題を取得します。
		/// </summary>
		/// <param name="college">学園マスタ。</param>
		/// <param name="subject">教科マスタ。</param>
		/// <returns>問題一覧。</returns>
		public static async Task<QData[]> GetQuestionAsync(
			CollegeMasterData college, SubjectMasterData subject) =>
			await GetQuestionAsync(collegeId: college.CollegeId, subjectId: subject.SubjectId);

		/// <summary>
		/// 問題を取得します。
		/// </summary>
		/// <param name="collegeId">学園ID。</param>
		/// <param name="subjectId">教科ID。</param>
		/// <returns>問題一覧。</returns>
		public static async Task<QData[]> GetQuestionAsync(int collegeId, int subjectId)
		{
			var path = CreatePath(@"question", collegeId, subjectId);
            var body = await RequestAsync(method: HttpMethodType.Get, path: path, content: null);
			return
				StringHelper
					.FromJson<KeyValuePair<int, Question>[]>(body)
					.Select(p => new QData(p.Key, QuestionData.Import(p.Value)))
					.ToArray();
		}

		/// <summary>
		/// 回答を問い合わせます。
		/// </summary>
		/// <param name="questionId">問題ワンタイムID。</param>
		/// <param name="answer">回答。</param>
		/// <returns>正解である場合、true。</returns>
		public static async Task<Tuple<bool, int>> TellAnswerAsync(int questionId, int answer)
		{
			var path = CreatePath(@"answer", questionId, answer);
			var body = await RequestAsync(method: HttpMethodType.Post, path: path);
			return StringHelper.FromJson<Tuple<bool, int>>(body);
		}

		/// <summary>
		/// すべてのマスタ データを読み込みます。
		/// </summary>
		/// <returns>読み込み完了通知。必ず true を返します。</returns>
		public static async Task<AllMaster> LoadAllMasterAsync()
		{
            var body = await RequestAsync(method: HttpMethodType.Get, path: @"master");
			return StringHelper.FromJson<AllMaster>(body);
		}

		/// <summary>
		/// 初期化されているかどうかを検証します。
		/// </summary>
		/// <exception cref="InvalidOperationException">初期化されていない場合。</exception>
		private static void CheckInitialized()
		{
			if (client == null)
			{
				throw new InvalidOperationException();
			}
		}

		/// <summary>
		/// BASIC認証用のヘッダを生成します。
		/// </summary>
		/// <param name="id">ID。</param>
		/// <param name="password">パスワード。</param>
		/// <returns>BASIC認証用ヘッダ。</returns>
		private static AuthenticationHeaderValue CreateBasicAuthHeader(
			string id, string password)
		{
			var idpw = string.Format(@"{0}:{1}", id, password);
			var parameter = Convert.ToBase64String(Encoding.UTF8.GetBytes(idpw));
			return new AuthenticationHeaderValue(scheme: @"Basic", parameter: parameter);
		}

		/// <summary>
		/// REST パスを作成します。
		/// </summary>
		/// <param name="args">REST パスを構成するパラメータ。</param>
		/// <returns>REST パス。</returns>
		private static string CreatePath(params object[] args) =>
			args
				.Select(o => o.ToString())
				.Aggregate(
					(s, o) => string.Format(CultureInfo.InvariantCulture, @"{0}/{1}", s, o));

		/// <summary>
		/// HTTPリクエストを非同期で送信します。
		/// </summary>
		/// <param name="method">HTTP メソッド。</param>
		/// <param name="path">API のパス。</param>
		/// <param name="content">API に渡すボディ。</param>
		/// <returns>戻り値の生文字列。</returns>
		private static async Task<string> RequestAsync(
			HttpMethodType method, string path, HttpContent content = null)
		{
			CheckInitialized();
			var uri = entryPoint + path;
			string body;
            using (var response = await client.Request(method, uri, content))
			{
				if (client.DefaultRequestHeaders.Authorization != null)
				{
					var bytes =
						Convert.FromBase64String(
							client.DefaultRequestHeaders.Authorization.Parameter);
                    var idpw = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
					Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Auth: {0}", idpw));
				}
				Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Request: {0}", uri));
				body = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Response: {0}", body));
			}
			return body;
		}
	}
}
