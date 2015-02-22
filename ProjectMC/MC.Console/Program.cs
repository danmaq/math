using System;
using MC.Common.Collection;
using MC.Core;
using MC.Core.Data;
using MC.Input;
using MC.Properties;
using BDD;
using System.Linq;

namespace MC
{
	/// <summary>
	/// エントリ ポイントのためのクラス。
	/// </summary>
	static class Program
	{

		/// <summary>入力管理オブジェクトを取得します。</summary>
		private static KeyManager KeyManager
		{
			get;
		}
		= new KeyManager();

		/// <summary>
		/// エントリ ポイント。
		/// </summary>
		private static void Main()
		{
			Console.WriteLine(Resources.MESSAGE_START);
			var xx = from x in Enumerable.Range(1, 10)
					select x;
			/*
			using (var flow = new GameFlow())
			{
				flow.RequireResponse += OnPrompt;
				var enumerable = flow.Run();
				enumerable.ForEach(_ => KeyManager.PeekInput());
			}
			*/
			Console.WriteLine(Resources.MESSAGE_EXITED);
			Console.Read();
		}

		/// <summary>
		/// 入力を要求された際に呼び出されます。
		/// </summary>
		/// <param name="sender">呼び出し元。</param>
		/// <param name="args">イベント情報。</param>
		private static void OnPrompt(object sender, RequireResponseArgs args)
		{
			Console.WriteLine(args.Description);
			var select = args as RequireSelectArgs;
			if (select == null)
			{
				KeyManager.Prompt(null);
				var text = args as RequireTextArgs;
				if (text != null)
				{
					text.Response(KeyManager.Inputed);
				}
			}
			else
			{
				KeyManager.Prompt(select.Selections);
			}
		}
	}
}
