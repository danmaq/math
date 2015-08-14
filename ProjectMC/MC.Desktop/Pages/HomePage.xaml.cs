using System.Windows;
using System.Windows.Controls;
using MC.Common.Utils;
using MC.Core.Data;
using MC.Core.Flow.Selections;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// HomePage.xaml の相互作用ロジック
	/// </summary>
	sealed partial class HomePage : Page, IInteractivePage
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public HomePage()
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
				Selection = value as RequireSelectArgs;
			}
		}

		/// <summary>
		/// ユーザ入力の要求を取得、設定します。
		/// </summary>
		private RequireSelectArgs Selection
		{
			get;
			set;
		}

		/// <summary>
		/// 通学ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedSchoolButtonHandler(object sender, RoutedEventArgs e)
		{
			NavigationService.NavigateUri(Properties.Resources.PAGE_WORLD);
			(Selection?.Selections[(int)HomeSelection.World].Select ?? DelegateHelper.EmptyAction)();
		}
	}
}
