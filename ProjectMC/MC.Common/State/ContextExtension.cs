using System;

namespace MC.Common.State
{
	/// <summary>
	/// State パターンにおけるコンテキストの拡張機能。
	/// </summary>
	public static class ContextExtension
	{

		/// <summary>
		/// 状態を実行します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public static void Execute(this IContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			context.CurrentState.Execute(context: context);
			context.CommitNextState();
		}

		/// <summary>
		/// 状態が既定に戻り、外部から手を加えない限りこれ以上進展することがない状態に至っているかどうかを取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>状態が既定に戻り、外部から手を加えない限りこれ以上進展することがない状態である場合、true。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public static bool IsTerminate(this IContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			return context.CurrentState == NullState.Instance && context.NextState == null;
        }

		/// <summary>
		/// 強制的に現在の状態を既定に戻します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public static void Terminate(this IContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			context.NextState = NullState.Instance;
			context.CommitNextState();
		}
	}
}
