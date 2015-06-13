using System;
using System.Collections.Generic;
using System.Linq;
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
		public async Task<object> Send()
		{
			throw new NotImplementedException();
		}
	}
}
