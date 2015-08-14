using MC.Common.Utils;
using MC.Desktop.Properties;
using System.Collections.Generic;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// プラクティス画面用の画面データ。
	/// </summary>
	sealed class PracticeBindingData
	{

		/// <summary>
		/// インタラクティブな操作を受け付けるかどうかを取得、または設定します。
		/// </summary>
		public bool Interactive
		{
			get;
			set;
		}

		/// <summary>
		/// 問題番号を取得、および設定します。
		/// </summary>
		public int Number
		{
			get;
			set;
		}
		= 1;

		/// <summary>
		/// 文字列化した問題番号を取得します。
		/// </summary>
		public string StringedNumber => string.Format(@"Q{0}", Number);

		/// <summary>
		/// 問題文を取得、および設定します。
		/// </summary>
		public string Caption
		{
			get;
			set;
		}
		= Resources.MSG_PRACTICE_CAPTION;

		/// <summary>
		/// 問題の解説文を取得、および設定します。
		/// </summary>
		public string Description
		{
			get;
			set;
		}
		= Resources.MSG_PRACTICE_DESCRIPTION;

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer1
		{
			get;
			set;
		}
		= Resources.MSG_PRACTICE_ANSWER1;

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer2
		{
			get;
			set;
		}
		= Resources.MSG_PRACTICE_ANSWER2;

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer3
		{
			get;
			set;
		}
		= Resources.MSG_PRACTICE_ANSWER3;

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer4
		{
			get;
			set;
		}
		= Resources.MSG_PRACTICE_ANSWER4;

		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(PracticeBindingData),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(Number)] = Number,
						[nameof(Caption)] = Caption,
						[nameof(Description)] = Description,
						[nameof(Answer1)] = Answer1,
						[nameof(Answer2)] = Answer2,
						[nameof(Answer3)] = Answer3,
						[nameof(Answer4)] = Answer4,
					});
	}
}
