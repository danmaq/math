using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using MC.Common.Data;
using MC.Common.Utils;

namespace MC.MockServer.Question
{
	/// <summary>
	/// 問題生成クラス。
	/// </summary>
	public static class QuestionGenerator
	{
		/// <summary>最大選択数。</summary>
		private const int MaxSelection = 4;

		/// <summary>疑似乱数ジェネレータ。</summary>
		private static readonly Random random = new Random();

		/// <summary>
		/// ステージ 1-1 問題一覧を生成します。
		/// </summary>
		/// <param name="selection">選択肢の数。</param>
		/// <param name="count">問題数。</param>
		/// <returns>問題と解答番号の組。</returns>
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<Tuple<QuestionData, int>> Create0101(int selection, int count)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}
			var funcs = new Func<int, Tuple<QuestionData, int>>[] { Create01011, Create01012 };
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
		private static Tuple<QuestionData, int> Create01011(int selection) =>
			Create0101Common(
				selection: selection,
				question: Res.Properties.Resources.QUESTION1_1_1,
				getDesc: t => t.Item1.ToString(CultureInfo.CurrentCulture),
				getAnswer: t => t.Item2);


		/// <summary>
		/// ステージ 1-1 問題を生成します。
		/// </summary>
		/// <param name="selection">選択肢の数。</param>
		/// <returns>問題と解答番号の組。</returns>
		private static Tuple<QuestionData, int> Create01012(int selection) =>
			Create0101Common(
				selection: selection,
				question: Res.Properties.Resources.QUESTION1_1_2,
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
		private static Tuple<QuestionData, int> Create0101Common(
			int selection,
			string question,
			Func<Tuple<int, string>, string> getDesc,
			Func<Tuple<int, string>, string> getAnswer)
		{
			if (!(selection == 2 || selection == MaxSelection))
			{
				throw new ArgumentOutOfRangeException(nameof(selection));
			}
			var list = QuestionResource.Selection0101;
			var answers =
				EnumerableHelper
					.GenerateUnique(count: selection, generator: () => random.Next(0, list.Count))
					.Select(v => Tuple.Create(v, list[v].GetRandomItem()))
					.ToArray();
			var answer = random.Next(0, selection);
			var data =
				new QuestionData()
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
