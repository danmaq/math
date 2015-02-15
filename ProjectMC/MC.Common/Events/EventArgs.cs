﻿using System;
using System.Globalization;

namespace MC.Common.Events
{

	/// <summary>
	/// 値を持つ、イベント データ。
	/// </summary>
	/// <typeparam name="T">値の型。</typeparam>
	public class EventArgs<T> : EventArgs
	{

		/// <summary>値を取得、または設定します。</summary>
		public T Data
		{
			get;
			set;
		}

		/// <summary>
		/// オブジェクトの文字列表現を取得します。
		/// </summary>
		/// <returns>文字列表現。</returns>
		public override string ToString()
			=>
				string.Format(
					CultureInfo.CurrentCulture,
					@"{0}({1}) Data:{2}",
					nameof(EventArgs),
					nameof(T),
					Data);
	}
}