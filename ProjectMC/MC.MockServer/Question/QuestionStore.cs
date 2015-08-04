using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Collection;
using MC.Common.Data;

namespace MC.MockServer.Question
{
	using QandA = Tuple<QuestionData, int>;

	sealed class QuestionStore
	{

		/// <summary>疑似乱数ジェネレータ。</summary>
		private static readonly Random random = new Random();

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static QuestionStore Instance
		{
			get;
		}
		= new QuestionStore();

		/// <summary>
		/// 現在アクティブな問題一覧。
		/// </summary>
		private IReadOnlyDictionary<int, QandA> Question
		{
			get;
			set;
		}

		/// <summary>
		/// 問題一覧を作成します。
		/// </summary>
		/// <param name="args">引数一覧。</param>
		/// <returns>問題一覧。</returns>
		public object CreateQuestion(IEnumerable<string> args)
		{
			Func<string, int> cast = Convert.ToInt32;
			var array = args.Select(cast).ToArray();
			if (array.Length < 2)
			{
				// TODO: 将来的にバトル問題にも対応する
				throw
					new ArgumentException(
						message: @"引数が足りません。", paramName: nameof(args));
			}
			return CreateQuestion(array[1]);
		}

		/// <summary>
		/// 問題一覧を作成します。
		/// </summary>
		/// <param name="SubjectId">教科ID。</param>
		/// <returns>問題一覧。</returns>
		public object CreateQuestion(int SubjectId)
		{
			IQuestionGenerator gen;
			if (!QuestionGenerators.Generators.TryGetValue(SubjectId, out gen))
			{
				gen = QuestionGenerators.Generators.First().Value;
			}
			Question = gen.Create(4, SubjectId == 101 ? 5 : 10).ToDictionary(q => random.Next());
			return
				Question.Select(p => EnumerableHelper.CreatePair(p.Key, p.Value.Item1)).ToArray();
		}
	}
}
