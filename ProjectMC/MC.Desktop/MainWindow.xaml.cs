﻿using System;
using System.Collections;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Desktop.Pages;

namespace MC.Desktop
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	partial class MainWindow : Window, IDisposable
	{

		/// <summary>ゲームフロー管理オブジェクト。</summary>
		private GameFlow gameFlow;

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
		/// ゲームフロー管理オブジェクトを取得します。
		/// </summary>
		public IGameFlow GameFlow => gameFlow;

		/// <summary>
		/// ページのナビゲーション サービスを取得します。
		/// </summary>
		public NavigationService Navigation => Frame.NavigationService;

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
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(obj: this);
		}

		/// <summary>
		/// ページ遷移を行います。
		/// </summary>
		/// <param name="path">XAML へのパス。</param>
		public void Navigate(string path) =>
			Navigation.Navigate(new Uri(uriString: path, uriKind: UriKind.Relative));

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージド リソースも解放するかどうか。</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				ReleaseGameFlow();
            }
		}

		/// <summary>
		/// ゲームフローを解放します。
		/// </summary>
		private void ReleaseGameFlow()
		{
			if (gameFlow != null)
			{
				gameFlow.Dispose();
				gameFlow = null;
			}
		}

		/// <summary>
		/// ゲームループ用のイベント ハンドラを作成します。
		/// </summary>
		/// <param name="flowEnumerable">ゲーム ループ用のコルーチン。</param>
		/// <returns>ゲームループ用のイベント ハンドラ。</returns>
		private EventHandler CreateGameLoopHandler(IEnumerable flowEnumerable)
		{
			var enumerator = flowEnumerable.GetEnumerator();
			return
				(_, __) =>
				{
					if (!enumerator.MoveNext())
					{
						Close();
					}
                };
		}

		/// <summary>
		/// メイン フレームの準備が完了した際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void FrameLoadedHandler(object sender, RoutedEventArgs e)
		{
			Navigate(Properties.Resources.PAGE_LOGO);
			gameFlow = new GameFlow();
			gameFlow.RequireResponse += GameRequireResponseHandler;
			CompositionTarget.Rendering += CreateGameLoopHandler(gameFlow.Run());
		}

		/// <summary>
		/// ゲームループからユーザ入力の要求を受けた際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void GameRequireResponseHandler(object sender, RequireResponseArgs e)
		{
			this.GetInteractive().RequireResponseArgs = e;
		}

		/// <summary>
		/// ウィンドウが閉じられた際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClosedWindowHandler(object sender, EventArgs e)
		{
			ReleaseGameFlow();
            Instance = null;
		}

		/// <summary>
		/// 画面のサイズ状態が変化した際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ChangedWindowStateHandler(object sender, EventArgs e)
		{
			DataContext = CurrentData.CopyTo(maximizeCaption: Maximized ? "2" : "1");
			ChangedActivateHandler(sender, e);
        }

		/// <summary>
		/// 画面がアクティブかどうか、状態が変化した際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ChangedActivateHandler(object sender, EventArgs e) =>
			Topmost = Maximized && IsActive;

		/// <summary>
		/// 閉じるボタン押下時に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedCloseButtonHandler(object sender, RoutedEventArgs e) => Close();

		/// <summary>
		/// 最小化ボタン押下時に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedMinimizeButtonHandler(object sender, RoutedEventArgs e) =>
			WindowState = WindowState.Minimized;

		/// <summary>
		/// 最大化・復元ボタン押下時に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedMaximizeButtonHandler(object sender, RoutedEventArgs e) =>
			WindowState = Maximized ? WindowState.Normal : WindowState.Maximized;
	}
}
