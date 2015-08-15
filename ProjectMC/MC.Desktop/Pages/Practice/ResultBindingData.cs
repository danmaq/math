using System;
using System.Collections.Generic;
using System.Globalization;
using MC.Common.Data;
using MC.Common.Utils;
using MC.Desktop.Properties;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// プラクティス結果用画面データ。
	/// </summary>
	sealed class ResultBindingData
	{

		/// <summary>
		/// 問題数を取得、または設定します。
		/// </summary>
		public int Length
		{
			get;
			set;
		}

		/// <summary>
		/// 正解数を取得、または設定します。
		/// </summary>
		public int Correct
		{
			get;
			set;
		}

		/// <summary>
		/// 合格かどうかを取得、または設定します。
		/// </summary>
		public bool Passed
		{
			get;
			set;
		}

		/// <summary>
		/// 教科マスタを取得、または設定します。
		/// </summary>
		public SubjectMasterData SubjectMasterData
		{
			get;
			set;
		}

		/// <summary>
		/// 合格かどうかを表現する文字列を取得します。
		/// </summary>
		public string StringedPassed => Passed ? Resources.MSG_PASSED : Resources.MSG_FAILED;

		/// <summary>
		/// 正答数を文字列形式で取得します。
		/// </summary>
		public string StringedCorrect =>
			string.Format(
				CultureInfo.CurrentUICulture, Resources.MSG_CORRECT_COUNT, Length, Correct);

		/// <summary>
		/// 正答率を0～1の間で取得します。
		/// </summary>
		public float CorrectPercentage => Correct / (float)Math.Max(Length, 1) * 100;

		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(ResultBindingData),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(Length)] = Length,
						[nameof(Correct)] = Correct,
						[nameof(Passed)] = StringedPassed,
						[nameof(CorrectPercentage)] = CorrectPercentage,
						[nameof(SubjectMasterData)] = SubjectMasterData,
					});
	}
}
