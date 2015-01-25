using System;

namespace MC.Common.State
{
	/// <summary>
	/// State パターンにおけるコンテキストの拡張機能。
	/// </summary>
	public static class ContextExtension
	{

		/// <summary>
		/// 状態が既定に戻り、外部から手を加えない限りこれ以上進展することがない状態に至っているかどうかを取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>状態が既定に戻り、外部から手を加えない限りこれ以上進展することがない状態である場合、true。</returns>
		public static bool IsTerminate(this IContext context)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 強制的に状態を既定に戻します。
		/// 次回状態実行時に既定の状態に戻ります。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		public static void Terminate(this IContext context)
		{
			context.Terminate(immediately: true);
		}

		/// <summary>
		/// 強制的に状態を既定に戻します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <param name="immediately">
		/// 即時実行するかどうか。この値が true である場合、状態が既定に戻るのを阻止できません。
		/// </param>
		public static void Terminate(this IContext context, bool immediately)
		{
			throw new NotImplementedException();
		}
	}
}
