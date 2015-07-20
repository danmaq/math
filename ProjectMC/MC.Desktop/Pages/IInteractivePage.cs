using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// インタラクティブなページに必要な定義。
	/// </summary>
	interface IInteractivePage
	{
		/// <summary>
		/// ユーザ入力の要求を設定します。
		/// </summary>
		RequireResponseArgs RequireResponseArgs
		{
			set;
		}
    }
}
