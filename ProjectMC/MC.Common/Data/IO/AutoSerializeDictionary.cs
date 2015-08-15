using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MC.Common.Utils;

namespace MC.Common.Data.IO
{

	/// <summary>
	/// 自動的にシリアライズを行う辞書。
	/// </summary>
	public sealed class AutoSerializeDictionary
	{
		/// <summary>並列動作を制限するためのセマフォ。</summary>
		private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(initialCount: 1);

		/// <summary>辞書本体。</summary>
		private Dictionary<string, string> body;

		/// <summary>I/O 委譲のためのインターフェイス。</summary>
		private IIOWrapper ioDelegate = EmptyIO.Instance;

		/// <summary>
		/// I/O 委譲のためのインターフェイスを取得、または設定します。
		/// </summary>
		public IIOWrapper IODelegate
		{
			get
			{
				return ioDelegate;
            }
			set
			{
				ioDelegate = value ?? EmptyIO.Instance;
			}
		}

		/// <summary>
		/// 辞書に登録されている値を取得します。
		/// </summary>
		/// <param name="key">キー。</param>
		/// <returns>値。</returns>
		public async Task<string> ReadAsync(string key)
		{
			Func<string> read =
				() =>
				{
					string value;
					var result = body.TryGetValue(key, out value);
					return result ? value : null;
				};
			await LoadAsync();
			return await semaphore.RunActionWaitAsync(read);
		}

		/// <summary>
		/// 辞書にキーと値のペアを書き込みます。
		/// </summary>
		/// <param name="key">キー。</param>
		/// <param name="value">値。</param>
		public async void WriteAsync(string key, string value)
		{
			await LoadAsync();
			await semaphore.RunActionWaitAsync(() => body[key] = value);
			await SaveAsync();
		}

		/// <summary>
		/// 辞書を読み込みます。
		/// </summary>
		/// <returns>非同期操作用オブジェクト。</returns>
		private async Task LoadAsync()
		{
			// TODO: 長すぎる
			if (body == null)
			{
				Func<Dictionary<string, string>> load =
					() =>
					{
						var serializer =
							new XmlSerializer(typeof(SerializablePair<string, string>[]));
						using (var stream = IODelegate.ReadStream)
						{
							try
							{
								var kvlist =
									(SerializablePair <string, string>[])serializer.Deserialize(
										stream);
								return
									kvlist.ToDictionary(
										keySelector: p => p.Key, elementSelector: p => p.Value);
							}
							catch
							{
								return new Dictionary<string, string>();
							}
                        }
					};
				body = await semaphore.RunActionWaitAsync(load);
			}
		}

		/// <summary>
		/// 辞書を保存します。
		/// </summary>
		/// <returns>非同期操作用オブジェクト。</returns>
		private async Task SaveAsync()
		{
			Action save =
				() =>
				{
					var array = body.Select(p => SerializablePair.Create(p)).ToArray();
					var serializer =
						new XmlSerializer(typeof(SerializablePair<string, string>[]));
					using (var stream = IODelegate.WriteStream)
					{
                        serializer.Serialize(stream: stream, o: array);
					}
				};
			await semaphore.RunActionWaitAsync(save);
		}
	}
}
