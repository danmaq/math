using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// PracticePage.xaml の相互作用ロジック
	/// </summary>
	public partial class PracticePage : Page, IInteractivePage, IPageContainer
	{

		/// <summary>
		/// ページのナビゲーション サービスを取得します。
		/// </summary>
		public NavigationService Navigation => Overlap.NavigationService;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public PracticePage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ユーザ入力の要求を設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			set
			{
				this.GetInteractive().RequireResponseArgs = value;
			}
		}

		/// <summary>
		/// オーバーラップされるフレームが読み込まれた際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void LoadedOverlapFrameHandler(object sender, RoutedEventArgs e)
		{
			this.Navigate(Properties.Resources.PAGE_PRACTICE_COUNT);
        }
	}
}
