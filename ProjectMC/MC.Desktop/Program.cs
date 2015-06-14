using CocosSharp;

namespace MC
{
	/// <summary>
	/// エントリ ポイントのためのクラス。
	/// </summary>
	static class Program
	{

		/// <summary>
		/// エントリ ポイント。
		/// </summary>
		private static void Main()
		{
			var size = Misc.DefaultResolution;
			using (var app = new CCApplication(isFullScreen: false, mainWindowSizeInPixels: size))
			{
				app.ApplicationDelegate = new GameAppDelegate();
				app.StartGame();
			}
		}
	}
}
