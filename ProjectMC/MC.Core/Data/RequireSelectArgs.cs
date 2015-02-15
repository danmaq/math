using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace MC.Core.Data
{

	/// <summary>
	/// 選択肢から選ぶことを要求するイベント データです。
	/// </summary>
	public sealed class RequireSelectArgs : RequireResponseArgs
	{

		/// <summary>選択肢を取得します。</summary>
		public ReadOnlyCollection<Selection> Selections
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
			string.Format(
				CultureInfo.CurrentCulture,
				@"{0}, Desc:{1}, Expires: {2} Selecton: {3}",
				nameof(RequireSelectArgs),
				Description,
				Expires,
				Selections.Aggregate(
					seed: string.Empty,
					func: (a, s) => string.Format(@"{0}, {1}", a, s.ToString())));
	}
}
