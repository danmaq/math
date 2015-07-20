using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MC.Common.Collection;
using MC.Core.Data;
using MC.Properties;

namespace MC
{
	/// <summary>
	/// キー入力管理クラス。
	/// </summary>
	sealed class KeyManager
	{

		/// <summary>選択肢を取得、または設定します。</summary>
		private IReadOnlyList<Selection> Selection
		{
			get;
			set;
		}

		/// <summary>入力された文字列を取得します。</summary>
		public string Inputed
		{
			get;
			private set;
		}

		/// <summary>
		/// 入力を要求します。
		/// </summary>
		/// <param name="selection">選択肢。</param>
		public void Prompt(IReadOnlyList<Selection> selection)
		{
			if ((Selection = selection) == null)
			{
				Console.WriteLine(Resources.MESSAGE_INPUT);
				Inputed = Console.ReadLine();
			}
			else
			{
				Console.WriteLine(Resources.MESSAGE_SELECT);
				Func<Selection, int, string> selector =
					(s, i) =>
						string.Format(
							CultureInfo.CurrentCulture, @"{0}: {1}", i + 1, s.Description);
                selection
					.Select(selector)
					.ForEach<string>(Console.WriteLine);
			}
		}

		/// <summary>
		/// 入力をチェックします。
		/// </summary>
		public void PeekInput()
		{
			if (Console.KeyAvailable)
			{
				var readed = (int)(Console.ReadKey(true).Key);
				if (Selection != null)
				{
					PeekInput(readed >= 96 ? readed - 48 : readed);
				}
			}
		}

		/// <summary>
		/// 入力をチェックします。
		/// </summary>
		/// <param name="readed">入力値。</param>
		/// <exception cref="InvalidOperationException">
		/// 選択肢が存在しない状態で、この関数を呼び出した場合。
		/// </exception>
		private void PeekInput(int readed)
		{
			var index = ToIndex(readed);
			var select = TryGetSelection(index);
			if (select.HasValue)
			{
				Selection = null;
				Console.WriteLine(index);
				select.Value.Select();
			}
		}

		/// <summary>
		/// 入力値から選択肢を取得します。
		/// </summary>
		/// <param name="index">インデックス。</param>
		/// <returns>選択肢。インデックスが正しくない場合、null。</returns>
		/// <exception cref="InvalidOperationException">
		/// 選択肢が存在しない状態で、この関数を呼び出した場合。
		/// </exception>
		private Selection? TryGetSelection(int index)
		{
			if (Selection == null)
			{
				throw new InvalidOperationException(@"選択肢が存在しません。");
			}
			return index > 0 && index <= Selection.Count ? Selection[index - 1] : (Selection?)null;
		}

		/// <summary>
		/// Enter 入力を要求します。
		/// </summary>
		public static void Enter()
		{
			Console.WriteLine(Resources.MESSAGE_ENTER);
			Console.ReadKey();
		}

		/// <summary>
		/// 入力値からインデックスを取得します。
		/// 範囲外の値を得ることもあるので、必ず使用前に検証を行ってください。
		/// </summary>
		/// <param name="readed">入力値。</param>
		/// <returns>インデックス。<paramref name="readed"/> が正しくない場合、負数値。</returns>
		public static int ToIndex(int readed)
		{
			var str = Convert.ToChar(value: readed).ToString();
			int index;
			return int.TryParse(s: str, result: out index) ? index : int.MinValue;
		}
	}
}
