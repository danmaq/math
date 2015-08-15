using MC.Common.Data;

namespace MC.MockServer
{
	/// <summary>
	/// ユーザ管理クラス。
	/// </summary>
	static class UserManager
	{

		private static UserData User
		{
			get;
			set;
		}
		= UserData.Default;

	}
}
