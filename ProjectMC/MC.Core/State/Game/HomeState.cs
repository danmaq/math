﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MC.Common.State;
using MC.Common.Utils;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Core.Flow.Selections;
using MC.Core.Properties;

namespace MC.Core.State.Game
{
	/// <summary>
	/// ホーム画面 シーン。
	/// </summary>
	class HomeState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private HomeState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new HomeState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Begin(IContext context)
		{
			Debug.WriteLine(Resources.DEBUG_STARTED, nameof(HomeState));
			var flow = GameFlow.GetService(context);
			var args =
				new RequireSelectArgs()
				{
					Description = Resources.MESSAGE_HOME,
					Selections = CreateSelection(context)
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
			Debug.WriteLine(Resources.DEBUG_TERMINATED, nameof(HomeState));
		}

		/// <summary>
		/// 選択肢を取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>選択肢。</returns>
		private static IReadOnlyList<Selection> CreateSelection(IContext context)
		{
			var selection = new Selection[EnumHelper.Length(typeof(HomeSelection))];
			selection[(int)HomeSelection.World] =
				Selection.Default.CopyTo(
					select: () => context.NextState = WorldState.Instance,
					caption: Resources.MENU_HOME_WORLD);
			selection[(int)HomeSelection.Preference] =
				Selection.Default.CopyTo(
					select: () => context.NextState = PreferenceState.Instance,
					caption: Resources.MENU_HOME_PREFERENCE);
			selection[(int)HomeSelection.Exit] =
				Selection.Default.CopyTo(
					select: () => context.Terminate(), caption: Resources.MENU_HOME_EXIT);
			return new ReadOnlyCollection<Selection>(selection);
		}
	}
}
