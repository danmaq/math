using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// プラクティス画面用の画面データ。
	/// </summary>
	sealed class PracticeBindingData
	{

		/// <summary>
		/// 問題番号を取得、および設定します。
		/// </summary>
		public int Number
		{
			get;
			set;
		}

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

		/// <summary>
		/// 問題の解説文を取得、および設定します。
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer1
		{
			get;
			set;
		}

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer2
		{
			get;
			set;
		}

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer3
		{
			get;
			set;
		}

		/// <summary>
		/// 問題の回答を取得、および設定します。
		/// </summary>
		public string Answer4
		{
			get;
			set;
		}
	}
}
