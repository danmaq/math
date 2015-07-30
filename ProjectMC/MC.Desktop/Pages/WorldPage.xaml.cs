﻿using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// WorldPage.xaml の相互作用ロジック
	/// </summary>
	partial class WorldPage : Page, IInteractivePage
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
				DataContext =
					new
					{
						Selections =
							Selection
								.Selections
								.Skip(1),
						Back = new SelectionData(Selection.Selections.First()),
						BackEnabled = true,
					};
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

		/// <summary>
		/// 戻るボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedBackButtonHandler(object sender, RoutedEventArgs e)
		{
			MainWindow.Instance.Navigation.GoBack();
		}

		/// <summary>
		/// ダミーボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedDummyButtonHandler(object sender, RoutedEventArgs e)
		{
			MainWindow.Instance.Navigate(Properties.Resources.PAGE_AREA);
		}

		/// <summary>
		/// リストボックスの選択に変化が生じた際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ChangedListBoxSelectionHandler(object sender, SelectionChangedEventArgs e)
		{
			var listBox = sender as ListBox;
			if (listBox != null && e.AddedItems.Count > 0)
			{
				listBox.SelectedIndex = -1;
				e.AddedItems.Cast<Selection>().First().Select();
				MainWindow.Instance.Navigate(Properties.Resources.PAGE_AREA);
			}
		}
	}
}
