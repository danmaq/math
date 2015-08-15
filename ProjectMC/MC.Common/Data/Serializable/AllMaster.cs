using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using MC.Common.Collection;
using MC.Common.Utils;

namespace MC.Common.Data.Serializable
{
	/// <summary>
	/// すべてのマスタ。
	/// </summary>
	[DataContract]
	public struct AllMaster : IEquatable<AllMaster>
	{
		/// <summary>
		/// 学園一覧を取得、または設定します。
		/// </summary>
		[DataMember]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		public College[] College
		{
			get;
			set;
		}

		/// <summary>
		/// 教科一覧を取得、または設定します。
		/// </summary>
		[DataMember]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		public Subject[] Subject
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
		public static bool operator ==(AllMaster valueA, AllMaster valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(AllMaster valueA, AllMaster valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(AllMaster),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(College)] = College.ToStringCollection(),
						[nameof(Subject)] = Subject.ToStringCollection(),
					});

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			College.Aggregate(seed: 0, func: (a, s) => a ^ s.GetHashCode()) ^
			Subject.Aggregate(seed: 0, func: (a, s) => a ^ s.GetHashCode());

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is AllMaster ? Equals((AllMaster)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="other"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(AllMaster other) =>
			College.SequenceEqual(other.College) &&
			Subject.SequenceEqual(other.Subject);
	}
}
