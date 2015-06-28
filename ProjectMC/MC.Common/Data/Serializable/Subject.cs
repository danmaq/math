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
	public struct Subject
    {

		/// <summary>
		/// 教科 ID を取得します。
		/// </summary>
		[DataMember]
		public int SubjectId
		{
			get;
			set;
		}

		/// <summary>
		/// 教科名を取得します。
		/// </summary>
		[DataMember]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// 解説を取得します。
		/// </summary>
		[DataMember]
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// 有効かどうかを取得します。
		/// </summary>
		[DataMember]
		public bool Enabled
		{
			get;
			set;
		}

		/// <summary>
		/// 所属学園 ID を取得します。
		/// </summary>
		[DataMember]
		public int CollegeId
		{
			get;
			set;
		}

		/// <summary>
		/// 必要教科 ID を取得および設定します。
		/// </summary>
		[DataMember]
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
			StringHelper.Format(
				$@"{nameof(Subject)} ID:{SubjectId}, Name:{Name}, Description:{Description}, Enabled:{Enabled}, College:{CollegeId} Require:[{RequireSubjects.ToStringCollection()}])");

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
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(Subject others) =>
			SubjectId == others.SubjectId &&
			Name == others.Name &&
			Description == others.Description &&
			Enabled == others.Enabled &&
			CollegeId == others.CollegeId &&
			RequireSubjects.SequenceEqual(others.RequireSubjects);
	}
}
