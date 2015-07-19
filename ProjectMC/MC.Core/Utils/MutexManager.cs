using System;
using System.Threading;
using MC.Core.Properties;

namespace MC.Core.Utils
{
	public sealed class MutexManager : IDisposable
	{

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

		~MutexManager()
		{
			Dispose(disposing: false);
		}

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
					Mutex.Close
				}
			}
		}
	}
}
