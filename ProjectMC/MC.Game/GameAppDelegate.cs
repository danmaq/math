using System.Diagnostics;
using CocosDenshion;
using CocosSharp;

namespace MC
{
	public class GameAppDelegate : CCApplicationDelegate
	{
		public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
		{
			application.PreferMultiSampling = false;
			application.ContentRootDirectory = "Content";
			Debug.WriteLine(@"Started Game of MC!!");
			CCLog.Log(@"Started Game of MC123!!");
			// todo:  Add our GameScene initialization here
		}

		public override void ApplicationDidEnterBackground(CCApplication application)
		{
			application.Paused = true;
			CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic();
		}

		public override void ApplicationWillEnterForeground(CCApplication application)
		{
			application.Paused = false;
			CCSimpleAudioEngine.SharedEngine.ResumeBackgroundMusic();
		}
	}
}
