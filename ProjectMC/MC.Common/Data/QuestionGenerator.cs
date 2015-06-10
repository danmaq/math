using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Common.Data
{
	/// <summary>
	/// 問題生成クラス。
	/// </summary>
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

		/// <summary>
		/// エリア 1-1 の問題を作成します。
		/// </summary>
		/// <returns>問題集。</returns>
		public IEnumerable<QuestionData> GetQuestion1_1()
		{
			var result = new List<QuestionData>();
			const string question = @"物の数を数えましょう。";

			for (int i = 10; --i >= 0;)
			{
				var item = new QuestionData() { Question = question };
				result.Add(item);
			}
			return result;
		}
	}
}
