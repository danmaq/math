using System;
using System.Collections.Generic;
using MC.Common.Utils;

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
		/// ToString() メソッドに使う、クラス名を取得します。
		/// </summary>
		protected virtual string ClassName
		{
			get;
		}
		= nameof(RequireResponseArgs);

		/// <summary>
		/// ToString() メソッドに使う、引数一覧を取得します。
		/// </summary>
		protected virtual IEnumerable<KeyValuePair<string, object>> Arguments =>
			new Dictionary<string, object>() {[nameof(Description)] = Description };

		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() => StringHelper.CreateToString(ClassName, Arguments);
	}
}
