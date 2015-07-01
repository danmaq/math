using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using MC.Common.Data;
using MC.Common.Utils;
using MC.MockServer;
using MC.Common.Data.Serializable;

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
				new MockMessageHandler();
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
		public static async Task<UserData> GetUser(int id)
		{
			CheckInitialized();
			throw new NotImplementedException();
		}

		/// <summary>
		/// すべてのマスタ データを読み込みます。
		/// </summary>
		/// <returns>読み込み完了通知。必ず true を返します。</returns>
		public static async Task<AllMaster> LoadAllMaster()
		{
			CheckInitialized();
			var response =
				await
					client.Request(
						method: HttpMethod.Get, uri: entryPoint + @"master", content: null);
			var body = await response.Content.ReadAsStringAsync();
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
	}
}
