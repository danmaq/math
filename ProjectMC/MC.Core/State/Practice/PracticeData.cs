using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Core.State.Practice
{
	/// <summary>
	/// プラクティス画面で使用する共通データ。
	/// </summary>
	sealed class PracticeData
	{
		/// <summary>
		/// 回答番号を取得、または設定します。
		/// </summary>
		public int Answer
		{
			get;
			set;
		}

		/// <summary>
		/// 問題数を取得、または設定します。
		/// </summary>
		public int Length
		{
			get;
			set;
		}

		/// <summary>
		/// 問題数を取得、または設定します。
		/// </summary>
		public int CorrectCount
		{
			get;
			set;
		}
	}
}
