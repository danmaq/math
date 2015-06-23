using System;
using MC.Common.State;
using MC.Core.State.Game;

namespace MC.Core.Flow
{
	/// <summary>
	/// ゲームフロー専用コンテキスト。
	/// </summary>
	sealed class GameFlowContext : Context
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="gameFlow">ゲームフロー オブジェクト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public GameFlowContext(IGameFlow gameFlow)
			: base(LoginState.Instance)
		{
			Container.AddService(instance: gameFlow);
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージド リソースも解放するかどうか。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Container.RemoveService(serviceType: typeof(IGameFlow), dispose: false);
			}
			base.Dispose(disposing);
		}
	}
}
