﻿using System.Diagnostics;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Core.Properties;

namespace MC.Core.State.Game
{
	/// <summary>
	/// タイトル シーン。
	/// </summary>
	class TitleState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private TitleState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new TitleState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Begin(IContext context)
		{
			Debug.WriteLine(Resources.DEBUG_STARTED, nameof(TitleState));
			var flow = GameFlow.GetService(context);
			var args =
				new RequireAlertArgs()
				{
					Caption = Resources.MESSAGE_START,
					Response = () => context.NextState = HomeState.Instance
				};
			flow.DispatchRequireResponse(args);
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
			Debug.WriteLine(Resources.DEBUG_TERMINATED, nameof(TitleState));
		}
	}
}
