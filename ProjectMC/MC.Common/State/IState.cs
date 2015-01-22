namespace MC.Common.State
{
	/// <summary>
	/// Stateパターンにおける、状態に必要な要件を定義します。
	/// </summary>
	public interface IState
	{

		/// <summary>
		/// 状態が開始した際の挙動を定義します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		void Prepare(IContext context);

		/// <summary>
		/// 状態を実行した際の挙動を定義します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		void Execute(IContext context);

		/// <summary>
		/// 他の状態に移行する際の挙動を定義します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		void Teardown(IContext context);

	}
}
