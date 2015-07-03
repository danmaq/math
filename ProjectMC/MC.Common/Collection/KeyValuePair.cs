using System.Collections.Generic;

namespace MC.Common.Collection
{

	/// <summary>
	/// キー/値ペアを生成するヘルパ クラス。
	/// </summary>
    static class KeyValuePair
    {

		/// <summary>
		/// キー/値ペアを生成します。
		/// </summary>
		/// <typeparam name="TKey">キーの型。</typeparam>
		/// <typeparam name="TValue">値の型。</typeparam>
		/// <param name="key">キー。</param>
		/// <param name="value">値。</param>
		/// <returns>キー/値ペア。</returns>
		public static KeyValuePair<TKey, TValue> Create<TKey, TValue>(TKey key, TValue value) =>
			new KeyValuePair<TKey, TValue>(key, value);
    }
}
