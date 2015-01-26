using System;

namespace MC.Common.Utils
{
	/// <summary>
	/// デリゲートのためのヘルパ関数群クラス。
	/// </summary>
	public static class DelegateHelper
	{

		/// <summary>何もしないアクション。</summary>
		public static Action EmptyAction
		{
			get;
		}
		= () =>
		{
		};

		/// <summary>
		/// 何もしないアクションを作成します。
		/// </summary>
		/// <typeparam name="T">引数の型。</typeparam>
		/// <returns>何もしないアクション</returns>
		public static Action<T> CreateEmptyAction<T>()
		{
			return x =>
			{
			};
		}
	}
}
