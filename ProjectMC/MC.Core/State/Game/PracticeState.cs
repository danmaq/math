using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using MC.Common.Collection;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Properties;
using MC.Core.Server;

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
			Debug.WriteLine(Resources.DEBUG_STARTED, nameof(PracticeState));
			// TODO: 強制バックを消して、ロジックを実装する
			ReadQuestion(context.Container);
			//context.Container.RemoveService(typeof(Tuple<SubjectMasterData>), true);
			//context.NextState = context.PreviousState;
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
			Debug.WriteLine(Resources.DEBUG_TERMINATED, nameof(PracticeState));
		}

		private async void ReadQuestion(ServiceContainer container)
		{
			var college = container.GetService<Tuple<CollegeMasterData>>();
			var subject = container.GetService<Tuple<SubjectMasterData>>();
			if (college != null && subject != null)
			{
				var result = await Api.GetQuestionAsync(college.Item1, subject.Item1);
				Debug.WriteLine(result);
			}
		}
	}
}
