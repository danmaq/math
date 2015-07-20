using System;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// 文字列入力を要求するイベント データです。
	/// </summary>
	public sealed class RequireTextArgs : RequireResponseArgs
	{

		/// <summary>レスポンス用コールバックを取得します。</summary>
		public Action<string> Response
		{
			get;
			internal set;
		} = DelegateHelper.CreateEmptyAction<string>();

		/// <summary>レスポンス文字列のバリデータを取得します。</summary>
		public Func<string, string> Validate
		{
			get;
			internal set;
		} = _ => null;

		/// <summary>
		/// ToString() メソッドに使う、クラス名を取得します。
		/// </summary>
		protected override string ClassName
		{
			get;
		}
		= nameof(RequireTextArgs);
	}
}
