using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Data;
using MC.Common.Utils;

namespace MC.MockServer.Question
{
	/// <summary>
	/// 問題生成クラス。
	/// </summary>
	public sealed class QuestionGenerator
	{
		/// <summary>最大選択数。</summary>
		private const int MaxSelection = 4;

		/// <summary>疑似乱数ジェネレータ。</summary>
		private static readonly Random random = new Random();

		public IEnumerable<Tuple<QuestionData, int>> Create0101(int selection, int count)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}
			while (--count >= 0)
			{
				yield return Create01011(selection);
            }
		}

		private Tuple<QuestionData, int> Create01011(int selection)
		{
			if (!(selection == 2 || selection == MaxSelection))
			{
				throw new ArgumentOutOfRangeException(nameof(selection));
			}
			var list = QuestionResource.Selection0101;
			var answer = random.Next(0, selection);
			var answers =
				EnumerableHelper
					.GenerateUnique(count: selection, generator: () => random.Next(0, list.Count))
					.Select(v => Tuple.Create(v, list[v].GetRandomItem()))
					.ToArray();
			var data =
				new QuestionData()
				{
					UniqueId = random.Next(),
					Caption = Res.Properties.Resources.QUESTION1_1_1,
					Description = answers[answer].Item1.ToString(),
					Expires = Constants.ExpiresPractice,
					Answers = answers.Select(t => t.Item2).ToArray(),
				};
			return Tuple.Create(data, answer);
        }
	}
}
