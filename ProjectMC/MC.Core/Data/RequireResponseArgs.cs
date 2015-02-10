using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MC.Core.Data
{
	/// <summary>
	/// レスポンスが必要な状態になった際のイベントと一緒に渡される引数クラスです。
	/// </summary>
	public sealed class RequireResponseArgs : EventArgs
	{

		/// <summary>選択肢を取得、または設定します。</summary>
		public IEnumerable<string> Selection
		{
			get;
			set;
		}

		/// <summary>現在の画面状態を取得、または設定します。</summary>
		public ScreenStatus Status
		{
			get;
			set;
		}

		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() =>
			string.Format(
				CultureInfo.CurrentCulture,
				@"RequireResponseArgs Status:{0}, Selecton: {1}",
				Status,
				Selection.Aggregate(seed: string.Empty, func: (a, s) => a + s.ToString()));
	}
}
