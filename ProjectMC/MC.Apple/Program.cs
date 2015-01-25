using MonoTouch.UIKit;

namespace MC
{
	/// <summary>
	/// エントリ ポイントのためのクラス。
	/// </summary>
	public class Application
	{
		/// <summary>
		/// This is the main entry point of the application.
		/// </summary>
		/// <param name="args">コマンド ライン引数。</param>
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(
				args: args, principalClassName: null, delegateClassName: @"AppDelegate");
		}
	}
}

