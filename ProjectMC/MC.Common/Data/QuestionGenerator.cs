using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Common.Data
{
	/// <summary>
	/// 問題生成クラス。
	/// </summary>
	public sealed class QuestionGenerator
	{

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static QuestionGenerator Instance
		{
			get;
			private set;
		}

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private QuestionGenerator()
		{
		}

		/// <summary>
		/// エリア 1-2 の問題を作成します。
		/// </summary>
		/// <returns>問題集。</returns>
		public IEnumerable<QuestionData> GetQuestion0102()
		{
			var list =
				new string[][]
				{
					new string[] { @"いち", @"ひとつ", @"一", @"1" },
					new string[] { @"に", @"ふたつ", @"二", @"2" },
					new string[] { @"さん", @"みっつ", @"三", @"3" },
					new string[] { @"し", @"よっつ", @"よん", @"四", @"4" },
					new string[] { @"ご", @"いつつ", @"五", @"5" },
					new string[] { @"ろく", @"むっつ", @"六", @"6" },
					new string[] { @"なな", @"ななつ", @"しち", @"七", @"7" },
					new string[] { @"はち", @"やっつ", @"八", @"8" },
					new string[] { @"きゅう", @"ここのつ", @"九", @"9" },
					new string[] { @"いっぱい", @"たくさん", @"指たりない" },
				};
            var result = new List<QuestionData>();
			const string question = @"物の数を数えましょう。";
			var rnd = new Random();
			for (int i = 10; --i >= 0;)
			{
				var answer = rnd.Next(0, 4);
                var answers =
					Enumerable
						.Repeat<Func<int>>(() => rnd.Next(1, 9), 4)
						.Select(f => f())
						.ToArray();
				var item = new QuestionData()
				{
					UniqueId = rnd.Next(),
					Caption = question,
					Description = new string('●', answers[answer]),
					Expires = Constants.ExpiresPractice,
					Answers = null
				};
				result.Add(item);
			}
			return result;
		}
	}
}
