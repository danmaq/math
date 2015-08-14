using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using MC.Core.Utils;

namespace MC.Desktop
{
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	sealed partial class App : Application, IDisposable
	{
		/// <summary>
		/// ミューテックス管理クラス。
		/// </summary>
		private MutexManager mutex;

		/// <summary>
		/// デストラクタ。
		/// </summary>
		~App()
		{
			Dispose(disposing: false);
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(obj: this);
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージド リソースも解放するかどうか。</param>
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				ReleaseMutex();
			}
		}

		/// <summary>
		/// アプリケーションが開始された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		[SuppressMessage("Microsoft.Reliability", "CA2000:スコープを失う前にオブジェクトを破棄")]
		private void StartupHandler(object sender, StartupEventArgs e)
		{
			try
			{
				mutex = new MutexManager(id: GetType().FullName);
				new MainWindow().Show();
			}
			catch (InvalidOperationException)
			{
				MessageBox.Show(
					messageBoxText: MutexManager.ErrorMessage,
					caption: MainWindowData.Default.Title,
					button: MessageBoxButton.OK,
					icon: MessageBoxImage.Hand);
				Shutdown(exitCode: 1);
			}
		}

		/// <summary>
		/// アプリケーションが終了される際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ExitHandler(object sender, ExitEventArgs e) => ReleaseMutex();

		/// <summary>
		/// ミューテックスを解放します。
		/// </summary>
		private void ReleaseMutex()
		{
			if (mutex != null)
			{
				mutex.Dispose();
				mutex = null;
			}
		}
	}
}
