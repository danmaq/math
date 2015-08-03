using System;
using System.Collections.Generic;
using MC.MockServer.Question.QG01;

namespace MC.MockServer.Question
{
	static class QuestionGenerators
	{
		public static Dictionary<int, IQuestionGenerator> Generators
		{
			get;
		}
		= new Dictionary<int, IQuestionGenerator>()
		{
			[101] = new QG0101(),
		};
	}
}
