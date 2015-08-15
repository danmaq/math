﻿using System.Collections.Generic;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// プラクティス画面で使用する共通データ。
	/// </summary>
	public sealed class PracticeData
	{
		/// <summary>
		/// 回答番号を取得、または設定します。
		/// </summary>
		internal int Answer
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

		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(PracticeData),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(Length)] = Length,
						[nameof(CorrectCount)] = CorrectCount,
					});
	}
}
