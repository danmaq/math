using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Data;
using MC.Common.Data.Serializable;
using MC.Common.Utils;
using MC.MockServer.Properties;

namespace MC.MockServer
{
	/// <summary>
	/// ユーザ管理クラス。
	/// </summary>
	sealed class UserManager
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private UserManager()
		{
		}

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static UserManager Instance
		{
			get;
		}
		= new UserManager();

		private static UserData User
		{
			get;
			set;
		}
		= UserData.Default;

		/// <summary>
		/// HTTPからの要求を処理します。
		/// </summary>
		/// <param name="method">HTTPメソッド。</param>
		/// <param name="args">パラメータ一覧。</param>
		/// <param name="contents">コンテンツ。</param>
		/// <returns>クライアントに戻す値。</returns>
		public object Facade(HttpMethodType method, IEnumerable<string> args, string contents)
		{
			switch (method)
			{
				case HttpMethodType.Get:
					User = LoadUserData(long.Parse(args.First()));
					break;
				case HttpMethodType.Post:
					break;
				case HttpMethodType.Put:
					User = CreateUserData();
					break;
				default:
					break;
			}
			return User.Export();
		}

		/// <summary>
		/// ユーザを読み込みます。
		/// 存在しない場合、新規でデータを作成します。
		/// </summary>
		/// <param name="id">ユーザID。</param>
		/// <returns>ユーザ情報。</returns>
		private UserData LoadUserData(long id)
		{
			var match = GetAllUsers().Where(u => u.UserId == id);
			return match.Any() ? UserData.Import(match.First()) : CreateUserData();
		}

		/// <summary>
		///	ユーザを新規生成します。
		/// </summary>
		/// <returns>ユーザ情報。</returns>
		private UserData CreateUserData()
		{
			var user = UserData.Default.CopyTo(userid: CreateUniqueUserId());
			WriteAllUsers(GetAllUsers().Concat(new User[] { user.Export() }).ToArray());
			return user;
		}

		/// <summary>
		/// ユニークなユーザIDを取得します。
		/// </summary>
		/// <returns>ユニークなユーザID。</returns>
		private long CreateUniqueUserId()
		{
			var users = GetAllUsers();
			var random = new Random();
			long id;
			do
			{
				id = (long)(random.Next()) * random.Next();
			}
			while (users.Any(u => id == u.UserId));
			return id;
		}

		/// <summary>
		/// ユーザ情報一覧を全件取得します。
		/// </summary>
		/// <returns>ユーザ情報一覧。</returns>
		private User[] GetAllUsers()
		{
			var json = VolatileMasterCache.ServerSaveData.ReadAsync(Resources.KEY_USER).Result;
			return json == null ? new User[0] : StringHelper.FromJson<User[]>(json);
		}

		/// <summary>
		/// ユーザ一覧をテーブルに上書きします。
		/// </summary>
		/// <param name="users">ユーザ一覧。</param>
		private void WriteAllUsers(IEnumerable<User> users)
		{
			var json = StringHelper.ToJson(users.ToArray());
			VolatileMasterCache.ServerSaveData.WriteAsync(key: Resources.KEY_USER, value: json);
        }
	}
}
