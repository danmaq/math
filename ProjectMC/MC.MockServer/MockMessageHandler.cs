using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using MC.Common.Utils;

namespace MC.MockServer
{
	/// <summary>
	/// モック サーバ用のメッセージ ハンドラ。
	/// </summary>
	sealed class MockMessageHandler : HttpMessageHandler
	{
		/// <summary>API 一覧。</summary>
		private readonly Dictionary<string, Func<string, string, object>> Apis =
			new Dictionary<string, Func<string, string, object>>()
			{
				["/v1/master"] = (_, __) => MasterStore.Instance.Export(),
			};

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
			var result =
				CallApi(
					path: request.RequestUri.AbsolutePath,
					method: request.Method.Method,
					content: request.Content?.ReadAsStringAsync().Result);
			var status = result.Item1 ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            var response = new HttpResponseMessage(status);
			response.Content = new StringContent(result.Item2);
			response.ReasonPhrase = @"Mock Server V1.";
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

		/// <summary>
		/// API を呼び出します。
		/// </summary>
		/// <param name="path"></param>
		/// <param name="method"></param>
		/// <param name="content"></param>
		/// <returns></returns>
		private Tuple<bool, string> CallApi(string path, string method, string content)
		{
			Func<string, string, object> api;
			var result = Apis.TryGetValue(path, out api);
			return Tuple.Create(result, result ? StringHelper.ToJson(api(method, content)) : null);
		}
	}
}
