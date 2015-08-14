using System.Collections.Generic;
using System.Linq;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Core.Server;

namespace MC.Core.State.Practice
{

	/// <summary>
	/// 判定中の状態。
	/// </summary>
	sealed class JudgeState : PracticeStateBase
	{
		/// <summary>
		/// この状態専用のストレージ データ。
		/// </summary>
		private sealed class LocalContainer : LocalContainerBase
		{
			/// <summary>
			/// 通知が完了したかどうかを取得、または設定します。
			/// </summary>
			public bool Notified
			{
				get;
				set;
			}

			/// <summary>
			/// 接続が完了したかどうかを取得、または設定します。
			/// </summary>
			public bool Connected
			{
				get;
				set;
			}

			/// <summary>
			/// 正解かどうかを取得、または設定します。
			/// </summary>
			public bool Correct
			{
				get;
				set;
			}

			/// <summary>
			/// 通知を行うべきかどうかを取得します。
			/// </summary>
			public bool ShouldNotify => Connected && !Notified;
		}

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private JudgeState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new JudgeState();

		/// <summary>
		/// ローカル コンテナを生成します。
		/// </summary>
		protected override LocalContainerBase NewLocalContainer => new LocalContainer();

		/// <summary>
		/// 辞書を取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>辞書。</returns>
		private static IDictionary<int, QuestionData> GetDictionary(IContext context) =>
			context?.Container.GetService<IDictionary<int, QuestionData>>();

		/// <summary>
		/// ローカル コンテナを取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>ローカル コンテナ。</returns>
		private static LocalContainer GetLocalContainer(IContext context) =>
			GetLocalContainer<LocalContainer>(context);

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Begin(IContext context)
		{
			base.Begin(context);
			PeekAnswerAsync(
				container: GetLocalContainer(context),
				key: GetDictionary(context).First().Key,
				answer: GetPracticeData(context).Answer);
        }

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Execute(IContext context)
		{
			base.Execute(context);
			var localContainer = GetLocalContainer(context);
			if (localContainer.ShouldNotify)
			{
				Prompt(context);
				var dic = GetDictionary(context);
				dic.Remove(dic.First().Key);
				localContainer.Notified = true;
			}
		}

		/// <summary>
		/// プロンプトを表示部へ送信します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		private void Prompt(IContext context)
		{
			var localContainer = GetLocalContainer(context);
            var flow = GameFlow.GetService(GetMainContext(context));
			var args =
				new RequireAlertArgs()
				{
					Caption = localContainer.Correct.ToString(),
					Response = () => context.NextState = CountDownState.Instance,
				};
			flow.DispatchRequireResponse(args);
		}

		/// <summary>
		/// 正解かどうかを非同期で取得し、ローカル ストレージへ格納します。
		/// </summary>
		/// <param name="container">ローカル ストレージ。</param>
		/// <param name="key">問題のワンタイムID。</param>
		/// <param name="answer">回答番号。</param>
		private async void PeekAnswerAsync(LocalContainer container, int key, int answer)
		{
			container.Correct = await Api.TellAnswerAsync(key, answer);
			container.Connected = true;
		}
	}
}
