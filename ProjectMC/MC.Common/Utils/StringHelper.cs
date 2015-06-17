using System;
using System.Globalization;

namespace MC.Common.Utils
{
	/// <summary>
	/// 文字列関係のヘルパ クラス。
	/// </summary>
	static class StringHelper
	{
		/// <summary>
		/// 文字列を整形します。
		/// </summary>
		/// <param name="formattable">整形用文字列。</param>
		/// <returns>文字列。</returns>
		public static string Format(this FormattableString formattable) =>
			formattable?.ToString(CultureInfo.CurrentCulture);
	}
}
