using System;
using System.Diagnostics.CodeAnalysis;
using MC.Common.State;

namespace MC.Core.State.Practice
{
	/// <summary>
	/// プラクティスの基底状態。
	/// </summary>
	abstract class PracticeStateBase : IState
	{
		/// <summary>
		/// ルートのコンテキストを取得します。
		/// </summary>
		/// <param name="context">現在のコンテキスト。</param>
		/// <returns>ルートのコンテキスト。</returns>
		protected static IContext GetMainContext(IContext context)
		{
			return context?.Container.GetService<Tuple<IContext>>()?.Item1;
		}

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public virtual void Begin(IContext context)
		{
		}

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public virtual void Execute(IContext context)
		{
		}

		/// <summary>
		/// 他の状態に移行する直前に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public virtual void Teardown(IContext context)
		{
		}
	}
}
