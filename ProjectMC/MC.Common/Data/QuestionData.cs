using System.Collections.Generic;
using System.Linq;
using MC.Common.Collection;
using MC.Common.Utils;

namespace MC.Common.Data
{

	/// <summary>
	/// 問題データ。
	/// </summary>
	struct QuestionData
	{

		/// <summary>
		/// 問題管理番号。
		/// </summary>
		public int UniqueId
		{
			get;
			internal set;
		}

		/// <summary>
		/// 問題。
		/// </summary>
		public string Caption
		{
			get;
			internal set;
		}

		/// <summary>
		/// 問題。
		/// </summary>
		public string Description
		{
			get;
			internal set;
		}

		/// <summary>
		/// 回答一覧。
		/// </summary>
		public IEnumerable<string> Answers
		{
			get;
			internal set;
		}

		/// <summary>
		/// 有効期限。
		/// </summary>
		public int Expires
		{
			get;
			internal set;
		}

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(QuestionData valueA, QuestionData valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(QuestionData valueA, QuestionData valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(QuestionData)} Caption:{Caption}, Description:{Description} Expires:{Expires}, Answers:{Answers.ToStringCollection()}");

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			Caption.GetHashCode() ^
			Description.GetHashCode() ^
			Expires.GetHashCode() ^
			Answers.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is QuestionData ? Equals((QuestionData)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(QuestionData others) =>
			Caption == others.Caption &&
			Description == others.Description &&
			Expires == others.Expires &&
			Answers.SequenceEqual(others.Answers);
	}
}
