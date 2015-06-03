using System.Collections.ObjectModel;
using MC.Common.State;
using MC.Core.Data;

namespace MC.Core.State.Game
{
	sealed class LoginState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private LoginState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new LoginState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Begin(IContext context)
		{
			/*
			var selection =
				new Selection[]
				{
					Selection.Default.CopyTo(description: @"ほげ"),
					Selection.Default.CopyTo(description: @"ふが"),
				};
			var args =
				new RequireSelectArgs()
				{
					Description = @"ぴよぷよ",
					Expires = 10,
					Selections = new ReadOnlyCollection<Selection>(selection),
				};
			var flow = context.Container.GetService<GameFlow>();
			if (flow != null)
			{
				flow.DispatchRequireResponse(args: args);
			}
			*/
		}

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Execute(IContext context)
		{
			context.NextState = TitleState.Instance;
		}

		/// <summary>
		/// 他の状態に移行する直前に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public void Teardown(IContext context)
		{
		}
	}
}
