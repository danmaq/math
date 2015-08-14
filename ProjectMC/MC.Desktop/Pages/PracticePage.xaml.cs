using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MC.Core.Data;
using MC.Desktop.Pages.Practice;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// PracticePage.xaml の相互作用ロジック
	/// </summary>
	sealed partial class PracticePage : Page, IInteractivePage, IPageContainer
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
			DataContext = new PracticeBindingData();
		}

		/// <summary>
		/// ユーザ入力の要求を設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			set
			{
				this.GetInteractive().RequireResponseArgs = value;
				RequireSelectArgs = value as RequireSelectArgs;
            }
		}

		private RequireSelectArgs RequireSelectArgs
		{
			set
			{
				if (value != null && value.Selections.Count >= 4)
				{
					DataContext = null;
					DataContext =
						new PracticeBindingData()
						{
							Caption = value.Description,
							Description = value.AdditionalDesctiption,
							Number = 1,
							Answer1 = value.Selections[0].Caption,
							Answer2 = value.Selections[1].Caption,
							Answer3 = value.Selections[2].Caption,
							Answer4 = value.Selections[3].Caption,
						};
					Debug.WriteLine(value);
				}
			}
		}

		/// <summary>
		/// オーバーラップされるフレームが読み込まれた際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void LoadedOverlapFrameHandler(object sender, RoutedEventArgs e)
		{
			this.NavigateUri(Properties.Resources.PAGE_PRACTICE_COUNT);
        }
	}
}
