namespace MC.Console
{
	/// <summary>
	/// エントリ ポイント クラス。
	/// </summary>
	static class Program
	{
		/// <summary>
		/// エントリ ポイント。
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", MessageId = "System.Console.WriteLine(System.String)")]
		private static void Main()
		{
			System.Console.WriteLine(@"何かキーを押すと終了します");
			System.Console.Read();
		}
	}
}
