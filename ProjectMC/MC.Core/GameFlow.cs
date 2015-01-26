using System;
using MC.Common.State;
using MC.Core.Data;

namespace MC.Core
{
	/// <summary>
	/// ゲーム全体のフローを管理するクラス。
	/// </summary>
	public sealed class GameFlow : IDisposable
	{

		/// <summary>ゲームの状態を保持するコンテキスト。</summary>
		private Context context = new Context();

		/// <summary>
		/// レスポンスを要求する際に発火するイベント。
		/// このイベントを受けたら、ユーザの入力に応じて Response() メソッドを呼び出してください。
		/// </summary>
		public event EventHandler<RequireResponseArgs> RequireResponse;

		/// <summary>
		/// ゲームフローを開始します。
		/// </summary>
		public GameFlow()
		{
			context.Container.AddService(instance: this);
			context.Execute();
		}

		/// <summary>
		/// レスポンスを受けます。
		/// </summary>
		public void Response()
		{
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
			if (context != null)
			{
				context.Dispose();
				context = null;
			}
		}
	}
}
