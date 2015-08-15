using System.Collections.Generic;
using MC.Common.Data;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// プラクティス画面で使用する共通データ。
	/// </summary>
	public sealed class PracticeData
	{
		/// <summary>
		/// 教科マスタを取得、または設定します。
		/// </summary>
		public SubjectMasterData SubjectMasterData
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
		/// 正解の可否問わず全問突破したかどうかを取得、または設定します。
		/// </summary>
		public bool Cleard
		{
			get;
			set;
		}

		/// <summary>
		/// 合格したかどうかを取得、または設定します。
		/// </summary>
		// TODO: 判定はモックサーバ側で行う！
		public bool Passed =>
			Cleard && (CorrectCount / (float)Length) > Constants.PracticeThreshold;

		/// <summary>
		/// 回答番号を取得、または設定します。
		/// </summary>
		internal int Answer
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
						[nameof(Cleard)] = Cleard,
						[nameof(Passed)] = Passed,
						[nameof(SubjectMasterData)] = SubjectMasterData,
					});
	}
}
