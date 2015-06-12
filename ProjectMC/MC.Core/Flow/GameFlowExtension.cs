using System;
using MC.Core.Data;

namespace MC.Core.Flow
{
	static class GameFlowExtension
	{

		/// <summary>
		/// 入力要求イベントを発火させます。
		/// </summary>
		/// <param name="flow">ゲームフロー オブジェクト。</param>
		/// <param name="args">入力要求に必要なデータ。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public static void DispatchRequireResponse(this IGameFlow flow, RequireResponseArgs args)
		{
			var concrete = flow as GameFlow;
			if (concrete != null)
			{
				concrete.DispatchRequireResponse(args);
            }
		}

		/// <summary>
		/// 入力タイムアウト イベントを発火させます。
		/// </summary>
		/// <param name="flow">ゲームフロー オブジェクト。</param>
		public static void DispatchTimeout(this IGameFlow flow)
		{
			var concrete = flow as GameFlow;
			if (concrete != null)
			{
				concrete.DispatchTimeout();
			}
		}
	}
}
