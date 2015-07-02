using System.Linq;
using System.Collections.Generic;
using MC.Core.Server;

namespace MC.Common.Data
{
	sealed class MasterCache
	{
		/// <summary>
		/// すべてのマスタを読み込みます。
		/// </summary>
		public static async void DownloadAllMaster()
		{
			var all = await Api.LoadAllMasterAsync();
			CollegeMaster = all.College.Select(c => CollegeMasterData.Import(c)).ToArray();
			SubjectMaster = all.Subject.Select(s => SubjectMasterData.Import(s)).ToArray();
			Ready = true;
		}

		/// <summary>
		/// 学園マスタを取得します。
		/// </summary>
		public static IReadOnlyCollection<CollegeMasterData> CollegeMaster
		{
			get;
			private set;
		}

		/// <summary>
		/// 講義マスタを取得します。
		/// </summary>
		public static IReadOnlyCollection<SubjectMasterData> SubjectMaster
		{
			get;
			private set;
		}

		/// <summary>
		/// 準備が完了したかどうかを取得します。
		/// </summary>
		public static bool Ready
		{
			get;
			private set;
		}
	}
}
