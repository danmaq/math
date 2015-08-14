using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using MC.Core.Data;

namespace MC.Desktop.Pages.Practice
{
	/// <summary>
	/// SingleResultPage.xaml の相互作用ロジック
	/// </summary>
	public partial class SingleResultPage : Page
	{
		/// <summary>
		/// バインドされるデータ。
		/// </summary>
		private class BindingData
		{
			/// <summary>
			/// 正解かどうかを取得、および設定します。
			/// </summary>
			public bool Confirm
			{
				get;
				set;
			}

			/// <summary>
			/// 結果を取得します。
			/// </summary>
			public string Result => Confirm ? @"○" : @"×";
		}

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="prompt">プロンプト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public SingleResultPage(RequireAlertArgs prompt)
		{
			InitializeComponent();
			if (prompt == null)
			{
				throw new ArgumentNullException(nameof(prompt));
			}
			DataContext = new BindingData() { Confirm = Convert.ToBoolean(prompt.Description) };
			Action callback =
				() =>
				{
					prompt.Response();
					NavigationService.Navigate(new Page());
				};
			PageHelper.DelayCallUsingDispatcherTimer(callback, TimeSpan.FromMilliseconds(1000));
		}
	}
}
