using System;
using System.Collections;
using MC.Common.State;
using MC.Common.Utils;
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
		public event EventHandler<RequireResponseArgs> RequireResponse =
			DelegateHelper.CreateEmptyEventHandler<RequireResponseArgs>();

		/// <summary>入力タイムアウト時に発火するイベント。</summary>
		public event EventHandler Timeout = DelegateHelper.EmptyHandler;

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

		/// <summary>
		/// 入力要求イベントを発火させます。
		/// </summary>
		/// <param name="args">入力要求に必要なデータ。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		internal void DispatchRequireResponse(RequireResponseArgs args)
		{
			if (args == null)
			{
				throw new ArgumentNullException(nameof(args));
			}
			RequireResponse(this, args);
		}

		/// <summary>
		/// 入力タイムアウト イベントを発火させます。
		/// </summary>
		internal void DispatchTimeout()
		{
			Timeout(this, EventArgs.Empty);
		}
	}
}
