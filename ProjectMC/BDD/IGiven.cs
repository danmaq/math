
namespace BDD
{
	/// <summary>
	/// BDDの条件実行に必要な定義。
	/// </summary>
	public interface IGiven
	{

		/// <summary>
		/// 追加条件を登録します。
		/// </summary>
		/// <param name="task">追加条件。</param>
		/// <returns></returns>
		IGiven When(string task);

		/// <summary>
		/// 結果の検証を登録します。
		/// </summary>
		/// <param name="task">結果の検証。</param>
		/// <returns></returns>
		IGiven Then(string task);
	}
}
