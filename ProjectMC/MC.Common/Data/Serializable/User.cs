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
	/// エクスポート可能なユーザ マスタ データ。
	/// </summary>
	[DataContract]
	public struct User : IEquatable<User>
	{

		/// <summary>
		/// ユーザIDを取得または設定します。
		/// </summary>
		[DataMember]
		public long UserId
		{
			get;
			set;
		}

		/// <summary>
		/// ニックネームを取得または設定します。
		/// </summary>
		[DataMember]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// 一言を取得または設定します。
		/// </summary>
		[DataMember]
		public string Comment
		{
			get;
			set;
		}

		/// <summary>
		/// 入学した学園一覧を取得または設定します。
		/// </summary>
		[DataMember]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		public int[] Admission
		{
			get;
			set;
		}

		/// <summary>
		/// 挑戦した講義一覧を取得または設定します。
		/// </summary>
		[DataMember]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		public Dictionary<int, TryAndClear>[] Tryed
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
		public static bool operator ==(User valueA, User valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(User valueA, User valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(User)} ID:{UserId}, Name:{Name}, Comment:{Comment}, Admission:[{Admission.ToStringCollection()}], Tryed:[{Tryed.ToStringCollection()}])");


		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			UserId.GetHashCode() ^
			Name.GetHashCode() ^
			Comment.GetHashCode() ^
			Admission.Aggregate(seed: 0, func: (a, s) => a ^ s.GetHashCode()) ^
			Tryed.Aggregate(seed: 0, func: (a, s) => a ^ s.GetHashCode());

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is User ? Equals((User)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(User others) =>
			UserId == others.UserId &&
			Name == others.Name &&
			Comment == others.Comment &&
			Admission.SequenceEqual(others.Admission) &&
			Tryed.SequenceEqual(others.Tryed);
	}
}
