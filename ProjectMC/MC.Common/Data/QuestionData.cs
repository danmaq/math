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
		/// 問題。
		/// </summary>
		public string Question
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
				@"{0} Question:{1}, Expires:{2}, Answers:{3}",
				nameof(QuestionData),
				Question,
				Expires,
				Answers);
	}
}
