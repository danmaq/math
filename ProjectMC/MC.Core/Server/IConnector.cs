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
		/// <returns>送信結果。</returns>
		Task<object> Send();

	}
}
