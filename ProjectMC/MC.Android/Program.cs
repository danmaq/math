
using Android.App;
using Android.Content.PM;
using Android.OS;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace MC
{

	[Activity(Label = "MC.Android"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, AlwaysRetainTaskState = true
		, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
		, ScreenOrientation = ScreenOrientation.Landscape
		, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
	public class Program : AndroidGameActivity
	{
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

