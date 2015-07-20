using System;
using System.Threading;
using MC.Core.Properties;

namespace MC.Core.Utils
{

	/// <summary>
	/// ミューテックス管理クラス。
	/// この機能を使って多重起動を抑止します。
	/// </summary>
	public sealed class MutexManager : IDisposable
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="id">アプリ名を示す固有のID。</param>
		public MutexManager(string id)
		{
			var mutex = new Mutex(false, id);
			if (!mutex.WaitOne(TimeSpan.Zero))
			{
				mutex.Dispose();
				throw new InvalidOperationException(Resources.ERR_MUTEX);
			}
			Mutex = mutex;
		}

		/// <summary>
		/// エラーメッセージを取得します。
		/// </summary>
		public static string ErrorMessage => Resources.ERR_MUTEX;

		/// <summary>
		/// ファイナライザ。
		/// </summary>
		~MutexManager()
		{
			Dispose(disposing: false);
		}

		/// <summary>
		/// ミューテックス オブジェクトを取得します。
		/// </summary>
		public Mutex Mutex
		{
			get;
			private set;
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(obj: this);
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージド リソースも解放するかどうか。</param>
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Mutex != null)
				{
					Mutex.ReleaseMutex();
					Mutex.Dispose();
					Mutex = null;
				}
			}
		}
	}
}
