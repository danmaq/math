using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// PracticePage.xaml の相互作用ロジック
	/// </summary>
	public partial class PracticePage : Page, IInteractivePage
	{

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
				// TODO: ここから
			}
		}
	}
}
