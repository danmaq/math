using System;

namespace MC.Core.Data
{
	public static class IOHelper
	{

		public static Func<string, string> LoadFile
		{
			get;
			set;
		}

		public static Func<string, string, Exception> SaveFile
		{
			get;
			set;
		}

	}
}
