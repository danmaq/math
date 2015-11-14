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
		public object Facade(string method, IEnumerable<string> args, string contents)
		{
			UserData user = User;
			switch ((HttpMethodType)Enum.Parse(typeof(HttpMethodType), method))
			{
				case HttpMethodType.Get:
					// TODO: Getで存在しない場合、PUTする。
					// 本当は良くないがクライアント側でIDをでっちあげているための策。
					LoadUserData(long.Parse(args.First()), out user);
					User = user;
                    break;
				case HttpMethodType.Post:
					break;
				case HttpMethodType.Put:
					User = UserData.Default;
					//VolatileMasterCache.ServerSaveData.WriteAsync(
					//	key: Resources.KEY_USER, value: StringHelper.ToJson(User.Export()));
					break;
				default:
					break;
			}
			return User;
		}

		private bool LoadUserData(long id, out UserData data)
		{
			var json = VolatileMasterCache.ServerSaveData.ReadAsync(Resources.KEY_USER).Result;
			var match = StringHelper.FromJson<User[]>(json).Where(u => u.UserId == id);
			var result = match.Any();
			data = result ? UserData.Import(match.First()) : UserData.Default;
			return result;
        }
	}
}
