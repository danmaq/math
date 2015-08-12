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
			public bool Expired => (DateTime.Now - Created).Seconds >= 3;

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
		/// プロンプトを表示部へ送信します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		private static void Prompt(IContext context)
		{
			var flow = GameFlow.GetService(GetMainContext(context));
			var args =
				new RequireAlertArgs()
				{
					Description = Resources.MESSAGE_PRACTICE_START,
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
			DeployQuestion(context);
        }

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Execute(IContext context)
		{
			base.Execute(context);
			var data = GetLocalContainer<LocalContainer>(context);
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
		private async void DeployQuestion(IContext context)
		{
			var rootContainer = GetMainContext(context).Container;
            context.Container.AddService(await ReadQuestion(rootContainer));
			GetLocalContainer<LocalContainer>(context).Downloaded = true;
		}

		/// <summary>
		/// 問題一覧を読み込みます。
		/// </summary>
		/// <param name="container">ルート コンテナ。</param>
		/// <returns>問題一覧。</returns>
		private async Task<IDictionary<int, QuestionData>> ReadQuestion(
			ServiceContainer container)
		{
			var college = container.GetService<Tuple<CollegeMasterData>>();
			var subject = container.GetService<Tuple<SubjectMasterData>>();
			if (college == null || subject == null)
			{
				throw new InvalidOperationException();
			}
			else
			{
				var result = await Api.GetQuestionAsync(college.Item1, subject.Item1);
				return result.ToDictionary(
					keySelector: p => p.Key, elementSelector: p => p.Value);
			}
		}
	}
}
