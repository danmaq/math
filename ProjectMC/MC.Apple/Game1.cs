using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CocosSharp;
using System.Diagnostics;

namespace MC.Apple
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		private readonly GraphicsDeviceManager graphics;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
			graphics.IsFullScreen = false;

			// Frame rate is 30 fps by default for Windows Phone.
			TargetElapsedTime = TimeSpan.FromTicks(333333 / 2);
			Debug.WriteLine("Started Game");
			// Extend battery life under lock.
			//InactiveSleepTime = TimeSpan.FromSeconds(1);
		}


		protected override void Update(GameTime gameTime)
		{

			// TODO: Add your update logic here
			base.Update(gameTime);
		}
	}
}