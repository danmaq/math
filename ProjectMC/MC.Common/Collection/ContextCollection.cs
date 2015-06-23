using System;
using System.Collections.Generic;
using MC.Common.State;

namespace MC.Common.Collection
{
	/// <summary>
	/// コンテキストのコレクション。
	/// コンテキストが不活化すると、自動的に削除・解放されます。
	/// </summary>
	sealed class ContextCollection : IDisposable
	{

		/// <summary>本体。</summary>
		private readonly List<IContext> body = new List<IContext>();

		/// <summary>
		/// コンテキストを追加します。
		/// </summary>
		/// <param name="context">コンテキスト。</param>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		public void Add(IContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}
			body.Add(context);
		}

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		public void Dispose()
		{
			body.ForEach(c => c.Dispose());
			body.Clear();
		}

		/// <summary>
		/// コンテキスト一括実行のための列挙子を取得します。
		/// </summary>
		/// <returns>列挙子。実行すると活性的なコンテキストの数を取得します。</returns>
		public IEnumerable<int> Run()
		{
			while (true)
			{
				body.ForEach(c => c.Execute());
				body.RemoveAll(c => c.DisposeIfTerminated());
				yield return body.Count;
			}
		}
	}
}
