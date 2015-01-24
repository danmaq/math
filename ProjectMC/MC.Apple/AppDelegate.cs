using CocosSharp;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MC
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public override void FinishedLaunching(UIApplication app)
		{
			var application = new CCApplication();
			application.ApplicationDelegate = new GameAppDelegate();
			application.StartGame();
		}
	}
}
