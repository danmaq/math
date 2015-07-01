using System;
using MC.Common.Collection;
using MC.Core.Data;
using MC.Core.Flow;
using MC.Properties;

namespace MC
{
	/// <summary>
	/// エントリ ポイントのためのクラス。
	/// </summary>
	static class Program
	{
		/// <summary>
		/// プロンプト管理クラスを取得します。
		/// </summary>
		static PromptManager PromptManager
		{
			get;
		}
		= new PromptManager();

		/// <summary>
		/// エントリ ポイント。
		/// </summary>
		private static void Main()
		{
			Console.WriteLine(Settings.Default.Storage);

			Console.WriteLine(Resources.MESSAGE_LOADING);
			using (var flow = new GameFlow())
			{
				flow.RequireResponse += OnPrompt;
				var enumerable = flow.Run();
				enumerable.ForEach(_ => PromptManager.KeyManager.PeekInput());
			}
			Console.WriteLine(Resources.MESSAGE_EXITED);
			KeyManager.Enter();
		}

		/// <summary>
		/// 入力を要求された際に呼び出されます。
		/// </summary>
		/// <param name="sender">呼び出し元。</param>
		/// <param name="args">イベント情報。</param>
		private static void OnPrompt(object sender, RequireResponseArgs args) =>
			PromptManager.Prompt(args);
	}
}
