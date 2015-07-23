using System.Windows;
using System.Windows.Controls;
using MC.Common.Utils;
using MC.Core.Data;
using MC.Core.Flow.Selection;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// WorldPage.xaml の相互作用ロジック
	/// </summary>
	public partial class WorldPage : Page, IInteractivePage
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public WorldPage()
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
	}
}
