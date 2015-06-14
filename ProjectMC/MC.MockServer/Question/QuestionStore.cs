using System;
using System.Collections.Generic;
using MC.Common.Data;

namespace MC.MockServer.Question
{
    static class QuestionStore
    {
		public static readonly Dictionary<int, Tuple<QuestionData, int>> store =
			new Dictionary<int, Tuple<QuestionData, int>>();
    }
}
