using System.Windows;
using MC.Core.Utils;

namespace MC.Desktop
{
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	partial class App : Application
	{
		/// <summary>
		/// ミューテックス管理クラス。
		/// </summary>
		private MutexManager Mutex;
	}
}
