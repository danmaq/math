using CocosSharp;

namespace MC
{
	static class Program
	{

		private static void Main()
		{
			var app = new CCApplication(false, new CCSize(1024f, 768f));
			app.ApplicationDelegate = new GameAppDelegate();
			app.StartGame();
		}
	}
}
