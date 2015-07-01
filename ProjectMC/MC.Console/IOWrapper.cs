using System;
using MC.Common.Data;

namespace MC
{
	/// <summary>
	/// I/O のラッパー。
	/// </summary>
	class IOWrapper : IIOWrapper
	{
		/// <summary>
		/// ユーザ情報を読み込みます。
		/// </summary>
		/// <param name="onCompleted">完了時に呼び出されるコールバック。</param>
		/// <returns>ユーザ情報。</returns>
		public void Load(Action<string, string> onCompleted)
		{
		}

		/// <summary>
		/// ユーザ情報を保存します。
		/// </summary>
		/// <param name="data">保存する情報。</param>
		/// <param name="onCompleted">完了時に呼び出されるコールバック。</param>
		/// <returns>ユーザ情報。</returns>
		public void Save(string data, Action<string> onCompleted)
		{
		}
	}
}
