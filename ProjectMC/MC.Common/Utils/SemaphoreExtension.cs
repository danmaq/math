using System;
using System.Threading;
using System.Threading.Tasks;

namespace MC.Common.Utils
{
	/// <summary>
	/// セマフォのための拡張機能。
	/// </summary>
	public static class SemaphoreExtension
	{
		/// <summary>
		/// アクションを非同期に実行します。
		/// </summary>
		/// <param name="semaphore">セマフォ。</param>
		/// <param name="callback">実行したいアクション。</param>
		/// <returns>非同期操作用オブジェクト。</returns>
		public static async Task RunActionWaitAsync(
			this SemaphoreSlim semaphore, Action callback)
		{
			await semaphore.WaitAsync();
			try
			{
				callback();
            }
			finally
			{
				semaphore.Release();
			}
		}

		/// <summary>
		/// アクションを非同期に実行します。
		/// </summary>
		/// <typeparam name="T">返したい値の型。</typeparam>
		/// <param name="semaphore">セマフォ。</param>
		/// <param name="callback">実行したいアクション。</param>
		/// <returns>非同期操作用オブジェクト。</returns>
		public static async Task<T> RunActionWaitAsync<T>(
			this SemaphoreSlim semaphore, Func<T> callback)
		{
			await semaphore.WaitAsync();
			try
			{
				return callback();
			}
			finally
			{
				semaphore.Release();
			}
		}
	}
}
