
namespace MC.Common.Data
{
	/// <summary>
	/// 可変性マスタ データのクライアント側キャッシュ。
	/// </summary>
	public static class VolatileMasterCache
	{
		/// <summary>
		/// ユーザ マスタを取得、または設定します。
		/// </summary>
		public static UserData UserData
		{
			get;
			set;
		}
		= UserData.Default;
	}
}
