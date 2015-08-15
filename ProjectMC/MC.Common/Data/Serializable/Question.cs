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
	/// エクスポート可能な問題データ。
	/// </summary>
	[DataContract]
	public struct Question : IEquatable<Question>
	{

		/// <summary>
		/// 問題管理番号を取得、または設定します。
		/// </summary>
		[DataMember]
		public int UniqueId
		{
			get;
			set;
		}

		/// <summary>
		/// 問題を取得、または設定します。
		/// </summary>
		[DataMember]
		public string Caption
		{
			get;
			set;
		}

		/// <summary>
		/// 問題を取得、または設定します。
		/// </summary>
		[DataMember]
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// 回答一覧を取得、または設定します。
		/// </summary>
		[DataMember]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		public string[] Answers
		{
			get;
			set;
		}

		/// <summary>
		/// 有効期限を取得、または設定します。
		/// </summary>
		[DataMember]
		public int Expires
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
		public static bool operator ==(Question valueA, Question valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(Question valueA, Question valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(Question),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(Caption)] = Caption,
						[nameof(Description)] = Description,
						[nameof(Expires)] = Expires,
						[nameof(Answers)] = Answers.ToStringCollection(),
					});

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			Caption.GetHashCode() ^
			Description.GetHashCode() ^
			Expires.GetHashCode() ^
			Answers.Aggregate(seed: 0, func: (a, s) => a ^ s.GetHashCode());

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is Question ? Equals((Question)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="other"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(Question other) =>
			Caption == other.Caption &&
			Description == other.Description &&
			Expires == other.Expires &&
			Answers.SequenceEqual(other.Answers);
	}
}
