using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MC.Common.Utils;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// UserControl1.xaml の相互作用ロジック
	/// </summary>
	sealed partial class BackButton : UserControl
	{
		/// <summary>
		/// 依存プロパティの定義。
		/// </summary>
		private static readonly DependencyProperty commandProperty =
				DependencyProperty.Register(
					name: nameof(Command),
					propertyType: typeof(ICommand),
					ownerType: typeof(BackButton),
					typeMetadata:
						new UIPropertyMetadata(
							defaultValue: null,
							propertyChangedCallback:
								(d, e) =>
									((BackButton)d).Button.Command = (ICommand)(e.NewValue)));

		/// <summary>
		/// ボタンがクリックされた際に発生するイベント。
		/// </summary>
		public event RoutedEventHandler Click = (_, __) => DelegateHelper.EmptyAction();

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public BackButton()
		{
			InitializeComponent();
		}

		/// <summary>
		/// ボタンが押下されたときに発信するコマンドを取得、または設定します。
		/// </summary>
		public ICommand Command
		{
			get
			{
				return (ICommand)GetValue(commandProperty);
			}
			set
			{
				SetValue(dp: commandProperty, value: value);
			}
		}

		/// <summary>
		/// ボタンが押下された際に呼び出されます。
		/// </summary>
		/// <param name="sender">送信元。</param>
		/// <param name="e">イベント情報。</param>
		private void ClickedButtonHandler(object sender, RoutedEventArgs e)
		{
			Click(sender: this, e: e);
		}
	}
}
