using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MC.Common.Data;

namespace MC.MockServer.Question
{
	sealed class QuestionStore
	{

		public static readonly Dictionary<int, Tuple<QuestionData, int>> store =
			new Dictionary<int, Tuple<QuestionData, int>>();

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static QuestionStore Instance
		{
			get;
		}
		= new QuestionStore();

		public object CreateQuestion(IEnumerable<string> args)
		{
			Func<string, int> cast = Convert.ToInt32;
			var array = args.Select(cast).ToArray();
			if (array.Length < 2)
			{
				throw
					new ArgumentException(
						message: @"引数が足りません。", paramName: nameof(args));
			}
			return CreateQuestion(array[0], array[1]);
		}

		public object CreateQuestion(int collegeId, int SubjectId)
		{

			Debug.WriteLine("CreateQuestion {0} {1}", collegeId, SubjectId);
			return 0;
		}
	}
}
