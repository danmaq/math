using System;
using System.Globalization;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// 選択肢データ。
	/// </summary>
	public struct Selection
	{

		/// <summary>既定のデータ。</summary>
		public static readonly Selection Default =
			new Selection() { Select = DelegateHelper.EmptyAction, Description = string.Empty };

		/// <summary>選択用コールバック。</summary>
		public Action Select
		{
			get;
			internal set;
		}

		/// <summary>選択の解説。</summary>
		public string Description
		{
			get;
			internal set;
		}

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			string.Format(
				CultureInfo.CurrentCulture, @"{0} Desc:{1}", nameof(Selection), Description);

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() => Select.GetHashCode() ^ Description.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is Selection ? Equals((Selection)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(Selection others) =>
			Select == others.Select && Description == others.Description;

		/// <summary>
		/// データの一部、または全部を改変して複製します。
		/// </summary>
		/// <param name="select"></param>
		/// <param name="description"></param>
		/// <returns>新しい値。</returns>
		public Selection CopyTo(Action select = null, string description = null) =>
			new Selection()
			{
				Select = select ?? Select,
				Description = description ?? Description
			};
	}
}
