using System;
using MC.Common.Utils;

namespace MC.Common.Data
{
	/// <summary>
	/// カード マスタの単票データ。
	/// </summary>
	struct CardMasterData : IEquatable<CardMasterData>
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="name">キャラクタ名。</param>
		/// <param name="comment">一言。</param>
		/// <param name="college">所属大学。</param>
		public CardMasterData(string name, string comment, CollegeMasterData college)
		{
			Name = name ?? string.Empty;
			Comment = comment ?? string.Empty;
			College = college;
		}

		/// <summary>ニックネームを取得または設定します。</summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>一言を取得または設定します。</summary>
		public string Comment
		{
			get;
			private set;
		}

		/// <summary>
		/// 所属学園を取得します。
		/// </summary>
		public CollegeMasterData College
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
		public static bool operator ==(CardMasterData valueA, CardMasterData valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(CardMasterData valueA, CardMasterData valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(CardMasterData)} Name:{Name}, Comment:{Comment}, College:{College.Name}");

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			(Name ?? string.Empty).GetHashCode() ^
			(Comment ?? string.Empty).GetHashCode() ^
			College.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is CardMasterData ? Equals((CardMasterData)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(CardMasterData others) =>
			Name == others.Name && Comment == others.Comment && College == others.College;
	}
}
