﻿using System.Diagnostics.CodeAnalysis;
using MC.Common.State;

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
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Begin(IContext context)
		{
			context.NextState = TitleState.Instance;
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
		}
	}
}
