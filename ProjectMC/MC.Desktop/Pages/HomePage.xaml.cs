using System;
using System.Windows;
using System.Windows.Controls;
using MC.Common.Utils;
using MC.Core.Data;
using MC.Core.Flow.Selections;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// HomePage.xaml の相互作用ロジック
	/// </summary>
	sealed partial class HomePage : Page, IInteractivePage
	{

		private static int index;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public HomePage()
		{
			var messages =
				new string[]
				{
					"こんにちは！ようこそ\"ますこれ\"へ！\nまだ試作版だけど楽しんでいってね！",
					"私の名前はピタゴラス。ほかにも\n24人の数学者たちが登場する(予定)よ！",
					"まだ試作版なので殆ど何もできないけど\n月に2～3回はアプデするよ！\n忘れたころに動かしてみてね。",
					"√2？割り切れるにきまってるじゃない。",
					"ネットに繋がっていれば、このアプリを\n動かすだけで勝手に最新版を\nダウンロードしてくれるよ。",
					"私の指先からあそこの隅まで2メートル。\n大抵のものは見ただけで\nどのくらい離れているかわかるの。",
					"私は今のバージョンでは\"おまけ\"だけど、\n後々ゲームを進めるにあたって\n重要なキャラクターになるよ。",
					"えっと……。何か聞きたいことある？\nソラマメ以外の話なら何でも聞くよ？",
					"ネットに繋がっていれば、このアプリを\n動かすだけで勝手に最新版を\nダウンロードしてくれるよ。",
					"私の前世は教祖のおっさんだったらしいよ。\n……え、あなたは輪廻とか信じない派？",
				};
			InitializeComponent();
			Balloon.Text = messages[index++ % messages.Length];

		}

		/// <summary>
		/// ユーザ入力の要求を設定します。
		/// </summary>
		public RequireResponseArgs RequireResponseArgs
		{
			set
			{
				Selection = value as RequireSelectArgs;
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
		/// 選択肢のためのコールバックを取得します。
		/// </summary>
		/// <param name="selection">選択肢。</param>
		/// <returns>コールバック。選択肢が存在しない場合、ダミーのコールバック。</returns>
		private Action GetSelect(HomeSelection selection) =>
			Selection?.Selections[(int)selection].Select ?? DelegateHelper.EmptyAction;

		/// <summary>
		/// 通学ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedSchoolButtonHandler(object sender, RoutedEventArgs e)
		{
			NavigationService.NavigateUri(Properties.Resources.PAGE_WORLD);
			GetSelect(HomeSelection.World)();
		}

		/// <summary>
		/// 設定ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedPreferenceButtonHandler(object sender, RoutedEventArgs e)
		{
			NavigationService.NavigateUri(Properties.Resources.PAGE_PREFERENCE);
			GetSelect(HomeSelection.Preference)();
		}
	}
}
