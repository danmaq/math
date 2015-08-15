using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Core.Properties;
using MC.Core.Server;

namespace MC.Core.State.Practice
{

	/// <summary>
	/// プラクティスの初期化状態。
	/// </summary>
	sealed class InitializeState : PracticeStateBase
	{

		/// <summary>
		/// この状態専用のストレージ データ。
		/// </summary>
		private sealed class LocalContainer : LocalContainerBase
		{

			/// <summary>
			/// ダウンロードが完了したかどうかを取得、または設定します。
			/// </summary>
			public bool Downloaded
			{
				get;
				set;
			}

			/// <summary>
			/// 確認を送信済みかどうかを取得、または設定します。
			/// </summary>
			public bool SendedConfirm
			{
				get;
				set;
			}

			/// <summary>
			/// カウントダウン待機が完了したかどうかを取得します。
			/// </summary>
			public bool Expired => (DateTime.Now - Created).Seconds >= Constants.PreCountDown;

			/// <summary>
			/// 確認を送信すべきかどうかを取得します。
			/// </summary>
			public bool CanSendConfirm => Downloaded && Expired && !SendedConfirm;
        }

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private InitializeState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new InitializeState();

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
			var args =
				new RequireAlertArgs()
				{
					Caption = Resources.MESSAGE_PRACTICE_START,
					Response = () => context.NextState = CountDownState.Instance,
				};
			flow.DispatchRequireResponse(args);
			Debug.WriteLine(@"Initialize Completed");
		}

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Begin(IContext context)
		{
			base.Begin(context);
			context.Container.AddService(new PracticeData());
			PeekQuestionAsync(context);
        }

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Execute(IContext context)
		{
			base.Execute(context);
			var data = GetLocalContainer(context);
            if (data.CanSendConfirm)
			{
				Prompt(context);
				data.SendedConfirm = true;
			}
		}

		/// <summary>
		/// 問題一覧をコンテナに配置します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		private async void PeekQuestionAsync(IContext context)
		{
			var rootContainer = GetMainContext(context).Container;
			var college = rootContainer.GetService<Tuple<CollegeMasterData>>();
			var subject = rootContainer.GetService<Tuple<SubjectMasterData>>();
			var dic = await GetQuestionAsync(college: college.Item1, subject: subject.Item1);
            context.Container.AddService(dic);
			GetLocalContainer(context).Downloaded = true;
			GetPracticeData(context).Length = dic.Count;
		}

		/// <summary>
		/// 問題一覧を読み込みます。
		/// </summary>
		/// <param name="college">学園マスタ。</param>
		/// <param name="subject">教科マスタ。</param>
		/// <returns>問題一覧。</returns>
		private async Task<IDictionary<int, QuestionData>> GetQuestionAsync(
			CollegeMasterData college, SubjectMasterData subject)
		{
			var result = await Api.GetQuestionAsync(college, subject);
			return result.ToDictionary(
				keySelector: p => p.Key, elementSelector: p => p.Value);
		}
	}
}
