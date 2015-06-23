using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MC.MockServer
{
	/// <summary>
	/// モック サーバ用のメッセージ ハンドラ。
	/// </summary>
	sealed class MockMessageHandler : HttpMessageHandler
	{
		/// <summary>
		/// 非同期操作として HTTP 要求を送信します。
		/// </summary>
		/// <param name="request">送信する HTTP 要求メッセージ。</param>
		/// <param name="cancellationToken">操作をキャンセルするキャンセル トークン。</param>
		/// <returns>非同期操作を表すタスク オブジェクト。</returns>
		/// <exception cref="ArgumentNullException"><paramref name="request"/> が null である場合。</exception>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}
			Sleep();
			var source = new TaskCompletionSource<HttpResponseMessage>();
			var response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new StringContent(@"Hello, world!");
			response.ReasonPhrase = @"Mock Server.";
			response.RequestMessage = request;
			source.TrySetResult(response);
			return source.Task;
		}

		/// <summary>
		/// 通信遅延を再現するため、休眠します。
		/// </summary>
		private void Sleep()
		{
			Thread.Sleep(500);
		}
	}
}
