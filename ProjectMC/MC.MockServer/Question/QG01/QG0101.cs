using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MC.Common.Collection;
using MC.Common.Data;
using MC.MockServer.Properties;

using QandA = System.Tuple<MC.Common.Data.QuestionData, int>;

namespace MC.MockServer.Question.QG01
{

	/// <summary>
	/// ステージ 1-1 用、問題生成クラス。
	/// </summary>
	sealed class QG0101 : IQuestionGenerator
	{
		/// <summary>疑似乱数ジェネレータ。</summary>
		private static readonly Random random = new Random();

		/// <summary>
		/// 問題一覧を生成します。
		/// </summary>
		/// <param name="selection">選択肢の数。</param>
		/// <param name="count">問題数。</param>
		/// <returns>問題と解答番号の組。</returns>
		public IEnumerable<QandA> Create(int selection, int count)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}
			var funcs = new Func<int, QandA>[] { Create01011, Create01012 };
			while (--count >= 0)
			{
				yield return funcs.GetRandomItem()(selection);
			}
		}

		/// <summary>
		/// ステージ 1-1 問題を生成します。
		/// </summary>
		/// <param name="selection">選択肢の数。</param>
		/// <returns>問題と解答番号の組。</returns>
		private static QandA Create01011(int selection) =>
			Create0101Common(
				selection: selection,
				question: Resources.QUESTION1_1_1,
				getDesc: t => t.Item1.ToString(CultureInfo.CurrentCulture),
				getAnswer: t => t.Item2);


		/// <summary>
		/// ステージ 1-1 問題を生成します。
		/// </summary>
		/// <param name="selection">選択肢の数。</param>
		/// <returns>問題と解答番号の組。</returns>
		private static QandA Create01012(int selection) =>
			Create0101Common(
				selection: selection,
				question: Resources.QUESTION1_1_2,
				getDesc: t => t.Item2,
				getAnswer: t => t.Item1.ToString(CultureInfo.CurrentCulture));

		/// <summary>
		/// ステージ 1-1 問題を生成します。
		/// </summary>
		/// <param name="selection">選択肢の数。</param>
		/// <param name="question">問題。</param>
		/// <param name="getDesc">問題を抽出する関数。</param>
		/// <param name="getAnswer">回答を抽出する関数。</param>
		/// <returns>問題と解答番号の組。</returns>
		private static QandA Create0101Common(
			int selection,
			string question,
			Func<Tuple<int, string>, string> getDesc,
			Func<Tuple<int, string>, string> getAnswer)
		{
			if (!(selection == 2 || selection == 4))
			{
				throw new ArgumentOutOfRangeException(nameof(selection));
			}
			var list = QuestionResource.Selection0101;
			var answers = (
				from v in
					EnumerableHelper
						.Generate(
							count: selection,
							generator: i => random.Next(0, i == 0 ? 10 : list.Count),
							predicate: (v, l) => l.All(i => !v.Equals(i)))
				orderby random.Next()
				select Tuple.Create(v, list[v].GetRandomItem())).ToArray();
			var answer =
				answers
					.Select((t, i) => Tuple.Create(t.Item1, i))
					.Where(t => t.Item1 < 10)
					.OrderBy(_ => random.Next())
					.First()
					.Item2;
			var data =
				new Common.Data.QuestionData()
				{
					UniqueId = random.Next(),
					Caption = question,
					Description = getDesc(answers[answer]),
					Expires = Constants.ExpiresPractice,
					Answers = answers.Select(getAnswer).ToArray(),
				};
			return Tuple.Create(data, answer);
		}
	}
}
