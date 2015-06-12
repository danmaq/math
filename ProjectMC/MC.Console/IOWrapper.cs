using System;
using MC.Common.Data;

namespace MC
{
	class IOWrapper : IIOWrapper
	{
		public event EventHandler<EventArgs<string>> Failed;

		public void LoadUserData(Action<UserData, bool> onCompleted)
		{
		}

		public void SaveUserData(UserData data, Action<bool> onCompleted)
		{
		}
	}
}
