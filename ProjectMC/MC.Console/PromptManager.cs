using System;
using System.Diagnostics.CodeAnalysis;
using MC.Core.Data;

namespace MC
{
	/// <summary>
	/// プロンプト制御クラス。
	/// </summary>
	class PromptManager
	{
		/// <summary>入力管理オブジェクトを取得します。</summary>
		public KeyManager KeyManager
		{
			get;
		}
		= new KeyManager();

		/// <summary>
		/// 入力を要求された際に呼び出されます。
		/// </summary>
		/// <param name="args">イベント情報。</param>
		public void Prompt(RequireResponseArgs args)
		{
			Console.WriteLine(args.Description);
			Prompt(args as RequireAlertArgs);
			Prompt(args as RequireSelectArgs);
			Prompt(args as RequireTextArgs);
		}

		/// <summary>
		/// 入力を要求された際に呼び出されます。
		/// </summary>
		/// <param name="args">イベント情報。</param>
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		public void Prompt(RequireAlertArgs args)
		{
			if (args != null)
			{
				KeyManager.Enter();
				args.Response();
			}
		}

		/// <summary>
		/// 入力を要求された際に呼び出されます。
		/// </summary>
		/// <param name="args">イベント情報。</param>
		public void Prompt(RequireSelectArgs args)
		{
			if (args != null)
			{
				KeyManager.Prompt(args.Selections);
			}
		}

		/// <summary>
		/// 入力を要求された際に呼び出されます。
		/// </summary>
		/// <param name="args">イベント情報。</param>
		public void Prompt(RequireTextArgs args)
		{
			if (args != null)
			{
				KeyManager.Prompt(null);
				args.Response(KeyManager.Inputed);
			}
		}
	}
}
