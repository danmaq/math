using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MC.Res.Properties;

namespace MC.Common.Data
{

	/// <summary>
	/// 不揮発性の辞書。
	/// </summary>
	static class IOManager
	{
		/// <summary>データ ファイルへのパス。</summary>
		private static readonly string path = GetDataFilePath();

		/// <summary>並列動作を制限するためのセマフォ。</summary>
		private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 1);

		/// <summary>保存されるデータ。</summary>
		private static Dictionary<string, string> dictionary;

		/// <summary>
		/// 辞書を読み込みます。
		/// </summary>
		/// <param name="key">キー。</param>
		/// <returns>値の文字列。</returns>
		public static async Task<string> ReadAsync(string key)
		{
			if (dictionary == null)
			{
				dictionary = await LoadAsync();
			}
			string result;
			dictionary.TryGetValue(key, out result);
			return result;
		}



		/// <summary>
		/// 辞書を読み込みます。
		/// </summary>
		/// <returns>辞書。</returns>
		private static async Task<Dictionary<string, string>> LoadAsync()
		{
			await semaphore.WaitAsync();
			try
			{
				var serializer = new XmlSerializer(typeof(Dictionary<string, string>));
				using (var stream = File.OpenRead(path))
				{
					return (Dictionary<string, string>)serializer.Deserialize(stream);
				}
			}
			finally
			{
				semaphore.Release();
			}
		}

		/// <summary>
		/// データ ファイルへのパスを取得します。
		/// </summary>
		/// <returns>データ ファイルへのパス。</returns>
		private static string GetDataFilePath()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath =
				string.Format(
					CultureInfo.InvariantCulture,
					Resources.PATH_DATA,
					Resources.APP_CODENAME,
					Resources.FILE_DATA);
			return Path.Combine(documentsPath, filePath);
		}

	}
}
