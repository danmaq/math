using System.Collections.Generic;
using System.Globalization;

namespace MC.Common.Data
{

	/// <summary>
	/// 問題データ。
	/// </summary>
	public struct QuestionData
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
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			string.Format(
				CultureInfo.CurrentCulture,
				@"{0} Caption:{1}, Description:{2} Expires:{3}, Answers:{4}",
				nameof(QuestionData),
				Caption,
				Description,
				Expires,
				Answers);
	}
}
