using System;
using System.Diagnostics.Contracts;

namespace MC.Common.State
{
	[ContractClassFor(typeof(IState))]
	abstract class IStateContract : IState
	{
		public void Execute(IContext context)
		{
			Contract.Requires<ArgumentNullException>(context != null);
		}

		public void Begin(IContext context)
		{
			Contract.Requires<ArgumentNullException>(context != null);
		}

		public void Teardown(IContext context)
		{
			Contract.Requires<ArgumentNullException>(context != null);
		}
	}
}
