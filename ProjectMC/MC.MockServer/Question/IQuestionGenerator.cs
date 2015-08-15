using System.Collections.Generic;

using QandA = System.Tuple<MC.Common.Data.QuestionData, int>;

namespace MC.MockServer.Question
{

	/// <summary>
	/// 問題生成のための定義。
	/// </summary>
	interface IQuestionGenerator
	{

		/// <summary>
		/// 問題を生成するメソッドを定義します。
		/// </summary>
		/// <param name="selection">選択肢数。</param>
		/// <param name="count">問題数。</param>
		/// <returns>問題一覧。</returns>
		IEnumerable<QandA> Create(int selection, int count);
	}
}
