using System;
using MC.Common.Collection;

namespace MC.Common.State
{
	/// <summary>
	/// Stateパターンにおける、コンテキストに必要な実装を定義します。
	/// </summary>
	public interface IContext : IDisposable
	{
		/// <summary>前回の状態を取得できます。</summary>
		/// <remarks>この値は常に null 以外の値である必要があります。</remarks>
		IState PreviousState
		{
			get;
		}

		/// <summary>現在の状態を取得できます。</summary>
		/// <remarks>この値は常に null 以外の値である必要があります。</remarks>
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

		/// <summary>データ コンテナを取得できます。</summary>
		ServiceContainer Container
		{
			get;
		}

		/// <summary>
		/// 次の状態を確定するための挙動を定義します。
		/// </summary>
		/// <returns>確定した状態。</returns>
		IState CommitNextState();
	}
}
