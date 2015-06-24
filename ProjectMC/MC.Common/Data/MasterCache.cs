using System.Collections.Generic;

namespace MC.Common.Data
{
	sealed class MasterCache
	{

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private MasterCache()
		{
		}

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static MasterCache Instance
		{
			get;
		}
		= new MasterCache();

		/// <summary>
		/// 学園マスタを取得します。
		/// </summary>
		public IReadOnlyCollection<CollegeMasterData> CollegeMaster
		{
			get;
			private set;
		}

		/// <summary>
		/// 講義マスタを取得します。
		/// </summary>
		public IReadOnlyCollection<SubjectMasterData> SubjectMaster
		{
			get;
			private set;
		}

	}
}
