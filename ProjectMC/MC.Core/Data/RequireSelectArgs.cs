using System.Collections.Generic;
using MC.Common.Collection;
using MC.Common.Utils;

namespace MC.Core.Data
{

	/// <summary>
	/// 選択肢から選ぶことを要求するイベント データです。
	/// </summary>
	public sealed class RequireSelectArgs : RequireResponseArgs
	{

		/// <summary>選択肢を取得します。</summary>
		public IReadOnlyList<Selection> Selections
		{
			get;
			internal set;
		}

		/// <summary>有効時間を取得します。</summary>
		public int Expires
		{
			get;
			internal set;
		}

		/// <summary>
		/// 文字列情報を取得します。
		/// </summary>
		/// <returns>文字列情報。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(RequireSelectArgs)} Description:{Description} Expires: {Description} Selecton: {Selections.ToStringCollection()}");
    }
}
