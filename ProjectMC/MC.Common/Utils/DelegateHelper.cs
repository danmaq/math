﻿using System;

namespace MC.Common.Utils
{
	/// <summary>
	/// デリゲートのためのヘルパ関数群クラス。
	/// </summary>
	public static class DelegateHelper
	{

		/// <summary>何もしないアクション。</summary>
		public static Action EmptyAction =>
			() =>
			{
			};

		/// <summary>何もしないイベント ハンドラ。</summary>
		public static EventHandler EmptyHandler => (_, __) => EmptyAction();

		/// <summary>
		/// 何もしないアクションを作成します。
		/// </summary>
		/// <typeparam name="T">引数の型。</typeparam>
		/// <returns>何もしないアクション。</returns>
		public static Action<T> CreateEmptyAction<T>() =>
			_ => EmptyAction();

		/// <summary>
		/// 何もしないイベント ハンドラを作成します。
		/// </summary>
		/// <typeparam name="T">引数の型。</typeparam>
		/// <returns>何もしないイベント ハンドラ。</returns>
		public static EventHandler<T> CreateEmptyEventHandler<T>() =>
			(_, __) => EmptyAction();
	}
}