using System;
using System.Windows.Navigation;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// ページ操作のヘルパ クラス。
	/// </summary>
	static class PageHelper
	{
		/// <summary>
		/// ダミー ページ。
		/// </summary>
		private sealed class DummyPage : IInteractivePage
		{

			/// <summary>
			/// コンストラクタ。
			/// </summary>
			private DummyPage()
			{
			}

			/// <summary>
			/// シングルトン オブジェクト。
			/// </summary>
			public static IInteractivePage Instance
			{
				get;
			}
			= new DummyPage();

			/// <summary>
			/// ユーザ入力の要求を設定します。
			/// </summary>
			public RequireResponseArgs RequireResponseArgs
			{
				set
				{
				}
			}
		}

		/// <summary>
		/// インタラクティブなページを取得します。
		/// </summary>
		/// <param name="pageContainer">ページ コンテナ。</param>
		/// <returns>インタラクティブなページ。</returns>
		public static IInteractivePage GetInteractive(this IPageContainer pageContainer) =>
			(pageContainer?.Navigation.Content as IInteractivePage) ?? DummyPage.Instance;

		/// <summary>
		/// ページ遷移を行います。
		/// </summary>
		/// <param name="pageContainer">ページ コンテナ。</param>
		/// <param name="path">XAML へのパス。</param>
		public static void NavigateUri(this IPageContainer pageContainer, string path) =>
			pageContainer.Navigation.NavigateUri(path);

		/// <summary>
		/// ページ遷移を行います。
		/// </summary>
		/// <param name="navigation">ナビゲーション サービス。</param>
		/// <param name="path">XAML へのパス。</param>
		public static void NavigateUri(this NavigationService navigation, string path) =>
			navigation.Navigate(new Uri(uriString: path, uriKind: UriKind.Relative));
	}
}
