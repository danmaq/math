﻿using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Collection;

using QandA = System.Tuple<MC.Common.Data.QuestionData, int>;

namespace MC.MockServer.Question
{

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
		/// <exception cref="ArgumentException">引数が足りない場合。</exception>
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

		/// <summary>
		/// 回答の判定を行います。
		/// </summary>
		/// <param name="args">引数一覧。</param>
		/// <returns>回答が正解である場合、true。</returns>
		/// <exception cref="ArgumentException">引数が足りない場合。</exception>
		public bool JudgeQuestion(IEnumerable<string> args)
		{
			Func<string, int> cast = Convert.ToInt32;
			var array = args.Select(cast).ToArray();
			if (array.Length < 2)
			{
				throw
					new ArgumentException(
						message: @"引数が足りません。", paramName: nameof(args));
			}
			return JudgeQuestion(qid: array[0], answer: array[1]);
        }

		/// <summary>
		/// 回答の判定を行います。
		/// </summary>
		/// <param name="qid">問題ID。</param>
		/// <param name="answer">回答。</param>
		/// <returns>回答が正解である場合、true。</returns>
		public bool JudgeQuestion(int qid, int answer)
		{
			QandA qa;
			return Question.TryGetValue(key: qid, value: out qa) && qa.Item2 == answer;
        }
	}
}
