using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MC.Common.State;
using MC.Common.Utils;

namespace MC.Common.Collection
{
	public sealed class ContextCollection
	{

		/// <summary>本体。</summary>
		private readonly List<IContext> body = new List<IContext>();

		/// <summary>
		/// コンテキストを追加します。
		/// </summary>
		/// <param name="context"></param>
		public void Add(IContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			body.Add(context);
		}

		public IEnumerable<int> Run()
		{
			var count = 0;
			do
			{
				Func<IContext, bool> shredder =
					c =>
					{
						var result = c.IsTerminate();
						if (result)
						{
							c.Dispose();
						}
						return result;
					};
				body.ForEach(c => c.Execute());
				body.RemoveAll(c => c.IsTerminate());
				yield return (count = body.Count);
			}
			while (count > 0);
        }
	}
}
