﻿using CocosSharp;

namespace MC
{
	/// <summary>
	/// The main class.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			CCApplication.Create(new GameAppDelegate());
		}
	}
}
