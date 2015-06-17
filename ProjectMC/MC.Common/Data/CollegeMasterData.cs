using System.Collections.Generic;
using System.Collections.ObjectModel;
using MC.Common.Collection;
using MC.Common.Utils;

namespace MC.Common.Data
{
	/// <summary>
	/// 学園マスタの単票データ。
	/// </summary>
	struct CollegeMasterData
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="id">教科 ID。</param>
		/// <param name="name">教科名。</param>
		/// <param name="description">解説。</param>
		/// <param name="enabled">有効かどうか。</param>
		/// <param name="requires">受講に必要な教科一覧。</param>
		public CollegeMasterData(
			int id,
			string name,
			string description,
			bool enabled,
			IReadOnlyCollection<SubjectMasterData> requires)
		{
			CollegeId = id;
			Name = name ?? string.Empty;
			Description = description ?? string.Empty;
			Enabled = enabled;
			Requires =
				requires ?? new ReadOnlyCollection<SubjectMasterData>(new SubjectMasterData[0]);
		}

		/// <summary>
		/// IDを取得します。
		/// </summary>
		public int CollegeId
		{
			get;
			private set;
		}

		/// <summary>
		/// 教科名を取得します。
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 解説を取得します。
		/// </summary>
		public string Description
		{
			get;
			private set;
		}

		/// <summary>
		/// 有効かどうかを取得します。
		/// </summary>
		public bool Enabled
		{
			get;
			private set;
		}

		/// <summary>
		/// 必要教科を取得します。
		/// </summary>
		public IReadOnlyCollection<SubjectMasterData> Requires
		{
			get;
			private set;
		}

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(CollegeMasterData valueA, CollegeMasterData valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(CollegeMasterData valueA, CollegeMasterData valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(CollegeMasterData)} ID:{CollegeId}, Name:{Name}, Description:{Description}, Enabled:{Enabled}, Requires:{Requires.ToStringCollection(s => s.Name)}");

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			CollegeId.GetHashCode() ^
			(Name ?? string.Empty).GetHashCode() ^
			(Description ?? string.Empty).GetHashCode() ^
			Enabled.GetHashCode() ^
			Requires.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is CollegeMasterData ? Equals((CollegeMasterData)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(CollegeMasterData others) =>
			CollegeId == others.CollegeId &&
			Name == others.Name &&
			Description == others.Description &&
			Enabled == others.Enabled &&
			Requires == others.Requires;
	}
}
