using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MC.Core.Data;
using MC.Desktop.Pages.Practice;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// PracticeResult.xaml の相互作用ロジック
	/// </summary>
	public partial class PracticeResultPage : Page
	{
		/// <summary>プロンプト。</summary>
		private RequireAlertArgs requireAlertArgs;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="prompt">プロンプト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public PracticeResultPage(RequireAlertArgs prompt)
		{
			if (prompt == null)
			{
				throw new ArgumentNullException(nameof(prompt));
			}
			InitializeComponent();
			requireAlertArgs = prompt;
			var practiceData = prompt?.AdditionalData as PracticeData;
			DataContext =
				new ResultBindingData()
				{
					Length = practiceData.Length,
					Correct = practiceData.CorrectCount,
					Passed = practiceData.Passed,
					SubjectMasterData = practiceData.SubjectMasterData,
				};
        }

		/// <summary>
		/// 確認ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedDoneButton(object sender, RoutedEventArgs e)
		{
			requireAlertArgs.Response();
			NavigationService.RemoveBackEntry();
			NavigationService.GoBack();
		}
	}
}
