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
			Title = asm.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
			Version.Content = Miscs.Format($"{Title} バージョン {asm.GetName().Version}");
		}

		/// <summary>
		/// 閉じるボタン押下時に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedCloseButton(object sender, RoutedEventArgs e) => Close();

		/// <summary>
		/// 最小化ボタン押下時に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedMinimizeButton(object sender, RoutedEventArgs e) =>
			WindowState = WindowState.Minimized;

		/// <summary>
		/// 最大化・復元ボタン押下時に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedMaximizeButton(object sender, RoutedEventArgs e)
		{
			var max = WindowState == WindowState.Maximized;
			((Button)sender).Content = max ? "1" : "2";
			WindowState = max ? WindowState.Normal : WindowState.Maximized;
		}
	}
}
