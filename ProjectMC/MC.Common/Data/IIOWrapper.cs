using System;

namespace MC.Common.Data
{
	/// <summary>
	/// I/O のラッパー。
	/// </summary>
	interface IIOWrapper
	{
		/// <summary>エラー発生時に呼び出されるイベント。</summary>
		event EventHandler<EventArgs<string>> Failed;

		/// <summary>
		/// ユーザ情報を読み込みます。
		/// </summary>
		/// <param name="onCompleted">完了時に呼び出されるコールバック。</param>
		/// <returns>ユーザ情報。</returns>
		void LoadUserData(Action<UserData, bool> onCompleted);

		/// <summary>
		/// ユーザ情報を保存します。
		/// </summary>
		/// <param name="data">保存する情報。</param>
		/// <param name="onCompleted">完了時に呼び出されるコールバック。</param>
		/// <returns>ユーザ情報。</returns>
		void SaveUserData(UserData data, Action<bool> onCompleted);
	}
}
