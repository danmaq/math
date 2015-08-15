using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// LogoPage.xaml の相互作用ロジック
	/// </summary>
	public partial class LogoPage : Page
	{
		/// <summary>プロンプト。</summary>
		private RequireAlertArgs requireAlertArgs;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="prompt">プロンプト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public LogoPage(RequireAlertArgs prompt)
		{
			if (prompt == null)
			{
				throw new ArgumentNullException(nameof(prompt));
			}
			InitializeComponent();
			requireAlertArgs = prompt;
        }

		/// <summary>
		/// ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedStartButtonHandler(object sender, RoutedEventArgs e)
		{
			NavigationService.NavigateUri(Properties.Resources.PAGE_HOME);
			requireAlertArgs.Response();
        }
	}
}
