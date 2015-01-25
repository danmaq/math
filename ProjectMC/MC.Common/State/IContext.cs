namespace MC.Common.State
{
	/// <summary>
	/// Stateパターンにおける、コンテキストに必要な実装を定義します。
	/// </summary>
	public interface IContext
	{
		/// <summary>前回の状態を取得できます。</summary>
		IState PreviousState
		{
			get;
		}

		/// <summary>現在の状態を取得できます。</summary>
		IState CurrentState
		{
			get;
		}

		/// <summary>次の状態を取得、または設定できます。</summary>
		IState NextState
		{
			get;
			set;
		}

		/// <summary>
		/// 現在の状態を実行できます。
		/// </summary>
		void Execute();
	}
}
