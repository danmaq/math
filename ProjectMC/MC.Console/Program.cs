using System;

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
			Console.WriteLine(@"何かキーを押すと終了します");
			Console.Read();
		}
	}
}
