using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MC.Desktop
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			var asm = Assembly.GetExecutingAssembly();
			Icon = BitmapFrame.Create(asm.GetManifestResourceStream("MC.Desktop.MC_1.ico"));
		}

		private void ClickedCloseButton(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ClickedMinimizeButton(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void ClickedMaximizeButton(object sender, RoutedEventArgs e)
		{
			var max = WindowState == WindowState.Maximized;
			((Button)sender).Content = max ? "1" : "2";
			WindowState = max ? WindowState.Normal : WindowState.Maximized;
		}
	}
}
