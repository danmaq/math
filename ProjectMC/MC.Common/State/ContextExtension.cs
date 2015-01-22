using System;

namespace MC.Common.State
{
	public static class ContextExtension
	{

		public static bool IsTerminate(this IContext context)
		{
			throw new NotImplementedException();
		}

		public static void Terminate(this IContext context)
		{
			context.Terminate(immediately: true);
		}

		public static void Terminate(this IContext context, bool immediately)
		{
			throw new NotImplementedException();
		}
	}
}
