using System.Collections.Generic;
using MC.Common.Collection;

namespace MC.Core.Data
{

	/// <summary>
	/// 選択肢から選ぶことを要求するイベント データです。
	/// </summary>
	public sealed class RequireSelectArgs : RequireResponseArgs
	{

		/// <summary>
		/// 追加の解説文を取得します。
		/// </summary>
		public string AdditionalDesctiption
		{
			get;
			internal set;
		}
		= string.Empty;

		/// <summary>
		/// 選択肢を取得します。
		/// </summary>
		public IReadOnlyList<Selection> Selections
		{
			get;
			internal set;
		}

		/// <summary>
		/// 有効時間を取得します。
		/// </summary>
		public int Expires
		{
			get;
			internal set;
		}

		/// <summary>
		/// ToString() メソッドに使う、クラス名を取得します。
		/// </summary>
		protected override string ClassName
		{
			get;
		}
		= nameof(RequireSelectArgs);

		/// <summary>
		/// ToString() メソッドに使う、引数一覧を取得します。
		/// </summary>
		protected override IEnumerable<KeyValuePair<string, object>> Arguments =>
			new Dictionary<string, object>()
			{
				[nameof(Description)] = Description,
				[nameof(AdditionalDesctiption)] = AdditionalDesctiption,
				[nameof(Expires)] = Expires,
				[nameof(Selections)] = Selections.ToStringCollection(),
			};
	}
}
