using System.Collections.Generic;
using MC.MockServer.Question.QG01;

namespace MC.MockServer.Question
{
	/// <summary>
	/// 問題生成クラス。
	/// </summary>
	static class QuestionGenerators
	{
		/// <summary>
		/// 問題生成機能一覧。
		/// </summary>
		public static IReadOnlyDictionary<int, IQuestionGenerator> Generators
		{
			get;
		}
		= new Dictionary<int, IQuestionGenerator>()
		{
			[101] = new QG0101(),
		};
	}
}
