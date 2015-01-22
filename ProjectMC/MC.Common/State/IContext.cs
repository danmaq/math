namespace MC.Common.State
{
	/// <summary>
	/// Stateパターンにおける、コンテキスト。
	/// </summary>
	public interface IContext
	{

		IState PreviousState
		{
			get;
		}

		IState CurrentState
		{
			get;
		}

		IState NextState
		{
			get;
			set;
		}

		void Execute();
	}
}
