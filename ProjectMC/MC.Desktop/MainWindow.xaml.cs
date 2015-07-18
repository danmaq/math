using System.Reflection;
using System.Windows;
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
		/// 画面が最大化されているかどうかを取得します。
		/// </summary>
		private bool Maximized => WindowState == WindowState.Maximized;

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
		private void ClickedMaximizeButton(object sender, RoutedEventArgs e) =>
			WindowState = Maximized ? WindowState.Normal : WindowState.Maximized;

		/// <summary>
		/// 画面状態が変化した際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void Window_StateChanged(object sender, System.EventArgs e) =>
			MaximizeButton.Content = Maximized ? "2" : "1";
	}
}
