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
		/// <param name="mainWindow">メイン ウィンドウ。</param>
		/// <returns>インタラクティブなページ。</returns>
		public static IInteractivePage GetInteractive(this MainWindow mainWindow) =>
			(mainWindow?.Navigation.Content as IInteractivePage) ?? DummyPage.Instance;
	}
}
