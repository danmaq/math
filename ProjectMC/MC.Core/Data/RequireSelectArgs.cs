﻿using System.Collections.Generic;
using MC.Common.Collection;

namespace MC.Core.Data
{

	/// <summary>
	/// 選択肢から選ぶことを要求するイベント データです。
	/// </summary>
	public sealed class RequireSelectArgs : RequireResponseArgs
	{

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
				[nameof(Caption)] = Caption,
				[nameof(Desctiption)] = Desctiption,
				[nameof(Expires)] = Expires,
				[nameof(Selections)] = Selections.ToStringCollection(),
			};
	}
}
