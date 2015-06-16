using System;
using MC.Common.Collection;
using MC.Common.Utils;

namespace MC.Common.State
{
	/// <summary>
	/// Stateパターンにおける、コンテキストの実装。
	/// </summary>
	public class Context : IContext
	{

		/// <summary>状態の確定を抑制するかどうか。</summary>
		private bool commitLock;

		/// <summary>データ コンテナ。</summary>
		private ServiceContainer container = new ServiceContainer();

		/// <summary>
		/// コンテキストを既定の状態で初期化します。
		/// </summary>
		public Context()
		{
		}

		/// <summary>
		/// コンテキストを指定の状態で初期化します。
		/// </summary>
		/// <param name="firstState">最初の状態。</param>
		public Context(IState firstState)
			: this()
		{
			NextState = firstState;
			CommitNextState();
		}

		/// <summary>
		/// ファイナライザ。
		/// </summary>
		~Context()
		{
			Dispose(false);
		}

		/// <summary>前回の状態を取得します。</summary>
		public IState PreviousState
		{
			get;
			private set;
		}
		= NullState.Instance;

		/// <summary>現在の状態を取得します。</summary>
		public IState CurrentState
		{
			get;
			private set;
		}
		= NullState.Instance;

		/// <summary>次回の状態を取得、または設定します。</summary>
		public IState NextState
		{
			get;
			set;
		}

		/// <summary>データ コンテナを取得します。</summary>
		public ServiceContainer Container => container;

		/// <summary>排他制御用オブジェクトを取得します。</summary>
		private object SyncRoot
		{
			get;
		}
		= new object();


		/// <summary>状態の確定を抑制するかどうかを取得、または設定します。</summary>
		private bool CommitLock
		{
			get
			{
				lock (SyncRoot)
				{
					return commitLock;
				}
			}
			set
			{
				lock (SyncRoot)
				{
					commitLock = value;
				}
			}
		}

		/// <summary>
		/// 次回の状態を確定します。
		/// </summary>
		/// <returns>確定した状態。</returns>
		public IState CommitNextState()
		{
			var result = CommitLock ? null : NextState;
            if (result != null)
			{
				CommitLock = true;
				result.Teardown(this);
				PreviousState = CurrentState;
				CurrentState = result;
				NextState = null;
				CurrentState.Begin(this);
				CommitLock = false;
			}
			return result;
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
		/// オブジェクトの文字列表現を取得します。
		/// </summary>
		/// <returns>文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(Context)} Prev:{PreviousState}, Current:{CurrentState}, Next:{NextState}");

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		/// <param name="disposing">マネージド リソースも解放するかどうか。</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Terminate();
				this.Terminate();
				if (container != null)
				{
					container.Dispose();
					container = null;
				}
			}
		}
	}
}
