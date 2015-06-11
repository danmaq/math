using System;
using MC.Common.Data;

namespace MC
{

	/// <summary>
	/// ユーザ アカウント情報。
	/// </summary>
	[Serializable]
	struct LocalUserData
	{

		/// <summary>ユーザIDを取得または設定します。</summary>
		public long UserId
		{
			get;
			set;
		}

		/// <summary>ニックネームを取得または設定します。</summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>一言を取得または設定します。</summary>
		public string Comment
		{
			get;
			set;
		}

		/// <summary>
		/// ユーザ アカウントをインポートします。
		/// </summary>
		/// <param name="source"></param>
		public static implicit operator LocalUserData(UserData source) =>
			new LocalUserData()
			{
				UserId = source.UserId, Name = source.Name, Comment = source.Comment
			};
    }
}
