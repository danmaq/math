using System;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// レスポンスが必要な状態になった際のイベントと一緒に渡される引数クラスです。
	/// </summary>
	abstract class RequireResponseArgs : EventArgs
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
			StringHelper.Format($@"{nameof(RequireResponseArgs)} Description:{Description}");
	}
}
