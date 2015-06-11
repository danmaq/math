using System.Collections.Generic;
using System.Collections.ObjectModel;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Properties;

namespace MC.Core.State.Game
{
	/// <summary>
	/// エリア選択シーン。
	/// </summary>
	class AreaState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private AreaState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new AreaState();

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
					new RequireSelectArgs()
					{
						Description = Resources.MESSAGE_AREA,
						Selections = CreateSelection(context)
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
						description: Resources.MENU_AREA_TEMP),
					Selection.Default.CopyTo(
						select: () => context.NextState = WorldState.Instance,
						description: Resources.MENU_GENERIC_BACK),
				};
			return new ReadOnlyCollection<Selection>(selection);
		}
	}
}
