using System;

namespace BDD
{

	sealed class Given<T> : IGiven
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="container"></param>
		/// <param name="tables">テスト テーブル。</param>
		/// <param name="firstTask">最初のタスク。</param>
		public Given(T container, TestTables<T> tables, Action<T> firstTask)
		{
			Container = container;
			Tables = tables;
			firstTask(Container);
		}

		/// <summary>
		/// テスト テーブルを取得、または設定します。
		/// </summary>
		private TestTables<T> Tables
		{
			get;
			set;
		}

		/// <summary>
		/// テスト用コンテナを取得します。
		/// </summary>
		private T Container
		{
			get;
			set;
		}

		public IGiven Then(string task)
		{
			Tables.GetTest(task: task, type: BDDType.Then)(Container);
			return this;
		}

		public IGiven When(string task)
		{
			Tables.GetTest(task: task, type: BDDType.When)(Container);
			return this;
		}
	}
}
