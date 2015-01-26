using System;
using System.Collections.Generic;
using MC.Common.Utils;

namespace MC.Common.Collection
{
	/// <summary>
	/// 配列、リスト、クエリなどに対する拡張機能。
	/// </summary>
	public static class EnumerableExtension
	{

		/// <summary>
		/// 即座にクエリを評価します。
		/// 評価結果が不要である際に使用します。
		/// </summary>
		/// <typeparam name="T">シーケンスの型。</typeparam>
		/// <param name="sequence">クエリ。</param>
		/// <exception cref="ArgumentNullException">引数 が null である場合。</exception>
		public static void ForEach<T>(this IEnumerable<T> sequence)
		{
			sequence.ForEach(callback: null);
		}

		/// <summary>
		/// 即座にクエリを評価し、その結果の要素一つ一つに対し、特定の処理を実行します。
		/// </summary>
		/// <typeparam name="T">シーケンスの型。</typeparam>
		/// <param name="sequence">クエリ。</param>
		/// <param name="callback">要素に対し実行するコールバック。</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="sequence"/> が null である場合。
		/// </exception>
		public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> callback)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException(nameof(sequence));
			}
			var c = callback ?? DelegateHelper.CreateEmptyAction<T>();
			foreach (var i in sequence)
			{
				c(i);
			}
		}
	}
}
