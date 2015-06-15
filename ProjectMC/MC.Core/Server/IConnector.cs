using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MC.Core.Server
{
	/// <summary>
	/// サーバ接続のためのインターフェイス。
	/// </summary>
	public interface IConnector
	{
		/// <summary>
		/// サーバへ送信します。
		/// </summary>
		/// <param name="uri">サーバのエンドポイント。</param>
		/// <returns>送信結果。</returns>
		Task<string> Send(
			Uri uri, HttpMethod method, IReadOnlyDictionary<string, string> param);

	}
}
