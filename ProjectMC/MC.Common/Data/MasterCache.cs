using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using MC.Common.Data.Serializable;

namespace MC.Common.Data
{
	/// <summary>
	/// マスタ データのクライアント側キャッシュ。
	/// </summary>
	public static class MasterCache
	{
		/// <summary>
		/// すべてのマスタを読み込みます。
		/// </summary>
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static async void DownloadAllMaster(Func<Task<AllMaster>> getMasterAsync)
		{
			var all = await getMasterAsync();
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
