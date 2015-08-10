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
					Response = () => context.NextState = null,
					// TODO: 次の状態
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
		/// 問題一覧をコンテナに配置します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		private async void DeployQuestion(IContext context)
		{
			var rootContainer = GetMainContext(context).Container;
            context.Container.AddService(await ReadQuestion(rootContainer));
			Prompt(context);
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
