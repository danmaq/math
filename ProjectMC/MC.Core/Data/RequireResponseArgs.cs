using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// レスポンスが必要な状態になった際のイベントと一緒に渡される引数クラスです。
	/// </summary>
	public abstract class RequireResponseArgs : EventArgs
	{

		/// <summary>レスポンスを要求する文章文字列を取得、または設定します。</summary>
		public string Caption
		{
			get;
			internal set;
		}
		= string.Empty;

		/// <summary>
		/// 追加の解説文を取得します。
		/// </summary>
		public string Desctiption
		{
			get;
			internal set;
		}
		= string.Empty;

		/// <summary>
		/// 付加的なデータ。
		/// </summary>
		public object AdditionalData
		{
			get;
			internal set;
		}
		= new object();

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
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		protected virtual IEnumerable<KeyValuePair<string, object>> Arguments =>
			new Dictionary<string, object>()
			{
				[nameof(Caption)] = Caption,
				[nameof(Desctiption)] = Desctiption,
				[nameof(AdditionalData)] = AdditionalData,
			};

		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() => StringHelper.CreateToString(ClassName, Arguments);
	}
}
