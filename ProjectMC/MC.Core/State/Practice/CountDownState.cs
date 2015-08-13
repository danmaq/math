using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MC.Common.Collection;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Core.Properties;
using MC.Core.Server;

namespace MC.Core.State.Practice
{

	/// <summary>
	/// プラクティス開始前カウントダウン待機の状態。
	/// </summary>
	sealed class CountDownState : PracticeStateBase
	{

		/// <summary>
		/// この状態専用のストレージ データ。
		/// </summary>
		private sealed class LocalContainer : LocalContainerBase
		{
			/// <summary>
			/// 問題のワンタイムIDを取得または設定します。
			/// </summary>
			public int ID
			{
				get;
				set;
			}
			= int.MinValue;

			/// <summary>
			/// 問題情報を取得または設定します。
			/// </summary>
			public QuestionData Question
			{
				get;
				set;
			}
		}


		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private CountDownState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new CountDownState();

		/// <summary>
		/// プロンプトを表示部へ送信します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		private static void Prompt(IContext context)
		{
			var container = GetLocalContainer<LocalContainer>(context);
			var flow = GameFlow.GetService(GetMainContext(context));
			var args =
				new RequireSelectArgs
				{
					Description = container.Question.Caption,
					AdditionalDesctiption = container.Question.Description,
					Expires = container.Question.Expires,
					Selections = CreateSelection(context),
				};
			flow.DispatchRequireResponse(args);
			Debug.WriteLine(@"Initialize Completed");
		}

		/// <summary>
		/// 選択肢リストを作成します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>選択肢リスト。</returns>
		private static IReadOnlyList<Selection> CreateSelection(IContext context) =>
			new List<Selection>(
				GetLocalContainer<LocalContainer>(context)
					.Question
					.Answers
					.Select(
						(s, i) => Selection.Create(s, i, CreateSelectedCallback(context))));

		/// <summary>
		/// 選択肢用コールバックを作成します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>選択肢用コールバック。</returns>
		private static Action<int> CreateSelectedCallback(IContext context) =>
			i =>
			{
				context.Container.AddService(Tuple.Create(i));
				// TODO: 選択後のオプションを設定する
			};

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Begin(IContext context)
		{
			base.Begin(context);
			var dic = context.Container.GetService<IDictionary<int, QuestionData>>();
			var kv = dic.First();
			try
			{
				var container = GetLocalContainer<LocalContainer>(context);
				container.ID = kv.Key;
				container.Question = kv.Value;
				Prompt(context);
            }
			catch
			{
				// TODO: 空の状態
			}
        }

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Execute(IContext context)
		{
			base.Execute(context);
		}
	}
}
