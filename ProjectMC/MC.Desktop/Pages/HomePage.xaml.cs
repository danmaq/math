using System.Diagnostics;
using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// HomePage.xaml の相互作用ロジック
	/// </summary>
	public partial class HomePage : Page, IInteractivePage
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public HomePage()
		{
			InitializeComponent();
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
		/// ユーザ入力の要求を設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			set
			{
				Debug.WriteLine(MainWindow.Instance.Navigation.Content);
				Selection = value as RequireSelectArgs;
			}
		}
	}
}
