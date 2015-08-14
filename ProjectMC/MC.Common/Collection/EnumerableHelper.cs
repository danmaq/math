using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MC.Common.Collection
{
	/// <summary>
	/// LINQ 関係のヘルパ クラス。
	/// </summary>
	public static class EnumerableHelper
	{

		/// <summary>
		/// 一定個数の値を生成します。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="count">件数。</param>
		/// <param name="generator">値を生成する関数。引数にはこれまで作成された値の個数が格納されます。</param>
		/// <param name="predicate">値を検証する関数。引数には値とこれまで作成された値一覧が格納されます。</param>
		/// <returns>値の一覧を生成するシーケンス。</returns>
		/// <exception cref="ArgumentNullException">各関数が null である場合。</exception>
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<T> Generate<T>(int count, Func<int, T> generator, Func<T, IEnumerable<T>, bool> predicate)
		{
			if (generator == null)
			{
				throw new ArgumentNullException(nameof(generator));
			}
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}
			var result = new List<T>(count);
			while (result.Count < count)
			{
				var value = generator(result.Count);
				if (predicate(value, result))
				{
					result.Add(value);
				}
			}
			return result;
		}

		/// <summary>
		/// 一定個数の値を生成します。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="count">件数。</param>
		/// <param name="generator">値を生成する関数。</param>
		/// <returns>値の一覧を生成するシーケンス。</returns>
		/// <exception cref="ArgumentNullException">各関数が null である場合。</exception>
		public static IEnumerable<T> Generate<T>(int count, Func<int, T> generator) =>
			Generate(count: count, generator: generator, predicate: (_, __) => true);

		/// <summary>
		/// 一定個数のユニークな値を生成します。
		/// ユニーク判定を行うため、 <paramref name="generator"/> が一定値のみを返す関数である場合、無限ループに陥る可能性があります。
		/// </summary>
		/// <typeparam name="T">値の型。</typeparam>
		/// <param name="count">件数。</param>
		/// <param name="generator">値を生成する関数。</param>
		/// <returns>値の一覧を生成するシーケンス。</returns>
		/// <exception cref="ArgumentNullException">各関数が null である場合。</exception>
		public static IEnumerable<T> GenerateUnique<T>(int count, Func<int, T> generator) =>
			Generate(
				count: count, generator: generator, predicate: (v, l) => l.All(i => !v.Equals(i)));

		/// <summary>
		/// キーと値のペアを作成します。
		/// </summary>
		/// <typeparam name="TKey">キーの型。</typeparam>
		/// <typeparam name="TValue">値の型。</typeparam>
		/// <param name="key">キー。</param>
		/// <param name="value">値。</param>
		/// <returns>キーと値のペア。</returns>
		public static KeyValuePair<TKey, TValue> CreatePair<TKey, TValue>(TKey key, TValue value) =>
			new KeyValuePair<TKey, TValue>(key, value);
	}
}
