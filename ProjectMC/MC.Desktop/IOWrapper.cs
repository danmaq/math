using System;
using System.IO;
using MC.Common.Data.IO;

namespace MC.Desktop
{
	/// <summary>
	/// Windows デスクトップ専用の IO ラッパー。
	/// </summary>
	sealed class IOWrapper : IIOWrapper
	{
		/// <summary>パス。</summary>
		private readonly string target = GetFilePath();

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static IIOWrapper Instance
		{
			get;
		}
		= new IOWrapper();

		/// <summary>
		/// 読み込み専用ストリームを取得します。
		/// 呼び出し側が Dispose の責任を負ってください。
		/// </summary>
		public Stream ReadStream => new FileStream(path: target, mode: FileMode.OpenOrCreate);

		/// <summary>
		/// 書き込み専用ストリームを取得します。
		/// 呼び出し側が Dispose の責任を負ってください。
		/// </summary>
		public Stream WriteStream => new FileStream(path: target, mode: FileMode.Create);

		private static string GetFilePath()
		{
			var roaming =
				Environment.GetFolderPath(
					folder: Environment.SpecialFolder.ApplicationData,
					option: Environment.SpecialFolderOption.Create);
			var target =
				Path.Combine(path1: roaming, path2: @"danmaq", path3: @"MC", path4: @"data.xml");
			Directory.CreateDirectory(Path.GetDirectoryName(target));
			return target;
        }
	}
}
