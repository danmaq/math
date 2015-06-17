using System;
using System.Diagnostics;
using CocosDenshion;
using CocosSharp;

namespace MC
{
	/// <summary>
	/// 実質ゲームのメインとなるクラス。
	/// </summary>
	sealed class GameAppDelegate : CCApplicationDelegate
	{
		/// <summary>
		/// 起動完了直後に呼び出されます。
		/// </summary>
		/// <param name="application">Cocos2D アプリケーション管理用オブジェクト。</param>
		/// <param name="mainWindow">Cocos2D ウィンドウ管理用オブジェクト。</param>
		/// <exception cref="System.ArgumentNullException">引数が null である場合。</exception>
		public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
		{
			base.ApplicationDidFinishLaunching(application, mainWindow);
			if (application == null)
			{
				throw new ArgumentNullException(nameof(application));
			}
			if (mainWindow == null)
			{
				throw new ArgumentNullException(nameof(mainWindow));
			}
			try
			{
				application.PreferMultiSampling = false;
				application.ContentRootDirectory = @"Content";

				var windowSize = mainWindow.WindowSizeInPixels;

				CCScene.SetDefaultDesignResolution(
					width: windowSize.Width,
					height: windowSize.Height,
					resPolicy: CCSceneResolutionPolicy.ExactFit);

				var scene = new CCScene(window: mainWindow);

				var layer = new ExampleLayer();
				scene.AddChild(child: layer);
				mainWindow.RunWithScene(scene: scene);
				// todo:  Add our GameScene initialization here
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		/// <summary>
		/// バックグラウンドに移行された直後に呼び出されます。
		/// </summary>
		/// <param name="application">Cocos2D アプリケーション管理用オブジェクト。</param>
		/// <exception cref="System.ArgumentNullException">引数が null である場合。</exception>
		public override void ApplicationDidEnterBackground(CCApplication application)
		{
			base.ApplicationDidEnterBackground(application);
			if (application == null)
			{
				throw new ArgumentNullException(nameof(application));
			}
			application.Paused = true;
			CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic();
		}

		/// <summary>
		/// バックグラウンドから復帰される直前に呼び出されます。
		/// </summary>
		/// <param name="application">Cocos2D アプリケーション管理用オブジェクト。</param>
		/// <exception cref="System.ArgumentNullException">引数が null である場合。</exception>
		public override void ApplicationWillEnterForeground(CCApplication application)
		{
			base.ApplicationWillEnterForeground(application);
			if (application == null)
			{
				throw new ArgumentNullException(nameof(application));
			}
			application.Paused = false;
			CCSimpleAudioEngine.SharedEngine.ResumeBackgroundMusic();
		}
	}
}
