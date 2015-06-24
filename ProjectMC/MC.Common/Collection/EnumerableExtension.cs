using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Utils;

namespace MC.Common.Collection
{
	/// <summary>
	/// 配列、リスト、クエリなどに対する拡張機能。
	/// </summary>
	static class EnumerableExtension
	{

		/// <summary>疑似乱数ジェネレータ。</summary>
		private static readonly Random random = new Random();

		/// <summary>
		/// 即座にクエリを評価し、その結果の要素一つ一つに対し、特定の処理を実行します。
		/// </summary>
		/// <param name="sequence">クエリ。</param>
		/// <param name="callback">要素に対し実行するコールバック。</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="sequence"/> が null である場合。
		/// </exception>
		public static void ForEach(this IEnumerable sequence, Action<object> callback)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException(nameof(sequence));
			}
			var c = callback ?? DelegateHelper.CreateEmptyAction<object>();
			foreach (var i in sequence)
			{
				c(i);
			}
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

		/// <summary>
		/// コレクションを文字列化します。
		/// </summary>
		/// <typeparam name="T">コレクションの型。</typeparam>
		/// <param name="sequence">コレクション。</param>
		/// <returns>文字列情報。</returns>
		public static string ToStringCollection<T>(this IEnumerable<T> sequence) =>
			sequence.ToStringCollection(v => v.ToString());

		/// <summary>
		/// コレクションを文字列化します。
		/// </summary>
		/// <typeparam name="T">コレクションの型。</typeparam>
		/// <param name="sequence">コレクション。</param>
		/// <param name="generator">文字列生成関数。</param>
		/// <returns>文字列情報。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public static string ToStringCollection<T>(this IEnumerable<T> sequence, Func<T, string> generator)
		{
			if (generator == null)
			{
				throw new ArgumentNullException(nameof(generator));
			}
			return
				sequence.Aggregate<T, string>(
					seed: null,
					func:
						(a, s) => a == null ?
						s.ToString() : StringHelper.Format($@"{a}, {generator(s)}"));
		}

		/// <summary>
		/// 一覧からランダムに取得します。
		/// </summary>
		/// <typeparam name="T">一覧の型。</typeparam>
		/// <param name="list">一覧。</param>
		/// <returns>値。</returns>
		/// <exception cref="ArgumentNullException">一覧が null である場合。</exception>
		/// <exception cref="ArgumentOutOfRangeException">一覧が空である場合。</exception>
		public static T GetRandomItem<T>(this IReadOnlyList<T> list)
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}
			var count = list.Count;
			if (count == 0)
			{
				throw new ArgumentOutOfRangeException(nameof(list));
			}
			return list[random.Next(count)];
		}
	}
}
