﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
			/// 正解かどうかを取得、または設定します。
			/// </summary>
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			public bool Correct
			{
				get;
				set;
			}

			/// <summary>
			/// 正解を取得、または設定します。
			/// </summary>
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			public string Answer
			{
				get;
				set;
			}
			= @"越後製菓";

			/// <summary>
			/// 結果を取得します。
			/// </summary>
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			public string Result =>
				string.Format(
					CultureInfo.CurrentUICulture,
					@"{0} 正解は: {1}",
					Correct ? @"○" : @"×",
					Answer);
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
			var correct =
				Convert.ToBoolean(value: prompt.Caption, provider: CultureInfo.InvariantCulture);
            DataContext =
				new BindingData()
				{
					Correct = correct,
					Answer = prompt.Desctiption,
				};
			Action callback =
				() =>
				{
					prompt.Response();
					NavigationService.Navigate(new Page());
				};
			var delay = TimeSpan.FromMilliseconds(1000);
            PageHelper.DelayCallUsingDispatcherTimer(callback, delay);
		}
	}
}
