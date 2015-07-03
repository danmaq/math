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
	static class NonVolatileDictionary
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
		/// <returns>値が存在するかどうか、および値の文字列の組。</returns>
		public static async Task<Tuple<bool, string>> ReadAsync(string key)
		{
			// await できないので、LoadAsync()を呼ばずにコピペする
			if (dictionary == null)
			{
				dictionary = await InnerLoadAsync();
			}
			string value;
			var result = dictionary.TryGetValue(key, out value);
			return Tuple.Create(result, value);
		}

		/// <summary>
		/// 辞書に書き込みます。
		/// </summary>
		/// <param name="key">キー。</param>
		/// <param name="value">文字列。</param>
		public static async void WriteAsync(string key, string value)
		{
			dictionary[key] = value;
			await SaveAsync();
		}

		/// <summary>
		/// 辞書を読み込みます。
		/// </summary>
		public static async void LoadAsync()
		{
			if (dictionary == null)
			{
				dictionary = await InnerLoadAsync();
			}
		}

		/// <summary>
		/// 辞書を読み込みます。
		/// </summary>
		/// <returns>辞書。</returns>
		private static async Task<Dictionary<string, string>> InnerLoadAsync()
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
		/// 辞書を保存します。
		/// </summary>
		/// <returns>例外が発生した場合、例外を返します。正常に終了した場合は null。</returns>
		private static async Task<Exception> SaveAsync()
		{
			await semaphore.WaitAsync();
			try
			{
				await Task.Factory.StartNew(InnerSave);
				return null;
			}
			catch (Exception e)
			{
				return e;
			}
			finally
			{
				semaphore.Release();
			}
		}

		/// <summary>
		/// 辞書を保存します。
		/// </summary>
		private static void InnerSave()
		{
			var serializer = new XmlSerializer(typeof(Dictionary<string, string>));
			using (var stream = File.OpenWrite(path))
			{
				serializer.Serialize(stream: stream, o: dictionary);
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
