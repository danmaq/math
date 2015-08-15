using System.Windows;
using System.Windows.Controls;
using MC.Common.Utils;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// PreferencePage.xaml の相互作用ロジック
	/// </summary>
	public partial class PreferencePage : Page, IInteractivePage
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public PreferencePage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ユーザ入力の要求を設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			get;
			set;
		}

		/// <summary>
		/// 戻るボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedBackButtonHandler(object sender, RoutedEventArgs e)
		{
			var alert = RequireResponseArgs as RequireAlertArgs;
			NavigationService.GoBack();
			((RequireResponseArgs as RequireAlertArgs)?.Response ?? DelegateHelper.EmptyAction)();
		}
	}
}
