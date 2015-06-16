using System;
using System.Collections.Generic;
using System.Text;

namespace MC.Common.Data
{
	/// <summary>
	/// カード マスタの単票データ。
	/// </summary>
	public struct CardMasterData
    {

		/// <summary>ニックネームを取得または設定します。</summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>一言を取得または設定します。</summary>
		public string Comment
		{
			get;
			private set;
		}

		/// <summary>
		/// 所属大学を取得します。
		/// </summary>
		public CollegeMasterData College
		{
			get;
			private set;
		}
	}
}
