using System.Collections.Generic;
using System.Collections.ObjectModel;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
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
		}

		/// <summary>
		/// 選択肢を取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>選択肢。</returns>
		private static IReadOnlyList<Selection> CreateSelection(IContext context)
		{
			var selection =
				new Selection[]
				{
					Selection.Default.CopyTo(
						select: () => context.NextState = WorldState.Instance,
						description: Resources.MENU_HOME_WORLD),
					Selection.Default.CopyTo(
						select: () => context.NextState = PreferenceState.Instance,
                        description: Resources.MENU_HOME_PREFERENCE),
					Selection.Default.CopyTo(
						select: () => context.Terminate(),
						description: Resources.MENU_HOME_EXIT),
				};
			return new ReadOnlyCollection<Selection>(selection);
		}
	}
}
