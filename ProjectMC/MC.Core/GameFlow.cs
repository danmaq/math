using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.State;

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
		/// ゲームフローを初期化します。
		/// </summary>
		public GameFlow()
		{
		}

		/// <summary>
		/// ゲームフローを開始します。
		/// </summary>
		public IEnumerable Run()
		{
			context.Container.AddService(instance: this);
			context.NextState = LoginState.Instance;
			Debug.WriteLine("Run");
			while (!context.IsTerminate())
			{
				yield return null;
				context.Execute();
			}
			context.Container.RemoveService(serviceType: typeof(GameFlow), dispose: false);
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
