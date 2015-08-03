using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MC.Common.Data;
using MC.Common.Utils;
using MC.Common.Data.Serializable;
using System.IO;
using System.Globalization;

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
		/// <param name="id">ユーザID。</param>
		/// <returns>ユーザ情報。</returns>
		/// <exception cref="InvalidOperationException">初期化されていない場合。</exception>
		public static async Task<UserData> GetUserAsync(int id)
		{
			CheckInitialized();
			throw new NotImplementedException();
		}

		/// <summary>
		/// 問題を取得します。
		/// </summary>
		/// <param name="college">学園マスタ。</param>
		/// <param name="subject">教科マスタ。</param>
		/// <returns>問題一覧。</returns>
		public static async Task<string> GetQuestionAsync(
			CollegeMasterData college, SubjectMasterData subject) =>
			await GetQuestionAsync(collegeId: college.CollegeId, subjectId: subject.SubjectId);

		/// <summary>
		/// 問題を取得します。
		/// </summary>
		/// <param name="collegeId">学園ID。</param>
		/// <param name="subjectId">教科ID。</param>
		/// <returns>問題一覧。</returns>
		public static async Task<string> GetQuestionAsync(int collegeId, int subjectId)
		{
			var path = CreatePath(@"question", collegeId, subjectId);
            var body = await Request(method: HttpMethod.Get, path: path, content: null);
			return body;
		}

		/// <summary>
		/// すべてのマスタ データを読み込みます。
		/// </summary>
		/// <returns>読み込み完了通知。必ず true を返します。</returns>
		public static async Task<AllMaster> LoadAllMasterAsync()
		{
            var body = await Request(method: HttpMethod.Get, path: @"master", content: null);
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
		private static async Task<string> Request(
			HttpMethod method, string path, HttpContent content)
		{
			CheckInitialized();
			var uri = entryPoint + path;
			string body;
            using (var response = await client.Request(method, uri, content))
			{
				body = await response.Content.ReadAsStringAsync();
			}
			return body;
		}
	}
}
