﻿using CocosSharp;
using MC.Properties;

namespace MC
{
	/// <summary>
	/// 雑多な関数群クラス。
	/// </summary>
	public static class Misc
	{

		/// <summary>既定の解像度を取得します。</summary>
		public static CCSize DefaultResolution
		{
			get;
		}
		=
			new CCSize()
			{
                Width = int.Parse(s: Resources.DEFAULT_WIDTH),
				Height = int.Parse(s: Resources.DEFAULT_HEIGHT),
			};

	}
}
