using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MC.Common.Events;

namespace MC.Input
{
	sealed class KeyManager
	{

		public event EventHandler<EventArgs<char>> InputedCharacter;

		public event EventHandler<EventArgs<int>> InputedNumber;

		/// <summary>入力された文字を取得します。</summary>
		public char Character
		{
			get;
			private set;
		}

		/// <summary>入力された数値を取得します。</summary>
		public int Number
		{
			get;
			private set;
		}

		public bool AllowCharacter
		{
			get;
			set;
		}

	}
}
