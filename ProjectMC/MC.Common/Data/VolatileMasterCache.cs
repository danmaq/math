
using MC.Common.Data.IO;

namespace MC.Common.Data
{
	/// <summary>
	/// 可変性マスタ データのクライアント側キャッシュ。
	/// </summary>
	public static class VolatileMasterCache
	{
		/// <summary>
		/// クライアント側のセーブデータ。
		/// </summary>
		public static AutoSerializeDictionary ClientSaveData
		{
			get;
		}
		= new AutoSerializeDictionary();

		/// <summary>
		/// サーバ側のセーブデータ。
		/// </summary>
		public static AutoSerializeDictionary ServerSaveData
		{
			get;
		}
		= new AutoSerializeDictionary();

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
