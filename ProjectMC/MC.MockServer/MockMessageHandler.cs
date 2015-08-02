using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MC.MockServer.Properties;

namespace MC.MockServer
{

	/// <summary>
	/// モック サーバ用のメッセージ ハンドラ。
	/// </summary>
	public sealed class MockMessageHandler : HttpMessageHandler
	{

		/// <summary>並列動作を制限するためのセマフォ。</summary>
		private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 1);

		/// <summary>モック サーバの API 呼び出し窓口。</summary>
		private static readonly MockApi api = new MockApi();

		/// <summary>
		/// 非同期操作として HTTP 要求を送信します。
		/// </summary>
		/// <param name="request">送信する HTTP 要求メッセージ。</param>
		/// <param name="cancellationToken">操作をキャンセルするキャンセル トークン。</param>
		/// <returns>非同期操作を表すタスク オブジェクト。</returns>
		/// <exception cref="ArgumentNullException"><paramref name="request"/> が null である場合。</exception>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}
			await semaphore.WaitAsync();
            try
			{
				await Task.Delay(TimeSpan.FromMilliseconds(500));
				return InnerProcess(request);
			}
			finally
			{
				semaphore.Release();
			}
		}

		/// <summary>
		/// API を呼び出し、レスポンスを作成します。
		/// </summary>
		/// <param name="request">リクエスト。</param>
		/// <returns>レスポンス。</returns>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		private static HttpResponseMessage InnerProcess(HttpRequestMessage request)
		{
			var result =
				api.CallApi(
					path: request.RequestUri.AbsolutePath,
					method: request.Method.Method,
					content: request.Content?.ReadAsStringAsync().Result);
			var status = result.Item1 ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
			var response = new HttpResponseMessage(status);
			response.Content = new StringContent(result.Item2);
			response.ReasonPhrase = Resources.SERVER_NAME;
			response.RequestMessage = request;
			return response;
		}
	}
}
