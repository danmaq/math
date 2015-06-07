﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Properties;

namespace MC.Core.State.Game
{
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
		public void Begin(IContext context)
		{
			var flow = context.Container.GetService<GameFlow>();
			if (flow != null)
			{
			}
		}

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Execute(IContext context)
		{
		}

		/// <summary>
		/// 他の状態に移行する直前に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Teardown(IContext context)
		{
		}
	}
}
