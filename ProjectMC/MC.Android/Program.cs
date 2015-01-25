using Android.App;
using Android.Content.PM;
using Android.OS;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace MC
{
	/// <summary>
	/// エントリ ポイントのためのクラス。
	/// </summary>
	[Activity(
		Label = "Project MC",
		MainLauncher = true,
		Icon = "@drawable/icon",
		Theme = "@style/Theme.Splash",
		AlwaysRetainTaskState = true,
		LaunchMode = LaunchMode.SingleInstance,
		ScreenOrientation = ScreenOrientation.Landscape,
		ConfigurationChanges =
			ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
	public class Program : AndroidGameActivity
	{
		/// <summary>
		/// 実質的なエントリ ポイント。
		/// アクティビティが生成された際に呼び出されます。
		/// </summary>
		/// <param name="bundle"></param>
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			var application = new CCApplication();

			// GameAppDelegate is your class that inherits 
			// from CCApplicationDelegate
			application.ApplicationDelegate = new GameAppDelegate();
			SetContentView(application.AndroidContentView);
			application.StartGame();
		}
	}
}
