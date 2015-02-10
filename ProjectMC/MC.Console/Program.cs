using System;
using MC.Core;
using MC.Common.Collection.EnumerableExtension;

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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", MessageId = "System.Console.WriteLine(System.String)")]
		private static void Main()
		{
			using (var flow = new GameFlow())
			{
				flow.RequireResponse += (sender, e) => Console.WriteLine(e);
				var enumerable = flow.Run();
				enumerable.ForEach();
			}
			Console.WriteLine(@"何かキーを押すと終了します");
			Console.Read();
		}

		/// <summary>選択された番号。</summary>
		static int select;

		private static void KeyInput()
		{
			if (Console.KeyAvailable)
			{
				var c = Convert.ToChar(Console.Read()).ToString();
				int.TryParse(s: c, result: out select);
			}
		}
	}
}
