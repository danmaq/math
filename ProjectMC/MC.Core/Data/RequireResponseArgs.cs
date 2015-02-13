using System;
using System.Globalization;

namespace MC.Core.Data
{
	/// <summary>
	/// レスポンスが必要な状態になった際のイベントと一緒に渡される引数クラスです。
	/// </summary>
	public abstract class RequireResponseArgs : EventArgs
	{

		/// <summary>解説文書を取得、または設定します。</summary>
		public string Description
		{
			get;
			internal set;
		}


		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() =>
			string.Format(
				CultureInfo.CurrentCulture,
				@"{0}, Desc:{1}",
				nameof(RequireResponseArgs),
				Description);
	}
}
