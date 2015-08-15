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
	/// エクスポート可能な教科マスタの単票データ。
	/// </summary>
	[DataContract]
	public struct Subject : IEquatable<Subject>
	{

		/// <summary>
		/// 教科 ID を取得、または設定します。
		/// </summary>
		[DataMember]
		public int SubjectId
		{
			get;
			set;
		}

		/// <summary>
		/// 教科名を取得、または設定します。
		/// </summary>
		[DataMember]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// 解説を取得、または設定します。
		/// </summary>
		[DataMember]
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// 有効かどうかを取得、または設定します。
		/// </summary>
		[DataMember]
		public bool Enabled
		{
			get;
			set;
		}

		/// <summary>
		/// 所属学園 ID を取得、または設定します。
		/// </summary>
		[DataMember]
		public int CollegeId
		{
			get;
			set;
		}

		/// <summary>
		/// 必要教科 ID を取得、または設定します。
		/// </summary>
		[DataMember]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		public int[] RequireSubjects
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
		public static bool operator ==(Subject valueA, Subject valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(Subject valueA, Subject valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(Subject),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(SubjectId)] = SubjectId,
						[nameof(Name)] = Name,
						[nameof(Description)] = Description,
						[nameof(Enabled)] = Enabled,
						[nameof(CollegeId)] = CollegeId,
						[nameof(RequireSubjects)] = RequireSubjects.ToStringCollection(),
					});

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			SubjectId.GetHashCode() ^
			Name.GetHashCode() ^
			Description.GetHashCode() ^
			Enabled.GetHashCode() ^
			CollegeId.GetHashCode() ^
			RequireSubjects.Aggregate(seed: 0, func: (a, s) => a ^ s.GetHashCode());

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is Subject ? Equals((Subject)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="other"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(Subject other) =>
			SubjectId == other.SubjectId &&
			Name == other.Name &&
			Description == other.Description &&
			Enabled == other.Enabled &&
			CollegeId == other.CollegeId &&
			RequireSubjects.SequenceEqual(other.RequireSubjects);
	}
}
