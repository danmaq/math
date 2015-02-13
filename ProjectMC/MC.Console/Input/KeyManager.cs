using System;
using System.Collections.Generic;
using MC.Common.Events;
using MC.Common.State;
using MC.Core.Data;

namespace MC.Input
{
	/// <summary>
	/// キー入力管理クラス。
	/// </summary>
	sealed class KeyManager
	{

		/// <summary>選択肢を取得、または設定します。</summary>
		private IReadOnlyCollection<Selection> Selection
		{
			get;
			set;
		}

		/// <summary>入力された値を取得します。</summary>
		public int Selected
		{
			get;
			private set;
		}

		/// <summary>入力された文字列を取得します。</summary>
		public string Inputed
		{
			get;
			private set;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="selection"></param>
		public void Prompt(IReadOnlyCollection<string> selection)
		{
		}

	}
}
