using System.Windows.Navigation;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// ページ コンテナに必要な定義。
	/// </summary>
	interface IPageContainer
	{

		/// <summary>
		/// ページのナビゲーション サービスを取得します。
		/// </summary>
		NavigationService Navigation
		{
			get;
		}
    }
}
