using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
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
		/// 選択肢を取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>選択肢。</returns>
		private static IReadOnlyList<Selection> CreateSelection(IContext context)
		{
			Action back =
				() =>
				{
					context.Container.RemoveService(typeof(Tuple<CollegeMasterData>), true);
					context.NextState = WorldState.Instance;
				};
			var result = new List<Selection>();
			result.Add(
				Selection.Default.CopyTo(
					select: back,
					caption: Resources.MENU_GENERIC_BACK));
			var college = context.Container.GetService<Tuple<CollegeMasterData>>();
			if (college != null)
			{
				Func<SubjectMasterData, Selection> create =
					m =>
						Selection.Default.CopyTo(
							caption: m.Name,
							description: m.Description,
							select:
								() =>
								{
									context.Container.AddService(Tuple.Create(m));
									context.NextState = PracticeState.Instance;
								});
				result.AddRange(
					from s in MasterCache.SubjectMaster
					where s.College == college.Item1
					select create(s));
			}
			return new ReadOnlyCollection<Selection>(result);
		}

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Begin(IContext context)
		{
			Debug.WriteLine(Resources.DEBUG_STARTED, nameof(AreaState));
			var flow = GameFlow.GetService(context);
			var args =
				new RequireSelectArgs()
				{
					Description = Resources.MESSAGE_AREA,
					Selections = CreateSelection(context)
				};
			flow.DispatchRequireResponse(args);
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
			Debug.WriteLine(Resources.DEBUG_TERMINATED, nameof(AreaState));
		}
	}
}
