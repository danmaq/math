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
		/// この状態専用ストレージ データのための基底クラス。
		/// </summary>
		protected class LocalContainerBase
		{
			/// <summary>
			/// このオブジェクトが生成された時刻を取得します。
			/// </summary>
			protected DateTime Created
			{
				get;
			}
			= DateTime.Now;
		}

		/// <summary>
		/// ローカル コンテナを生成します。
		/// </summary>
		protected virtual LocalContainerBase NewLocalContainer => new LocalContainerBase();

		/// <summary>
		/// ルートのコンテキストを取得します。
		/// </summary>
		/// <param name="context">現在のコンテキスト。</param>
		/// <returns>ルートのコンテキスト。</returns>
		protected static IContext GetMainContext(IContext context) =>
			context?.Container.GetService<Tuple<IContext>>()?.Item1;

		/// <summary>
		/// ローカル コンテナを取得します。
		/// </summary>
		/// <typeparam name="T">ローカル コンテナの既定型。</typeparam>
		/// <param name="context">コンテキスト。</param>
		/// <returns>ローカル コンテナ。</returns>
		protected static T GetLocalContainer<T>(IContext context) where T : LocalContainerBase =>
			context?.Container.GetService<LocalContainerBase>() as T;

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public virtual void Begin(IContext context) =>
			context.Container.AddService(NewLocalContainer);

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
		public virtual void Teardown(IContext context) =>
			context.Container.RemoveService(typeof(LocalContainerBase));
	}
}
