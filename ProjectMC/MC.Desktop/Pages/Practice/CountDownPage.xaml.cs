using System.Diagnostics;
using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// CountDownPage.xaml の相互作用ロジック
	/// </summary>
	public partial class CountDownPage : Page, IInteractivePage
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public CountDownPage()
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
				Debug.WriteLine(value);
			}
		}
	}
}
