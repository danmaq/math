﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;

namespace MC.Core.State.Game
{
	/// <summary>
	/// 練習ステージ画面。
	/// </summary>
	class PracticeState : IState
	{

		private class Director
		{
			public IEnumerable<IReadOnlyList<Selection>> Collection
			{
				get;
				set;
			}
		}

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
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Begin(IContext context)
		{
			//var flow = GameFlow.GetService(context);
		}

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Execute(IContext context)
		{
		}

		/// <summary>
		/// 他の状態に移行する直前に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Teardown(IContext context)
		{
		}
	}
}
