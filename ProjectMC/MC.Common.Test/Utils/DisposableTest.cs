using System;
using MC.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MC.Common.Test.Utils
{
	/// <summary>
	/// Disposable クラス用テスト。
	/// </summary>
	[TestClass]
	public sealed class DisposableTest
	{

		/// <summary>
		/// Dispose インスタンスのテストをします。
		/// </summary>
		[TestMethod]
		public void TestInstance()
		{
			new Disposable().Dispose();
			var passed = false;
			using (var _ = new Disposable(dispose: () => passed = true))
			{
			}
			Assert.IsTrue(condition: passed, message: @"Dispose()された場合、コールバックを呼ぶ必要があります。");
			passed = false;
			var disposing = false;
			Action<bool> dispose =
				d =>
				{
					passed = true;
					disposing = d;
				};
			using (var _ = new Disposable(dispose: dispose))
			{
			}
			Assert.IsTrue(condition: passed, message: @"スコープを外れた場合、コールバックを呼ぶ必要があります。");
		}

		/// <summary>
		/// Dispose() 静的メソッドのテストをします。
		/// </summary>
		[TestMethod]
		public void TestDispose()
		{
			var passed = false;
			var disposable = new Disposable(dispose: () => passed = true);
			Assert.IsTrue(condition: Disposable.Dispose(instance: disposable), message: @"Disposeされる");
			Assert.IsTrue(condition: passed, message: @"Dispose()された場合、コールバックを呼ぶ必要があります。");
			Assert.IsFalse(condition: Disposable.Dispose(instance: null), message: @"Disposeされる");
			Assert.IsFalse(condition: Disposable.Dispose(instance: 0), message: @"Disposeされる");
			Assert.IsFalse(condition: Disposable.Dispose(instance: new object()), message: @"Disposeされる");
		}
	}
}
