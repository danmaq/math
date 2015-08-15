using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MC.Common.Utils;

namespace MC.Common.Data.IO
{
	/// <summary>
	/// シリアライズ可能なキー・値のペア。
	/// </summary>
	/// <typeparam name="TKey">キーの型。</typeparam>
	/// <typeparam name="TValue">値の型。</typeparam>
	[Serializable]
	[XmlType(TypeName = "KV")]
	public struct SerializablePair<TKey, TValue> : IEquatable<SerializablePair<TKey, TValue>>
	{
		/// <summary>
		/// キーを取得、または設定します。
		/// </summary>
		public TKey Key
		{
			get;
			set;
		}

		/// <summary>
		/// 値を取得、または設定します。
		/// </summary>
		public TValue Value
		{
			get;
			set;
		}

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(
			SerializablePair<TKey, TValue> valueA, SerializablePair<TKey, TValue> valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(
			SerializablePair<TKey, TValue> valueA, SerializablePair<TKey, TValue> valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(SerializablePair<TKey, TValue>),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(Key)] = Key,
						[nameof(Value)] = Value,
					});

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() => Key.GetHashCode() ^ Value.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is SerializablePair<TKey, TValue> ?
			Equals((SerializablePair<TKey, TValue>)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="other"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(SerializablePair<TKey, TValue> other) =>
			Convert.Equals(Key, other.Key) && Convert.Equals(Value, other.Value);
	}

	/// <summary>
	/// シリアライズ可能なキー・値のペアを生成するための便利関数群クラス。
	/// </summary>
	public static class SerializablePair
	{

		/// <summary>
		/// シリアライズ可能なキー・値のペアを生成します。
		/// </summary>
		/// <typeparam name="TKey">キーの型。</typeparam>
		/// <typeparam name="TValue">値の型。</typeparam>
		/// <param name="pair">キー・値のペア。</param>
		/// <returns>シリアライズ可能なキー・値のペア。</returns>
		public static SerializablePair<TKey, TValue> Create<TKey, TValue>(
			KeyValuePair<TKey, TValue> pair) =>
			new SerializablePair<TKey, TValue>()
			{
				Key = pair.Key,
				Value = pair.Value,
			};

		/// <summary>
		/// シリアライズ可能なキー・値のペアを生成します。
		/// </summary>
		/// <typeparam name="TKey">キーの型。</typeparam>
		/// <typeparam name="TValue">値の型。</typeparam>
		/// <param name="key">キー。</param>
		/// <param name="value">値。</param>
		/// <returns>シリアライズ可能なキー・値のペア。</returns>
		public static SerializablePair<TKey, TValue> Create<TKey, TValue>(TKey key, TValue value) =>
			new SerializablePair<TKey, TValue>()
			{
				Key = key,
				Value = value,
			};
	}
}
