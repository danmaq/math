using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Threading;
using MC.Common.Data;
using MC.Common.Utils;
using MC.Core.Data;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// CountDownPage.xaml の相互作用ロジック
	/// </summary>
	sealed partial class CountDownPage : Page, IInteractivePage
	{
		/// <summary>
		/// バインドされるデータ。
		/// </summary>
		private class BindingData
		{
			/// <summary>
			/// カウントダウンを取得、および設定します。
			/// </summary>
			public int CountDownValue
			{
				get;
				set;
			}
			= Constants.PreCountDown;

			/// <summary>
			/// カウントダウン文字列を取得します。
			/// </summary>
			public string CountDown => CountDownValue.ToString(CultureInfo.CurrentUICulture);
		}

		/// <summary>タイマー。</summary>
		private readonly DispatcherTimer dispatcherTimer = new DispatcherTimer();

		/// <summary>バインドされるデータ。</summary>
		private readonly BindingData data = new BindingData();

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public CountDownPage()
		{
			InitializeComponent();
			dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
			dispatcherTimer.Tick += TickTimerHandler;
			dispatcherTimer.Start();
			DataContext = data;
        }

		/// <summary>
		/// ユーザ入力の要求を取得、設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			set
			{
				((value as RequireAlertArgs)?.Response ?? DelegateHelper.EmptyAction)();
				dispatcherTimer.Stop();
				NavigationService.Navigate(new Page());
            }
		}

		/// <summary>
		/// タイマによって毎秒呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void TickTimerHandler(object sender, EventArgs e)
		{
			data.CountDownValue = Math.Max(0, data.CountDownValue - 1);
			DataContext = null;
			DataContext = data;
		}
	}
}
