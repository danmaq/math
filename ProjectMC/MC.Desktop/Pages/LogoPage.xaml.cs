using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// LogoPage.xaml の相互作用ロジック
	/// </summary>
	partial class LogoPage : Page, IInteractivePage
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public LogoPage()
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
				var alert = value as RequireAlertArgs;
				if (alert != null)
				{
					MainWindow.Instance.Navigate(Properties.Resources.PAGE_HOME);
					alert.Response();
				}
			}
		}
	}
}
