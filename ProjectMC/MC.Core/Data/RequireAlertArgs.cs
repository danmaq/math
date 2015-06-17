using System;
using MC.Common.Utils;

namespace MC.Core.Data
{
	/// <summary>
	/// 確認を要求するイベント データです。
	/// </summary>
	sealed class RequireAlertArgs : RequireResponseArgs
	{

		/// <summary>レスポンス用コールバックを取得します。</summary>
		public Action Response
		{
			get;
			internal set;
		}
		= DelegateHelper.EmptyAction;
	}
}
