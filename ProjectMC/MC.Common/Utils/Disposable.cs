using System;

namespace MC.Common.Utils
{

	/// <summary>
	/// Dispose() に対応してコールバックを発生させるためのクラス。
	/// </summary>
	sealed class Disposable : IDisposable
	{

		/// <summary>リソース解放関数。</summary>
		private readonly Action<bool> dispose;

		/// <summary>
		/// 初期化します。
		/// </summary>
		public Disposable()
			: this(_ => DelegateHelper.EmptyAction())
		{
		}

		/// <summary>
		/// 初期化します。
		/// </summary>
		/// <param name="dispose">Dispose() メソッドに対応して呼び出されるコールバック。</param>
		public Disposable(Action dispose)
			: this(_ => (dispose ?? DelegateHelper.EmptyAction)())
		{
		}

		/// <summary>
		/// 初期化します。
		/// 引数には、マネージド リソースの解放も行うかどうかが設定されます。
		/// </summary>
		/// <param name="dispose">Dispose() メソッドに対応して呼び出されるコールバック。</param>
		public Disposable(Action<bool> dispose)
		{
			this.dispose = dispose ?? DelegateHelper.CreateEmptyAction<bool>();
		}

		/// <summary>
		/// ファイナライザ。
		/// </summary>
		~Disposable()
		{
			dispose(false);
		}

		/// <summary>
		/// リソースの解放を行います。
		/// </summary>
		public void Dispose()
		{
			dispose(true);
			GC.SuppressFinalize(obj: this);
		}

		/// <summary>
		/// リソースの解放を行います。
		/// </summary>
		/// <param name="instance">リソース解放可能なオブジェクト。</param>
		/// <returns>リソースの解放を行った場合、true。</returns>
		public static bool Dispose(object instance)
		{
			var disposable = instance as IDisposable;
			var result = disposable != null;
			if (result)
			{
				disposable.Dispose();
			}
			return result;
		}
	}
}
