﻿using MC.Common.State;
using MC.Core.Data;
using MC.Core.Properties;

namespace MC.Core.State.Game
{
	/// <summary>
	/// ワールドマップ シーン。
	/// </summary>
	class WorldState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private WorldState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new WorldState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Begin(IContext context)
		{
			var flow = context.Container.GetService<GameFlow>();
			if (flow != null)
			{
				var args =
					new RequireAlertArgs()
					{
						Description = Resources.MESSAGE_WORLD,
						Response = () => context.NextState = HomeState.Instance
					};
				flow.DispatchRequireResponse(args);
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
