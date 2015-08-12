using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Properties;
using MC.Core.State.Practice;

namespace MC.Core.State.Game
{
	/// <summary>
	/// 練習ステージ画面。
	/// </summary>
	class PracticeState : IState
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private PracticeState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new PracticeState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Begin(IContext context)
		{
			Debug.WriteLine(Resources.DEBUG_STARTED, nameof(PracticeState));

			var director =
				context.Container.AddService<IContext>(new Context());
			director.Container.AddService(Tuple.Create(context));
			director.NextState = InitializeState.Instance;	// コンテナを登録してから、状態を設定する必要がある
		}

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Execute(IContext context)
		{
			var director = context.Container.GetService<IContext>();
			director.Execute();
			if (director.IsTerminated())
			{
				context.NextState = null;
				// TODO: プラクティス終了
			}
        }

		/// <summary>
		/// 他の状態に移行する直前に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Teardown(IContext context)
		{
			context.Container.RemoveService(typeof(IContext));
			Debug.WriteLine(Resources.DEBUG_TERMINATED, nameof(PracticeState));
		}
	}
}
