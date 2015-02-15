﻿using MC.Common.State;
using MC.Core.Data;

namespace MC.Core.State
{
	sealed class LoginState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private LoginState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new LoginState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Begin(IContext context)
		{
		}

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Execute(IContext context)
		{
			context.NextState = NullState.Instance;
			var args =
				new RequireSelectArgs()
				{
					Expires = 10,
					Selections =
						new Selection[]
						{
							new Selection() { Description = @"ほげ" },
							new Selection() { Description = @"ふが" },
						},
				};
			var flow = context.Container.GetService<GameFlow>();
			if (flow != null)
			{
				flow.DispatchRequireResponse(args: args);
			}
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