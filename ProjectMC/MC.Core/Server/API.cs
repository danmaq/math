using System;
using System.Threading.Tasks;
using MC.Common.Data;

namespace MC.Core.Server
{
	/// <summary>
	/// 各種API。
	/// </summary>
	public static class API
	{
		/// <summary>既定の接続。</summary>
		public static IConnector Connector
		{
			get;
			set;
		}


		/// <summary>
		/// ユーザ情報を取得します。
		/// </summary>
		/// <param name="id">ユーザID。</param>
		/// <returns>ユーザ情報。</returns>
		public static async Task<UserData> GetUser(int id)
		{
			throw new NotImplementedException();
		}

	}
}
