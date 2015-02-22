using System;
using System.Collections.Generic;

namespace BDD
{
	/// <summary>
	/// テスト関数テーブル。
	/// </summary>
	/// <typeparam name="T">コンテナの型。</typeparam>
	public sealed class TestTables<T>
	{

		/// <summary>
		/// テーブルを初期化します。
		/// </summary>
		/// <param name="initializer">コンテナ初期化関数。</param>
		/// <param name="testTable"></param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public TestTables(
			Func<T> initializer, IDictionary<Tuple<string, BDDType>, Action<T>> testTable)
		{
			if (initializer == null)
			{
				throw new ArgumentNullException(nameof(initializer));
			}
			if (testTable == null)
			{
				throw new ArgumentNullException(nameof(testTable));
			}
			TestTable = testTable;
		}

		/// <summary>
		/// 
		/// </summary>
		private IDictionary<Tuple<string, BDDType>, Action<T>> TestTable
		{
			get;
			set;
		}

		private Func<T> Initializer
		{
			get;
			set;
		}

		/// <summary>
		/// 存在しない、または未実装タスクを呼び出した際に呼び出される、代替のタスクを取得します。
		/// </summary>
		private Action<T> NotImplemented =>
			_ =>
			{
				throw new InvalidOperationException();
			};

		public IGiven Given(string task)
		{
			if (Initializer == null)
			{
				throw new InvalidOperationException(@"初期化不能");
			}
			var firstTask = GetTest(task: task, type: BDDType.Given);
			return new Given<T>(container: Initializer(), tables: this, firstTask: firstTask);
		}

		internal Action<T> GetTest(string task, BDDType type)
		{
			Action<T> result;
			var impl = TestTable.TryGetValue(key: Tuple.Create(task, type), value: out result);
            return impl ? result : NotImplemented;
		}
	}
}
