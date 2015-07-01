using System;

namespace MC.Common.Data
{
	/// <summary>
	/// I/O のラッパーに必要な定義。
	/// </summary>
	interface IIOWrapper
	{
		/// <summary>
		/// ユーザ情報を読み込みます。
		/// </summary>
		/// <param name="onCompleted">完了時に呼び出されるコールバック。</param>
		/// <returns>ユーザ情報。</returns>
		void Load(Action<string, string> onCompleted);

		/// <summary>
		/// ユーザ情報を保存します。
		/// </summary>
		/// <param name="data">保存する情報。</param>
		/// <param name="onCompleted">完了時に呼び出されるコールバック。</param>
		/// <returns>ユーザ情報。</returns>
		void Save(string data, Action<string> onCompleted);
	}
}
