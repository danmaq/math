using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// WaitPage.xaml の相互作用ロジック
	/// </summary>
	public partial class WaitPage : Page, IInteractivePage
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public WaitPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ユーザ入力の要求を取得、設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			set
			{
				if (value is RequireAlertArgs)
				{
					NavigationService.Navigate(new SingleResultPage((RequireAlertArgs)value));
				}
			}
		}
	}
}
