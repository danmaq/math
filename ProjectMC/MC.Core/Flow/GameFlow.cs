using System;
using System.Collections;
using MC.Common.Collection;
using MC.Common.State;
using MC.Common.Utils;
using MC.Core.Data;

namespace MC.Core.Flow
{
	/// <summary>
	/// ゲーム全体のフローを管理するクラス。
	/// </summary>
	public sealed class GameFlow : IGameFlow
	{

		/// <summary>コンテキストのコレクション。</summary>
		private readonly ContextCollection contextCollection = new ContextCollection();

		/// <summary>
		/// レスポンスを要求する際に発火するイベント。
		/// このイベントを受けたら、ユーザの入力に応じて Response() メソッドを呼び出してください。
		/// </summary>
		public event EventHandler<RequireResponseArgs> RequireResponse =
			DelegateHelper.CreateEmptyEventHandler<RequireResponseArgs>();

		/// <summary>入力タイムアウト時に発火するイベント。</summary>
		public event EventHandler Timeout = DelegateHelper.EmptyHandler;

		/// <summary>
		/// インスタンスを取得します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <returns>ゲームフロー インスタンス。登録されていない場合、null オブジェクト。</returns>
		public static IGameFlow GetService(IContext context) =>
			context?.Container.GetService<IGameFlow>() ?? EmptyGameFlow.Instance;

		/// <summary>
		/// ゲームフローを開始します。
		/// </summary>
		public IEnumerable Run()
		{
			var contextEnumerable = contextCollection.Run();
			contextCollection.Add(new GameFlowContext(this));
            foreach (var count in contextCollection.Run())
			{
				yield return null;
				if (count == 0)
				{
					break;
				}
			}
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose() => contextCollection.Dispose();

		/// <summary>
		/// 入力要求イベントを発火させます。
		/// </summary>
		/// <param name="args">入力要求に必要なデータ。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		internal void DispatchRequireResponse(RequireResponseArgs args)
		{
			if (args == null)
			{
				throw new ArgumentNullException(nameof(args));
			}
			RequireResponse(this, args);
		}

		/// <summary>
		/// 入力タイムアウト イベントを発火させます。
		/// </summary>
		internal void DispatchTimeout()
			=> Timeout(this, EventArgs.Empty);
	}
}
