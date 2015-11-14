using System;
using System.Net.Http;
using System.Threading.Tasks;
using MC.Common.Data;

namespace MC.Core.Server
{

	/// <summary>
	/// HTTP リクエストの拡張機能。
	/// </summary>
	static class HttpClientExtension
	{

		/// <summary>
		/// リクエストを発行します。
		/// </summary>
		/// <param name="client">HTTP クライアント。</param>
		/// <param name="method">HTTP メソッド。</param>
		/// <param name="uri">リクエスト先の URL。</param>
		/// <param name="content">送信するコンテンツ。</param>
		/// <returns>レスポンス情報。</returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="client"/> または <paramref name="uri"/> が null である場合。
		/// </exception>
		public static Task<HttpResponseMessage> Request(
			this HttpClient client, HttpMethodType method, string uri, HttpContent content)
		{
			if (client == null)
			{
				throw new ArgumentNullException(nameof(client));
			}
			if (uri == null)
			{
				throw new ArgumentNullException(nameof(uri));
			}
			switch (method)
			{
				case HttpMethodType.Get:
					return client.GetAsync(uri);
				case HttpMethodType.Post:
					return client.PostAsync(requestUri: uri, content: content);
				case HttpMethodType.Put:
					return client.PutAsync(requestUri: uri, content: content);
				case HttpMethodType.Delete:
					return client.DeleteAsync(uri);
				default:
					throw new ArgumentOutOfRangeException(nameof(method));
			}
		}
	}
}
