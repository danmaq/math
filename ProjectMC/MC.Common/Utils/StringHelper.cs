using System;
using System.Globalization;

namespace MC.Common.Utils
{
	public static class StringHelper
	{

		public static string Format(this IFormattable formattable) =>
			formattable.ToString(null, CultureInfo.CurrentCulture);
	}
}
