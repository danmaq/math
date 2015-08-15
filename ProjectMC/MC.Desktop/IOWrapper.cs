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
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="fileName">ファイル名。</param>
		public IOWrapper(string fileName)
		{
			Target = Path.Combine(path1: GetDirectoryPath(), path2: fileName);
		}

		/// <summary>
		/// 対象へのパスを取得します。
		/// </summary>
		public string Target
		{
			get;
		}

		/// <summary>
		/// 読み込み専用ストリームを取得します。
		/// 呼び出し側が Dispose の責任を負ってください。
		/// </summary>
		public Stream ReadStream => new FileStream(path: Target, mode: FileMode.OpenOrCreate);

		/// <summary>
		/// 書き込み専用ストリームを取得します。
		/// 呼び出し側が Dispose の責任を負ってください。
		/// </summary>
		public Stream WriteStream => new FileStream(path: Target, mode: FileMode.Create);

		/// <summary>
		/// フォルダへのフルパスを取得します。
		/// </summary>
		/// <returns>フォルダへのフルパス。</returns>
		private static string GetDirectoryPath()
		{
			var roaming =
				Environment.GetFolderPath(
					folder: Environment.SpecialFolder.MyDocuments,
					option: Environment.SpecialFolderOption.Create);
			var target =
				Path.Combine(
					path1: roaming, path2: @"SavedGames", path3: @"MATH.SC", path4: @"AllPlayers");
			Directory.CreateDirectory(target);
			return target;
        }
	}
}
