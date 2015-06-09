using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Common.Data
{
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

		public IEnumerable<QuestionData> GetQuestion1_1()
		{
			var result = new List<QuestionData>();
			const string question = @"物の数を数えましょう。";

			for (int i = 10; --i >= 0;)
			{
				var item = new QuestionData() { };
				result.Add(item);
			}
			return result;
		}
	}
}
