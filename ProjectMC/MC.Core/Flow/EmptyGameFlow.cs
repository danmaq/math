using System;
using MC.Common.Utils;
using MC.Core.Data;

namespace MC.Core.Flow
{
	/// <summary>
	/// 空のゲームフロー クラス。
	/// </summary>
	class EmptyGameFlow : IGameFlow
	{

		/// <summary>
		/// レスポンスを要求する際に発火するイベント。
		/// このイベントを受けたら、ユーザの入力に応じて Response() メソッドを呼び出してください。
		/// </summary>
		public event EventHandler<RequireResponseArgs> RequireResponse =
			DelegateHelper.CreateEmptyEventHandler<RequireResponseArgs>();

		/// <summary>入力タイムアウト時に発火するイベント。</summary>
		public event EventHandler Timeout = DelegateHelper.EmptyHandler;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private EmptyGameFlow()
		{
		}

		/// <summary>
		/// シングルトン インスタンス。
		/// </summary>
		public static IGameFlow Instance
		{
			get;
		}
		= new EmptyGameFlow();

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
		}
	}
}
