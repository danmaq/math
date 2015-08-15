using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;

namespace MC.Core.State.Practice
{

	/// <summary>
	/// 問題攻略中カウントダウンの状態。
	/// </summary>
	sealed class CountDownState : PracticeStateBase
	{

		/// <summary>
		/// この状態専用のストレージ データ。
		/// </summary>
		private sealed class LocalContainer : LocalContainerBase
		{
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
		/// ローカル コンテナを生成します。
		/// </summary>
		protected override LocalContainerBase NewLocalContainer => new LocalContainer();

		/// <summary>
		/// ローカル コンテナを取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>ローカル コンテナ。</returns>
		private static LocalContainer GetLocalContainer(IContext context) =>
			GetLocalContainer<LocalContainer>(context);

		/// <summary>
		/// プロンプトを表示部へ送信します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		private static void Prompt(IContext context)
		{
			var flow = GameFlow.GetService(GetMainContext(context));
			var question = GetLocalContainer<LocalContainer>(context).Question;
            var args =
				new RequireSelectArgs()
				{
					Caption = question.Caption,
					Desctiption = question.Description,
					AdditionalData = GetPracticeData(context),
					Selections = CreateSelection(context),
					Expires = question.Expires,
				};
			flow.DispatchRequireResponse(args);
		}

		/// <summary>
		/// 選択肢リストを作成します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>選択肢リスト。</returns>
		private static IReadOnlyList<Selection> CreateSelection(IContext context) =>
			new List<Selection>(
				GetLocalContainer(context)
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
				GetPracticeData(context).Answer = i;
				context.NextState = JudgeState.Instance;
			};

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public override void Begin(IContext context)
		{
			base.Begin(context);
			var dic = context.Container.GetService<IDictionary<int, QuestionData>>();
			if (dic.Any())
			{
				var kv = dic.First();
				var container = GetLocalContainer(context);
				container.Question = kv.Value;
				Prompt(context);
            }
			else
			{
				context.NextState = ResultState.Instance;
			}
        }
	}
}
