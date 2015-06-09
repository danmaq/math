
using System.Collections.Generic;

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
			private set;
		}

		/// <summary>
		/// 回答一覧。
		/// </summary>
		public IEnumerable<string> Answers
		{
			get;
			private set;
		}

		/// <summary>
		/// 有効期限。
		/// </summary>
		public int expires
		{
			get;
			private set;
		}
	}
}
