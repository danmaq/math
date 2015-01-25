using Android.App;
using Android.Content.PM;
using Android.OS;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace MC
{
	/// <summary>
	/// �G���g�� �|�C���g�̂��߂̃N���X�B
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
		/// �����I�ȃG���g�� �|�C���g�B
		/// �A�N�e�B�r�e�B���������ꂽ�ۂɌĂяo����܂��B
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
