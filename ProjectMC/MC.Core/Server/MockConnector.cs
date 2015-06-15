using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MC.Core.Server
{
	/// <summary>
	/// モックサーバと通信を行うための実装。
	/// </summary>
	public sealed class MockConnector : IConnector
	{
		/// <summary>
		/// サーバへ送信します。
		/// </summary>
		/// <returns>送信結果。</returns>
		public async Task<string> Send(Uri uri, HttpMethod method, IReadOnlyDictionary<string, string> param)
		{
			// TODO: 構想に迷っていたらキリがないので、一旦HttpClientで簡易RESTクライアントを作って実験する
			HttpMessageHandler hoge;
            throw new NotImplementedException();
		}
	}
}
