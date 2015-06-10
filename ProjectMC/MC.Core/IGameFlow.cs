using System;
using MC.Core.Data;

namespace MC.Core
{
	/// <summary>
	/// ゲーム全体のフローを管理するクラスに必要な要件。
	/// </summary>
	public interface IGameFlow : IDisposable
	{
		/// <summary>
		/// レスポンスを要求する際に発火するイベント。
		/// このイベントを受けたら、ユーザの入力に応じて Response() メソッドを呼び出してください。
		/// </summary>
		event EventHandler<RequireResponseArgs> RequireResponse;

		/// <summary>入力タイムアウト時に発火するイベント。</summary>
		event EventHandler Timeout;
	}
}
