using System;
using System.Windows;
using System.Windows.Navigation;

namespace MC.Desktop
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	partial class MainWindow : Window
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public MainWindow()
		{
			Instance = this;
			InitializeComponent();
			DataContext = CurrentData;
        }

		/// <summary>
		/// シングルトン オブジェクト。
		/// ウィンドウが開かれている間のみ有効です。
		/// </summary>
		public static MainWindow Instance
		{
			get;
			private set;
		}

		/// <summary>
		/// 既定のデータを取得します。
		/// </summary>
		private MainWindowData CurrentData =>
			DataContext as MainWindowData ?? MainWindowData.Default;

		/// <summary>
		/// 画面が最大化されているかどうかを取得します。
		/// </summary>
		private bool Maximized => WindowState == WindowState.Maximized;

		/// <summary>
		/// ページのナビゲーション サービスを取得します。
		/// </summary>
		private NavigationService Navigation => Frame.NavigationService;

		/// <summary>
		/// 画面状態が変化した際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void Window_StateChanged(object sender, EventArgs e) =>
			DataContext = CurrentData.CopyTo(maximizeCaption: Maximized ? "2" : "1");

		/// <summary>
		/// メイン フレームの準備が完了した際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void Frame_Loaded(object sender, RoutedEventArgs e) =>
			Navigation.Navigate(
				new Uri(uriString: @"Pages/LogoPage.xaml", uriKind: UriKind.Relative));

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
		/// ウィンドウが閉じられた際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void Window_Closed(object sender, EventArgs e) => Instance = null;
	}
}
