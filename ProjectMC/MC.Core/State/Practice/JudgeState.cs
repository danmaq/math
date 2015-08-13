using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Flow;

namespace MC.Core.State.Practice
{
	sealed class JudgeState : PracticeStateBase
	{

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
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public override void Begin(IContext context)
		{
			base.Begin(context);
			var dic = context.Container.GetService<IDictionary<int, QuestionData>>();
			var key = dic.First().Key;
			var ans = GetPracticeData(context).Answer;
        }
	}
}
