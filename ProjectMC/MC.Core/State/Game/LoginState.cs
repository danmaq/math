using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using MC.Common.Data;
using MC.Common.State;
using MC.Core.Data;
using MC.Core.Properties;
using MC.Core.Server;

namespace MC.Core.State.Game
{
	sealed class LoginState : IState
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private LoginState()
		{
		}

		/// <summary>インスタンスを取得します。</summary>
		public static IState Instance
		{
			get;
		}
		= new LoginState();

		/// <summary>
		/// この状態に移行された直後に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Begin(IContext context)
		{
			Debug.WriteLine(Resources.DEBUG_STARTED, nameof(LoginState));
			Api.Initialize();
			MasterCache.DownloadAllMasterAsync(Api.LoadAllMasterAsync);
        }

		/// <summary>
		/// 状態が実行された際に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Execute(IContext context)
		{
			if (MasterCache.Ready)
			{
				LoadUserData();
				context.NextState = TitleState.Instance;
			}
		}

		/// <summary>
		/// 他の状態に移行する直前に呼び出されます。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		[SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", MessageId = "0")]
		public void Teardown(IContext context)
		{
			Debug.WriteLine(Resources.DEBUG_TERMINATED, nameof(LoginState));
		}

		/// <summary>
		/// ユーザ データを読み込みます。
		/// </summary>
		private async void LoadUserData()
		{
			var mgr = VolatileMasterCache.ClientSaveData;
            var key = ClientStorageKeys.UserId.ToString();
            var uid = await mgr.ReadAsync(key);
			var userid = uid == null ? new Random().Next() : Convert.ToInt32(uid);
			if (uid == null)
			{
				mgr.WriteAsync(key: key, value: userid.ToString(CultureInfo.InvariantCulture));
			}
		}
	}
}
