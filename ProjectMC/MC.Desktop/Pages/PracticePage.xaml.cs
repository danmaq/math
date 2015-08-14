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
		/// <summary>選択肢データ。</summary>
		private RequireSelectArgs requireSelectArgs;

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

		/// <summary>
		/// 選択肢データを取得、または設定します。
		/// </summary>
		private RequireSelectArgs RequireSelectArgs
		{
			get
			{
				return requireSelectArgs;
			}
			set
			{
				requireSelectArgs = value;
                if (value != null && value.Selections.Count >= 4)
				{
					ApplySelectionData(allowInteractive: true);
				}
			}
		}

		/// <summary>
		/// 強制的に選択します。
		/// </summary>
		/// <param name="index">選択番号。</param>
		public void Select(int index)
		{
			RequireSelectArgs.Selections[index].Select();
			ApplySelectionData(allowInteractive: false);
			this.NavigateUri(Properties.Resources.PAGE_PRACTICE_WAIT);
		}

		/// <summary>
		/// 選択肢データを表示に適用します。
		/// </summary>
		private void ApplySelectionData(bool allowInteractive)
		{
			var value = requireSelectArgs;
			DataContext =
				new PracticeBindingData()
				{
					Caption = value.Caption,
					Description = value.Desctiption,
					Number = 1,
					Interactive = allowInteractive,
					Answer1 = value.Selections[0].Caption,
					Answer2 = value.Selections[1].Caption,
					Answer3 = value.Selections[2].Caption,
					Answer4 = value.Selections[3].Caption,
				};
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

		/// <summary>
		/// 回答ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedAnser1ButtonHandler(object sender, RoutedEventArgs e) => Select(0);

		/// <summary>
		/// 回答ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedAnser2ButtonHandler(object sender, RoutedEventArgs e) => Select(1);

		/// <summary>
		/// 回答ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedAnser3ButtonHandler(object sender, RoutedEventArgs e) => Select(2);

		/// <summary>
		/// 回答ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedAnser4ButtonHandler(object sender, RoutedEventArgs e) => Select(3);
	}
}
