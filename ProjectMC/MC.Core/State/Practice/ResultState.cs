using System.Diagnostics;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Core.Properties;

namespace MC.Core.State.Practice
{

	/// <summary>
	/// 結果表示の状態。
	/// </summary>
	sealed class ResultState : PracticeStateBase
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private ResultState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new ResultState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Begin(IContext context)
		{
			base.Begin(context);
			var flow = GameFlow.GetService(GetMainContext(context));
			var args =
				new RequireAlertArgs()
				{
					Caption = Resources.MESSAGE_PRACTICE_ENDED,
					AdditionalData = GetPracticeData(context),
					Response = () => context.Terminate(),
				};
			flow.DispatchRequireResponse(args);
		}
	}
}
