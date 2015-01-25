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
			using (
				var app =
					new CCApplication(
						isFullScreen: false, mainWindowSizeInPixels: new CCSize(1366f, 768f)))
			{
				app.ApplicationDelegate = new GameAppDelegate();
				app.StartGame();
			}
		}
	}
}
