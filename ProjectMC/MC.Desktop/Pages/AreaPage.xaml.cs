using System.Windows;
using System.Windows.Controls;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
    /// <summary>
    /// AreaPage.xaml の相互作用ロジック
    /// </summary>
    public partial class AreaPage : Page
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public AreaPage()
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

        }
    }
}
