using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MC.Common.Data;
using MC.Common.Data.Serializable;
using MC.MockServer.Res.Properties;

namespace MC.MockServer
{
	/// <summary>
	/// マスタ データのストア。
	/// </summary>
	sealed class MasterStore
	{
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		private MasterStore()
		{
			Setup();
		}

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static MasterStore Instance
		{
			get;
		}
		= new MasterStore();

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

		/// <summary>
		/// マスタ全件をエクスポートします。
		/// </summary>
		/// <returns>マスタ全件。</returns>
		public AllMaster Export() =>
			new AllMaster()
			{
				College = CollegeMaster.Select(c => c.Export()).ToArray(),
				Subject = SubjectMaster.Select(s => s.Export()).ToArray(),
			};

		/// <summary>
		/// データを構築します。
		/// </summary>
		[SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode")]
		[SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals")]
		private void Setup()
		{
			var id = 0;
			var emptySubject = new List<SubjectMasterData>().AsReadOnly();
			var c = new CollegeMasterData[24];
			c[0] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_01_NAME, description: Resources.COLLEGE_01_DESCRIPTION, enabled: true, full: true, requires: emptySubject);
			var s0101 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_001, description: Resources.SUBJECT_DESCRIPTION_01_001, enabled: true, full: true, college: c[0], requires: emptySubject);
			var s0102 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_002, description: Resources.SUBJECT_DESCRIPTION_01_002, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0101 });
			var s0103 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_003, description: Resources.SUBJECT_DESCRIPTION_01_003, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0101 });
			var s0104 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_004, description: Resources.SUBJECT_DESCRIPTION_01_004, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0102 });
			var s0105 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_005, description: Resources.SUBJECT_DESCRIPTION_01_005, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0102 });
			var s0106 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_006, description: Resources.SUBJECT_DESCRIPTION_01_006, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0105 });
			var s0107 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_007, description: Resources.SUBJECT_DESCRIPTION_01_007, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0102 });
			var s0108 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_008, description: Resources.SUBJECT_DESCRIPTION_01_008, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0107 });
			var s0109 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_009, description: Resources.SUBJECT_DESCRIPTION_01_009, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0101 });
			var s0110 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_010, description: Resources.SUBJECT_DESCRIPTION_01_010, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0109 });
			var s0111 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_011, description: Resources.SUBJECT_DESCRIPTION_01_011, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0110 });
			var s0112 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_012, description: Resources.SUBJECT_DESCRIPTION_01_012, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0109, s0106 });
			var s0113 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_013, description: Resources.SUBJECT_DESCRIPTION_01_013, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0109, s0108 });
			var s0114 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_014, description: Resources.SUBJECT_DESCRIPTION_01_014, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0112, s0113 });
			var s0115 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_015, description: Resources.SUBJECT_DESCRIPTION_01_015, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0106, s0111 });
			var s0116 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_016, description: Resources.SUBJECT_DESCRIPTION_01_016, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0112, s0115 });
			var s0117 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_017, description: Resources.SUBJECT_DESCRIPTION_01_017, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0111, s0108 });
			var s0118 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_018, description: Resources.SUBJECT_DESCRIPTION_01_018, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0113, s0117 });
			var s0119 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_019, description: Resources.SUBJECT_DESCRIPTION_01_019, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0110, s0111 });
			var s0120 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_020, description: Resources.SUBJECT_DESCRIPTION_01_020, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0119 });
			var s0121 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_021, description: Resources.SUBJECT_DESCRIPTION_01_021, enabled: true, full: true, college: c[0], requires: new SubjectMasterData[] { s0120 });

			c[1] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_02_NAME, description: Resources.COLLEGE_02_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0104, s0114, s0116, s0118, s0119 });
			var s0201 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_001, description: Resources.SUBJECT_DESCRIPTION_02_001, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0116 });
			var s0202 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_002, description: Resources.SUBJECT_DESCRIPTION_02_002, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0104, s0201 });
			var s0203 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_003, description: Resources.SUBJECT_DESCRIPTION_02_003, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0201 });
			var s0204 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_004, description: Resources.SUBJECT_DESCRIPTION_02_004, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0203 });
			var s0205 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_005, description: Resources.SUBJECT_DESCRIPTION_02_005, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0201 });
			var s0206 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_006, description: Resources.SUBJECT_DESCRIPTION_02_006, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0104, s0205 });
			var s0207 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_007, description: Resources.SUBJECT_DESCRIPTION_02_007, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0205 });
			var s0208 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_008, description: Resources.SUBJECT_DESCRIPTION_02_008, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0207 });
			var s0209 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_009, description: Resources.SUBJECT_DESCRIPTION_02_009, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0201, s0205, s0114 });
			var s0210 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_010, description: Resources.SUBJECT_DESCRIPTION_02_010, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0209 });
			var s0211 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_011, description: Resources.SUBJECT_DESCRIPTION_02_011, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0210 });
			var s0212 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_012, description: Resources.SUBJECT_DESCRIPTION_02_012, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0114, s0116 });
			var s0213 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_013, description: Resources.SUBJECT_DESCRIPTION_02_013, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0212, s0119 });
			var s0214 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_014, description: Resources.SUBJECT_DESCRIPTION_02_014, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0213, s0111 });
			var s0215 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_015, description: Resources.SUBJECT_DESCRIPTION_02_015, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0114, s0118 });
			var s0216 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_016, description: Resources.SUBJECT_DESCRIPTION_02_016, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0215, s0119 });
			var s0217 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_017, description: Resources.SUBJECT_DESCRIPTION_02_017, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0216, s0111 });
			var s0218 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_018, description: Resources.SUBJECT_DESCRIPTION_02_018, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0204 });
			var s0219 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_019, description: Resources.SUBJECT_DESCRIPTION_02_019, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0218, s0119 });
			var s0220 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_020, description: Resources.SUBJECT_DESCRIPTION_02_020, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0219, s0213 });
			var s0221 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_021, description: Resources.SUBJECT_DESCRIPTION_02_021, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0205 });
			var s0222 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_022, description: Resources.SUBJECT_DESCRIPTION_02_022, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0221 });
			var s0223 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_023, description: Resources.SUBJECT_DESCRIPTION_02_023, enabled: true, full: true, college: c[1], requires: new SubjectMasterData[] { s0222 });

			c[2] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_03_NAME, description: Resources.COLLEGE_03_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0102 });
			var s0301 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_001, description: Resources.SUBJECT_DESCRIPTION_03_001, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0102 });
			var s0302 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_002, description: Resources.SUBJECT_DESCRIPTION_03_002, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0301 });
			var s0303 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_003, description: Resources.SUBJECT_DESCRIPTION_03_003, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0301 });
			var s0304 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_004, description: Resources.SUBJECT_DESCRIPTION_03_004, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0303 });
			var s0305 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_005, description: Resources.SUBJECT_DESCRIPTION_03_005, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0304 });
			var s0306 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_006, description: Resources.SUBJECT_DESCRIPTION_03_006, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0307 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_007, description: Resources.SUBJECT_DESCRIPTION_03_007, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0302, s0304 });
			var s0308 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_008, description: Resources.SUBJECT_DESCRIPTION_03_008, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0309 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_009, description: Resources.SUBJECT_DESCRIPTION_03_009, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0308, s0303 });
			var s0310 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_010, description: Resources.SUBJECT_DESCRIPTION_03_010, enabled: true, full: true, college: c[2], requires: emptySubject);
			var s0311 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_011, description: Resources.SUBJECT_DESCRIPTION_03_011, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0310 });
			var s0312 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_012, description: Resources.SUBJECT_DESCRIPTION_03_012, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0311 });
			var s0313 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_013, description: Resources.SUBJECT_DESCRIPTION_03_013, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0310 });
			var s0314 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_014, description: Resources.SUBJECT_DESCRIPTION_03_014, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0315 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_015, description: Resources.SUBJECT_DESCRIPTION_03_015, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0314 });
			var s0316 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_016, description: Resources.SUBJECT_DESCRIPTION_03_016, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0314, s0304 });
			var s0317 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_017, description: Resources.SUBJECT_DESCRIPTION_03_017, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0307, s0315 });
			var s0318 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_018, description: Resources.SUBJECT_DESCRIPTION_03_018, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0319 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_019, description: Resources.SUBJECT_DESCRIPTION_03_019, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0307, s0318 });
			var s0320 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_020, description: Resources.SUBJECT_DESCRIPTION_03_020, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0319 });
			var s0321 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_021, description: Resources.SUBJECT_DESCRIPTION_03_021, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0320 });
			var s0322 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_022, description: Resources.SUBJECT_DESCRIPTION_03_022, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0319, s0309 });
			var s0323 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_023, description: Resources.SUBJECT_DESCRIPTION_03_023, enabled: true, full: true, college: c[2], requires: new SubjectMasterData[] { s0318 });

			c[4] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_05_NAME, description: Resources.COLLEGE_05_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0220, s0223 });
			var s0501 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_001, description: Resources.SUBJECT_DESCRIPTION_05_001, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0221 });
			var s0502 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_002, description: Resources.SUBJECT_DESCRIPTION_05_002, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0501 });
			var s0503 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_003, description: Resources.SUBJECT_DESCRIPTION_05_003, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0502 });
			var s0504 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_004, description: Resources.SUBJECT_DESCRIPTION_05_004, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0205, s0203 });
			var s0505 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_005, description: Resources.SUBJECT_DESCRIPTION_05_005, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0504 });
			var s0506 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_006, description: Resources.SUBJECT_DESCRIPTION_05_006, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0504 });
			var s0507 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_007, description: Resources.SUBJECT_DESCRIPTION_05_007, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0506 });
			var s0508 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_008, description: Resources.SUBJECT_DESCRIPTION_05_008, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0504 });
			var s0509 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_009, description: Resources.SUBJECT_DESCRIPTION_05_009, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0503 });
			var s0510 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_010, description: Resources.SUBJECT_DESCRIPTION_05_010, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0503 });
			var s0511 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_011, description: Resources.SUBJECT_DESCRIPTION_05_011, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0510 });
			var s0512 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_012, description: Resources.SUBJECT_DESCRIPTION_05_012, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0511 });
			var s0513 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_013, description: Resources.SUBJECT_DESCRIPTION_05_013, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0111, s0503 });
			var s0514 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_014, description: Resources.SUBJECT_DESCRIPTION_05_014, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0513, s0212 });
			var s0515 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_015, description: Resources.SUBJECT_DESCRIPTION_05_015, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0514, s0218 });
			var s0516 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_016, description: Resources.SUBJECT_DESCRIPTION_05_016, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0515, s0220 });
			var s0517 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_017, description: Resources.SUBJECT_DESCRIPTION_05_017, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0515, s0222 });
			var s0518 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_018, description: Resources.SUBJECT_DESCRIPTION_05_018, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0517 });
			var s0519 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_019, description: Resources.SUBJECT_DESCRIPTION_05_019, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0517, s0223 });
			var s0520 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_020, description: Resources.SUBJECT_DESCRIPTION_05_020, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0107, s0104 });
			var s0521 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_021, description: Resources.SUBJECT_DESCRIPTION_05_021, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0520, s0106, s0108 });
			var s0522 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_022, description: Resources.SUBJECT_DESCRIPTION_05_022, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0521, s0203, s0205 });
			var s0523 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_023, description: Resources.SUBJECT_DESCRIPTION_05_023, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0520 });
			var s0524 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_024, description: Resources.SUBJECT_DESCRIPTION_05_024, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0513, s0502, s0520 });
			var s0525 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_025, description: Resources.SUBJECT_DESCRIPTION_05_025, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0506, s0502 });
			var s0526 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_026, description: Resources.SUBJECT_DESCRIPTION_05_026, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0525 });
			var s0527 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_027, description: Resources.SUBJECT_DESCRIPTION_05_027, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0526, s0510 });
			var s0528 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_028, description: Resources.SUBJECT_DESCRIPTION_05_028, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0518 });
			var s0529 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_029, description: Resources.SUBJECT_DESCRIPTION_05_029, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0109 });
			var s0530 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_030, description: Resources.SUBJECT_DESCRIPTION_05_030, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0529 });
			var s0531 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_031, description: Resources.SUBJECT_DESCRIPTION_05_031, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0529, s0525 });
			var s0532 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_032, description: Resources.SUBJECT_DESCRIPTION_05_032, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0531 });
			var s0533 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_05_033, description: Resources.SUBJECT_DESCRIPTION_05_033, enabled: true, full: true, college: c[4], requires: new SubjectMasterData[] { s0516, s0519, s0527, s0528 });

			c[3] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_04_NAME, description: Resources.COLLEGE_04_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0120, s0218, s0222, s0307 });
			var s0401 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_001, description: Resources.SUBJECT_DESCRIPTION_04_001, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0110 });
			var s0402 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_002, description: Resources.SUBJECT_DESCRIPTION_04_002, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0401, s0119 });
			var s0403 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_003, description: Resources.SUBJECT_DESCRIPTION_04_003, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0110, s0307 });
			var s0404 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_004, description: Resources.SUBJECT_DESCRIPTION_04_004, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0403, s0402, s0120 });
			var s0405 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_005, description: Resources.SUBJECT_DESCRIPTION_04_005, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0119 });
			var s0406 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_006, description: Resources.SUBJECT_DESCRIPTION_04_006, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0405 });
			var s0407 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_007, description: Resources.SUBJECT_DESCRIPTION_04_007, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0110 });
			var s0408 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_008, description: Resources.SUBJECT_DESCRIPTION_04_008, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0407 });
			var s0409 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_009, description: Resources.SUBJECT_DESCRIPTION_04_009, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0110 });
			var s0410 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_010, description: Resources.SUBJECT_DESCRIPTION_04_010, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0409, s0120 });
			var s0411 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_011, description: Resources.SUBJECT_DESCRIPTION_04_011, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0222, s0402, s0404, s0410 });
			var s0412 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_012, description: Resources.SUBJECT_DESCRIPTION_04_012, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0408, s0411 });
			var s0413 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_013, description: Resources.SUBJECT_DESCRIPTION_04_013, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0304, s0119 });
			var s0414 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_014, description: Resources.SUBJECT_DESCRIPTION_04_014, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0413, s0301 });
			var s0415 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_015, description: Resources.SUBJECT_DESCRIPTION_04_015, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0413, s0308 });
			var s0416 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_016, description: Resources.SUBJECT_DESCRIPTION_04_016, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0307, s0404, s0201 });
			var s0417 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_017, description: Resources.SUBJECT_DESCRIPTION_04_017, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0404, s0305, s0221 });
			var s0418 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_018, description: Resources.SUBJECT_DESCRIPTION_04_018, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0417 });
			var s0419 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_019, description: Resources.SUBJECT_DESCRIPTION_04_019, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0416, s0317 });
			var s0420 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_020, description: Resources.SUBJECT_DESCRIPTION_04_020, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0419, s0210, s0222 });
			var s0421 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_021, description: Resources.SUBJECT_DESCRIPTION_04_021, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0419 });
			var s0422 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_022, description: Resources.SUBJECT_DESCRIPTION_04_022, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0311, s0515 });
			var s0423 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_023, description: Resources.SUBJECT_DESCRIPTION_04_023, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0416, s0422 });
			var s0424 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_024, description: Resources.SUBJECT_DESCRIPTION_04_024, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0423, s0312, s0413, s0525 });
			var s0425 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_025, description: Resources.SUBJECT_DESCRIPTION_04_025, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0423, s0313 });
			var s0426 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_026, description: Resources.SUBJECT_DESCRIPTION_04_026, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0405, s0110, s0319 });
			var s0427 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_027, description: Resources.SUBJECT_DESCRIPTION_04_027, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0426, s0120 });
			var s0428 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_028, description: Resources.SUBJECT_DESCRIPTION_04_028, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0427, s0319, s0416 });
			var s0429 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_029, description: Resources.SUBJECT_DESCRIPTION_04_029, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0320, s0428, s0423 });
			var s0430 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_030, description: Resources.SUBJECT_DESCRIPTION_04_030, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0429, s0321 });
			var s0431 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_031, description: Resources.SUBJECT_DESCRIPTION_04_031, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0313, s0428, s0423 });

			c[5] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_06_NAME, description: Resources.COLLEGE_06_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0306, s0311, s0315, s0316, s0317, s0321, s0413, s0531 });
			var s0601 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_001, description: Resources.SUBJECT_DESCRIPTION_06_001, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0319 });
			var s0602 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_002, description: Resources.SUBJECT_DESCRIPTION_06_002, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0320, s0601 });
			var s0603 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_003, description: Resources.SUBJECT_DESCRIPTION_06_003, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0321, s0602 });
			var s0604 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_004, description: Resources.SUBJECT_DESCRIPTION_06_004, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0311 });
			var s0605 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_005, description: Resources.SUBJECT_DESCRIPTION_06_005, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0604 });
			var s0606 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_006, description: Resources.SUBJECT_DESCRIPTION_06_006, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0314 });
			var s0607 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_007, description: Resources.SUBJECT_DESCRIPTION_06_007, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0606 });
			var s0608 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_008, description: Resources.SUBJECT_DESCRIPTION_06_008, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0413 });
			var s0609 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_009, description: Resources.SUBJECT_DESCRIPTION_06_009, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0315, s0316 });
			var s0610 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_010, description: Resources.SUBJECT_DESCRIPTION_06_010, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0607 });
			var s0611 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_011, description: Resources.SUBJECT_DESCRIPTION_06_011, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0610, s0608 });
			var s0612 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_012, description: Resources.SUBJECT_DESCRIPTION_06_012, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0608, s0306 });
			var s0613 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_013, description: Resources.SUBJECT_DESCRIPTION_06_013, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0609, s0317 });
			var s0614 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_014, description: Resources.SUBJECT_DESCRIPTION_06_014, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0609, s0311 });
			var s0615 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_015, description: Resources.SUBJECT_DESCRIPTION_06_015, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0609, s0315 });
			var s0616 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_016, description: Resources.SUBJECT_DESCRIPTION_06_016, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0610 });
			var s0617 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_017, description: Resources.SUBJECT_DESCRIPTION_06_017, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0616, s0611, s0531 });
			var s0618 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_018, description: Resources.SUBJECT_DESCRIPTION_06_018, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0617, s0615 });
			var s0619 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_019, description: Resources.SUBJECT_DESCRIPTION_06_019, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0529, s0314, s0401 });
			var s0620 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_06_020, description: Resources.SUBJECT_DESCRIPTION_06_020, enabled: true, full: true, college: c[5], requires: new SubjectMasterData[] { s0619 });

			var s0432 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_032, description: Resources.SUBJECT_DESCRIPTION_04_032, enabled: true, full: true, college: c[3], requires: new SubjectMasterData[] { s0616, s0404, s0427 });

			c[6] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_07_NAME, description: Resources.COLLEGE_07_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0121, s0222, s0502, s0513, s0520 });
			var s0701 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_001, description: Resources.SUBJECT_DESCRIPTION_07_001, enabled: true, full: true, college: c[6], requires: emptySubject);
			var s0702 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_002, description: Resources.SUBJECT_DESCRIPTION_07_002, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0701 });
			var s0703 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_003, description: Resources.SUBJECT_DESCRIPTION_07_003, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0702 });
			var s0704 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_004, description: Resources.SUBJECT_DESCRIPTION_07_004, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0701 });
			var s0705 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_005, description: Resources.SUBJECT_DESCRIPTION_07_005, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0704 });
			var s0706 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_006, description: Resources.SUBJECT_DESCRIPTION_07_006, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0513, s0531 });
			var s0707 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_007, description: Resources.SUBJECT_DESCRIPTION_07_007, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0706 });
			var s0708 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_008, description: Resources.SUBJECT_DESCRIPTION_07_008, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0707, s0704 });
			var s0709 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_009, description: Resources.SUBJECT_DESCRIPTION_07_009, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0520, s0513, s0502 });
			var s0710 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_010, description: Resources.SUBJECT_DESCRIPTION_07_010, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0701 });
			var s0711 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_011, description: Resources.SUBJECT_DESCRIPTION_07_011, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0710 });
			var s0712 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_012, description: Resources.SUBJECT_DESCRIPTION_07_012, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0109 });
			var s0713 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_013, description: Resources.SUBJECT_DESCRIPTION_07_013, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0712 });
			var s0714 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_014, description: Resources.SUBJECT_DESCRIPTION_07_014, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0712, s0706, s0502 });
			var s0715 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_015, description: Resources.SUBJECT_DESCRIPTION_07_015, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0121 });
			var s0716 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_07_016, description: Resources.SUBJECT_DESCRIPTION_07_016, enabled: true, full: true, college: c[6], requires: new SubjectMasterData[] { s0222 });

			c[7] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_08_NAME, description: Resources.COLLEGE_08_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0121, s0222, s0502, s0513, s0520 });
			var s0801 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_001, description: Resources.SUBJECT_DESCRIPTION_08_001, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0204 });
			var s0802 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_002, description: Resources.SUBJECT_DESCRIPTION_08_002, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0801 });
			var s0803 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_003, description: Resources.SUBJECT_DESCRIPTION_08_003, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0701, s0802 });
			var s0804 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_004, description: Resources.SUBJECT_DESCRIPTION_08_004, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0802 });
			var s0805 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_005, description: Resources.SUBJECT_DESCRIPTION_08_005, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0802, s0211 });
			var s0806 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_006, description: Resources.SUBJECT_DESCRIPTION_08_006, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0220 });
			var s0807 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_007, description: Resources.SUBJECT_DESCRIPTION_08_007, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0806 });
			var s0808 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_008, description: Resources.SUBJECT_DESCRIPTION_08_008, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0802, s0807 });
			var s0809 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_009, description: Resources.SUBJECT_DESCRIPTION_08_009, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0808, s0805 });
			var s0810 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_010, description: Resources.SUBJECT_DESCRIPTION_08_010, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0809 });
			var s0811 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_011, description: Resources.SUBJECT_DESCRIPTION_08_011, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0801, s0512, s0522 });
			var s0812 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_012, description: Resources.SUBJECT_DESCRIPTION_08_012, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0804, s0805 });
			var s0813 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_013, description: Resources.SUBJECT_DESCRIPTION_08_013, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0811, s0812 });
			var s0814 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_014, description: Resources.SUBJECT_DESCRIPTION_08_014, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0107 });
			var s0815 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_015, description: Resources.SUBJECT_DESCRIPTION_08_015, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0709, s0814 });
			var s0816 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_016, description: Resources.SUBJECT_DESCRIPTION_08_016, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0813, s0815 });
			var s0817 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_017, description: Resources.SUBJECT_DESCRIPTION_08_017, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0812, s0814 });
			var s0818 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_018, description: Resources.SUBJECT_DESCRIPTION_08_018, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0808, s0816, s0817 });
			var s0819 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_019, description: Resources.SUBJECT_DESCRIPTION_08_019, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0806 });
			var s0820 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_020, description: Resources.SUBJECT_DESCRIPTION_08_020, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0819, s0804 });
			var s0821 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_021, description: Resources.SUBJECT_DESCRIPTION_08_021, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0819 });
			var s0822 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_022, description: Resources.SUBJECT_DESCRIPTION_08_022, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0821 });
			var s0823 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_08_023, description: Resources.SUBJECT_DESCRIPTION_08_023, enabled: true, full: true, college: c[7], requires: new SubjectMasterData[] { s0810, s0821 });

			c[8] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_09_NAME, description: Resources.COLLEGE_09_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0709, s0803, s0816, s0818 });
			var s0901 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_001, description: Resources.SUBJECT_DESCRIPTION_09_001, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0709 });
			var s0902 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_002, description: Resources.SUBJECT_DESCRIPTION_09_002, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0803, s0901 });
			var s0903 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_003, description: Resources.SUBJECT_DESCRIPTION_09_003, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0902 });
			var s0904 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_004, description: Resources.SUBJECT_DESCRIPTION_09_004, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0819, s0808 });
			var s0905 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_005, description: Resources.SUBJECT_DESCRIPTION_09_005, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0819, s0901, s0904 });
			var s0906 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_006, description: Resources.SUBJECT_DESCRIPTION_09_006, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0801 });
			var s0907 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_007, description: Resources.SUBJECT_DESCRIPTION_09_007, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0813, s0906 });
			var s0908 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_008, description: Resources.SUBJECT_DESCRIPTION_09_008, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0816, s0523 });
			var s0909 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_009, description: Resources.SUBJECT_DESCRIPTION_09_009, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0818, s0908 });
			var s0910 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_010, description: Resources.SUBJECT_DESCRIPTION_09_010, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0810 });
			var s0911 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_011, description: Resources.SUBJECT_DESCRIPTION_09_011, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0805 });
			var s0912 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_012, description: Resources.SUBJECT_DESCRIPTION_09_012, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0809, s0911 });
			var s0913 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_013, description: Resources.SUBJECT_DESCRIPTION_09_013, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0912 });
			var s0914 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_014, description: Resources.SUBJECT_DESCRIPTION_09_014, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0913 });
			var s0915 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_015, description: Resources.SUBJECT_DESCRIPTION_09_015, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0914 });
			var s0916 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_016, description: Resources.SUBJECT_DESCRIPTION_09_016, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0903 });
			var s0917 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_017, description: Resources.SUBJECT_DESCRIPTION_09_017, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0903 });
			var s0918 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_018, description: Resources.SUBJECT_DESCRIPTION_09_018, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0815, s0916, s0917 });
			var s0919 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_019, description: Resources.SUBJECT_DESCRIPTION_09_019, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0917 });
			var s0920 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_020, description: Resources.SUBJECT_DESCRIPTION_09_020, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0917 });
			var s0921 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_021, description: Resources.SUBJECT_DESCRIPTION_09_021, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0903, s0907 });
			var s0922 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_022, description: Resources.SUBJECT_DESCRIPTION_09_022, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0903, s0907 });
			var s0923 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_09_023, description: Resources.SUBJECT_DESCRIPTION_09_023, enabled: true, full: true, college: c[8], requires: new SubjectMasterData[] { s0818, s0907 });

			c[9] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_10_NAME, description: Resources.COLLEGE_10_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0808, s0816, s0822, s0914, s0916 });
			var s1001 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_001, description: Resources.SUBJECT_DESCRIPTION_10_001, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s0808, s0816 });
			var s1002 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_002, description: Resources.SUBJECT_DESCRIPTION_10_002, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1001 });
			var s1003 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_003, description: Resources.SUBJECT_DESCRIPTION_10_003, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1002 });
			var s1004 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_004, description: Resources.SUBJECT_DESCRIPTION_10_004, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1003, s0810 });
			var s1005 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_005, description: Resources.SUBJECT_DESCRIPTION_10_005, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1004, s0822 });
			var s1006 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_006, description: Resources.SUBJECT_DESCRIPTION_10_006, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1005 });
			var s1007 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_007, description: Resources.SUBJECT_DESCRIPTION_10_007, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1005, s0916 });
			var s1008 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_008, description: Resources.SUBJECT_DESCRIPTION_10_008, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1002, s0914, s1007 });
			var s1009 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_009, description: Resources.SUBJECT_DESCRIPTION_10_009, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s0815, s1004, s1008 });
			var s1010 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_010, description: Resources.SUBJECT_DESCRIPTION_10_010, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1003 });
			var s1011 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_011, description: Resources.SUBJECT_DESCRIPTION_10_011, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1003, s1004 });
			var s1012 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_012, description: Resources.SUBJECT_DESCRIPTION_10_012, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s0815, s1011 });
			var s1013 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_013, description: Resources.SUBJECT_DESCRIPTION_10_013, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1012 });
			var s1014 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_014, description: Resources.SUBJECT_DESCRIPTION_10_014, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s0815, s1007, s1008 });
			var s1015 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_015, description: Resources.SUBJECT_DESCRIPTION_10_015, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s1001 });
			var s1016 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_10_016, description: Resources.SUBJECT_DESCRIPTION_10_016, enabled: true, full: true, college: c[9], requires: new SubjectMasterData[] { s0911 });

			c[10] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_11_NAME, description: Resources.COLLEGE_11_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0413, s0422, s0818, s0902, s0904 });
			var s1101 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_001, description: Resources.SUBJECT_DESCRIPTION_11_001, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0808, s0413 });
			var s1102 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_002, description: Resources.SUBJECT_DESCRIPTION_11_002, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1101, s0904 });
			var s1103 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_003, description: Resources.SUBJECT_DESCRIPTION_11_003, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1101, s0904 });
			var s1104 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_004, description: Resources.SUBJECT_DESCRIPTION_11_004, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0901, s1101 });
			var s1105 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_005, description: Resources.SUBJECT_DESCRIPTION_11_005, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0413 });
			var s1106 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_006, description: Resources.SUBJECT_DESCRIPTION_11_006, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1105, s1104 });
			var s1107 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_007, description: Resources.SUBJECT_DESCRIPTION_11_007, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1106 });
			var s1108 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_008, description: Resources.SUBJECT_DESCRIPTION_11_008, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1107 });
			var s1109 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_009, description: Resources.SUBJECT_DESCRIPTION_11_009, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0813, s1106 });
			var s1110 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_010, description: Resources.SUBJECT_DESCRIPTION_11_010, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0819, s0813, s1005, s1106 });
			var s1111 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_011, description: Resources.SUBJECT_DESCRIPTION_11_011, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0413, s0422 });
			var s1112 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_012, description: Resources.SUBJECT_DESCRIPTION_11_012, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1102, s1106, s1111 });
			var s1113 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_013, description: Resources.SUBJECT_DESCRIPTION_11_013, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1112 });
			var s1114 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_014, description: Resources.SUBJECT_DESCRIPTION_11_014, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0813, s1104, s1112 });
			var s1115 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_015, description: Resources.SUBJECT_DESCRIPTION_11_015, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0818, s1104, s1114 });
			var s1116 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_016, description: Resources.SUBJECT_DESCRIPTION_11_016, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s0902, s1106, s1111 });
			var s1117 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_017, description: Resources.SUBJECT_DESCRIPTION_11_017, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1116 });
			var s1118 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_11_018, description: Resources.SUBJECT_DESCRIPTION_11_018, enabled: true, full: true, college: c[10], requires: new SubjectMasterData[] { s1116 });

			c[11] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_12_NAME, description: Resources.COLLEGE_12_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0808, s0815 });
			var s1201 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_001, description: Resources.SUBJECT_DESCRIPTION_12_001, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s0808 });
			var s1202 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_002, description: Resources.SUBJECT_DESCRIPTION_12_002, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1201 });
			var s1203 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_003, description: Resources.SUBJECT_DESCRIPTION_12_003, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s0815, s1201 });
			var s1204 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_004, description: Resources.SUBJECT_DESCRIPTION_12_004, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s0815, s1201 });
			var s1205 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_005, description: Resources.SUBJECT_DESCRIPTION_12_005, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1201 });
			var s1206 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_006, description: Resources.SUBJECT_DESCRIPTION_12_006, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s0815, s1204, s1203 });
			var s1207 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_007, description: Resources.SUBJECT_DESCRIPTION_12_007, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1204, s1205 });
			var s1208 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_008, description: Resources.SUBJECT_DESCRIPTION_12_008, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1207 });
			var s1209 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_009, description: Resources.SUBJECT_DESCRIPTION_12_009, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1204, s1208 });
			var s1210 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_010, description: Resources.SUBJECT_DESCRIPTION_12_010, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1208 });
			var s1211 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_011, description: Resources.SUBJECT_DESCRIPTION_12_011, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1210 });
			var s1212 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_012, description: Resources.SUBJECT_DESCRIPTION_12_012, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1210, s1209 });
			var s1213 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_12_013, description: Resources.SUBJECT_DESCRIPTION_12_013, enabled: true, full: true, college: c[11], requires: new SubjectMasterData[] { s1212 });

			c[12] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_13_NAME, description: Resources.COLLEGE_13_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0712, s0714, s0808, s1206 });
			var s1301 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_001, description: Resources.SUBJECT_DESCRIPTION_13_001, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s0220 });
			var s1302 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_002, description: Resources.SUBJECT_DESCRIPTION_13_002, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s0712 });
			var s1303 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_003, description: Resources.SUBJECT_DESCRIPTION_13_003, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s0712 });
			var s1304 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_004, description: Resources.SUBJECT_DESCRIPTION_13_004, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1204, s0712 });
			var s1305 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_005, description: Resources.SUBJECT_DESCRIPTION_13_005, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1206, s0712, s1302 });
			var s1306 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_006, description: Resources.SUBJECT_DESCRIPTION_13_006, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s0808, s1303, s1301 });
			var s1307 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_007, description: Resources.SUBJECT_DESCRIPTION_13_007, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1306 });
			var s1308 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_008, description: Resources.SUBJECT_DESCRIPTION_13_008, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1306 });
			var s1309 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_009, description: Resources.SUBJECT_DESCRIPTION_13_009, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1306 });
			var s1310 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_010, description: Resources.SUBJECT_DESCRIPTION_13_010, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1303, s0714 });
			var s1311 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_011, description: Resources.SUBJECT_DESCRIPTION_13_011, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1304, s0714 });
			var s1312 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_012, description: Resources.SUBJECT_DESCRIPTION_13_012, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1302, s0714 });
			var s1313 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_013, description: Resources.SUBJECT_DESCRIPTION_13_013, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1305, s0714 });
			var s1314 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_014, description: Resources.SUBJECT_DESCRIPTION_13_014, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s0806, s1309, s1308, s1310, s1312, s1311 });
			var s1315 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_015, description: Resources.SUBJECT_DESCRIPTION_13_015, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s0714 });
			var s1316 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_13_016, description: Resources.SUBJECT_DESCRIPTION_13_016, enabled: true, full: true, college: c[12], requires: new SubjectMasterData[] { s1206, s0714 });

			c[13] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_14_NAME, description: Resources.COLLEGE_14_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0818, s0902 });
			var s1401 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_001, description: Resources.SUBJECT_DESCRIPTION_14_001, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0807 });
			var s1402 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_002, description: Resources.SUBJECT_DESCRIPTION_14_002, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0819 });
			var s1403 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_003, description: Resources.SUBJECT_DESCRIPTION_14_003, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s1401, s1402 });
			var s1404 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_004, description: Resources.SUBJECT_DESCRIPTION_14_004, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0807 });
			var s1405 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_005, description: Resources.SUBJECT_DESCRIPTION_14_005, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0902, s1404, s1403 });
			var s1406 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_006, description: Resources.SUBJECT_DESCRIPTION_14_006, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0818, s1403, s1405 });
			var s1407 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_007, description: Resources.SUBJECT_DESCRIPTION_14_007, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0813, s1404, s1403 });
			var s1408 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_008, description: Resources.SUBJECT_DESCRIPTION_14_008, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s1404, s1403 });
			var s1409 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_009, description: Resources.SUBJECT_DESCRIPTION_14_009, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s1408 });
			var s1410 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_010, description: Resources.SUBJECT_DESCRIPTION_14_010, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s1409 });
			var s1411 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_011, description: Resources.SUBJECT_DESCRIPTION_14_011, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s1408 });
			var s1412 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_012, description: Resources.SUBJECT_DESCRIPTION_14_012, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s1005, s1409, s1411 });
			var s1413 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_013, description: Resources.SUBJECT_DESCRIPTION_14_013, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0902, s1408 });
			var s1414 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_14_014, description: Resources.SUBJECT_DESCRIPTION_14_014, enabled: true, full: true, college: c[13], requires: new SubjectMasterData[] { s0818, s1413 });

			c[14] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_15_NAME, description: Resources.COLLEGE_15_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0802, s0901 });
			var s1501 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_001, description: Resources.SUBJECT_DESCRIPTION_15_001, enabled: true, full: true, college: c[14], requires: emptySubject);
			var s1502 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_002, description: Resources.SUBJECT_DESCRIPTION_15_002, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0901, s1501 });
			var s1503 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_003, description: Resources.SUBJECT_DESCRIPTION_15_003, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0802, s1501 });
			var s1504 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_004, description: Resources.SUBJECT_DESCRIPTION_15_004, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0901, s1501 });
			var s1505 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_005, description: Resources.SUBJECT_DESCRIPTION_15_005, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0901, s0619 });
			var s1506 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_006, description: Resources.SUBJECT_DESCRIPTION_15_006, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0619, s1505, s1504 });
			var s1507 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_007, description: Resources.SUBJECT_DESCRIPTION_15_007, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s1503, s1504 });
			var s1508 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_008, description: Resources.SUBJECT_DESCRIPTION_15_008, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s1503, s1502 });
			var s1509 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_009, description: Resources.SUBJECT_DESCRIPTION_15_009, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0905, s1502 });
			var s1510 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_010, description: Resources.SUBJECT_DESCRIPTION_15_010, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0901, s0620 });
			var s1511 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_011, description: Resources.SUBJECT_DESCRIPTION_15_011, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s1510, s1508 });
			var s1512 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_012, description: Resources.SUBJECT_DESCRIPTION_15_012, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s0530, s1508 });
			var s1513 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_013, description: Resources.SUBJECT_DESCRIPTION_15_013, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s1106, s1509 });
			var s1514 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_014, description: Resources.SUBJECT_DESCRIPTION_15_014, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s1508 });
			var s1515 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_15_015, description: Resources.SUBJECT_DESCRIPTION_15_015, enabled: true, full: true, college: c[14], requires: new SubjectMasterData[] { s1513, s1514 });

			c[15] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_16_NAME, description: Resources.COLLEGE_16_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0808, s0813, s0814, s0819, s0905, s0906 });
			var s1601 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_001, description: Resources.SUBJECT_DESCRIPTION_16_001, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0905 });
			var s1602 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_002, description: Resources.SUBJECT_DESCRIPTION_16_002, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s1601 });
			var s1603 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_003, description: Resources.SUBJECT_DESCRIPTION_16_003, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s1601 });
			var s1604 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_004, description: Resources.SUBJECT_DESCRIPTION_16_004, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s1601 });
			var s1605 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_005, description: Resources.SUBJECT_DESCRIPTION_16_005, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0903, s1601 });
			var s1606 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_006, description: Resources.SUBJECT_DESCRIPTION_16_006, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s1602, s1603, s1604, s1605 });
			var s1607 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_007, description: Resources.SUBJECT_DESCRIPTION_16_007, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0903, s0814 });
			var s1608 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_008, description: Resources.SUBJECT_DESCRIPTION_16_008, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0814, s1601 });
			var s1609 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_009, description: Resources.SUBJECT_DESCRIPTION_16_009, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0923, s1607, s1608 });
			var s1610 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_010, description: Resources.SUBJECT_DESCRIPTION_16_010, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s1010, s1117 });
			var s1611 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_011, description: Resources.SUBJECT_DESCRIPTION_16_011, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0902, s1610 });
			var s1612 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_012, description: Resources.SUBJECT_DESCRIPTION_16_012, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0819, s0902, s1610 });
			var s1613 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_013, description: Resources.SUBJECT_DESCRIPTION_16_013, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s1116, s1611, s1612 });
			var s1614 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_014, description: Resources.SUBJECT_DESCRIPTION_16_014, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0801, s0802 });
			var s1615 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_015, description: Resources.SUBJECT_DESCRIPTION_16_015, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0906, s1614 });
			var s1616 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_016, description: Resources.SUBJECT_DESCRIPTION_16_016, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0808, s0208 });
			var s1617 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_017, description: Resources.SUBJECT_DESCRIPTION_16_017, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0813, s0906 });
			var s1618 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_16_018, description: Resources.SUBJECT_DESCRIPTION_16_018, enabled: true, full: true, college: c[15], requires: new SubjectMasterData[] { s0901 });

			c[16] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_17_NAME, description: Resources.COLLEGE_17_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0809, s0820, s0822, s0901, s1113 });
			var s1701 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_001, description: Resources.SUBJECT_DESCRIPTION_17_001, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0822 });
			var s1702 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_002, description: Resources.SUBJECT_DESCRIPTION_17_002, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0820, s1701 });
			var s1703 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_003, description: Resources.SUBJECT_DESCRIPTION_17_003, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0809, s1702 });
			var s1704 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_004, description: Resources.SUBJECT_DESCRIPTION_17_004, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1701 });
			var s1705 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_005, description: Resources.SUBJECT_DESCRIPTION_17_005, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1005, s1701 });
			var s1706 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_006, description: Resources.SUBJECT_DESCRIPTION_17_006, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0819, s0422, s1701 });
			var s1707 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_007, description: Resources.SUBJECT_DESCRIPTION_17_007, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1701, s0901 });
			var s1708 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_008, description: Resources.SUBJECT_DESCRIPTION_17_008, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1106 });
			var s1709 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_009, description: Resources.SUBJECT_DESCRIPTION_17_009, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1708 });
			var s1710 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_010, description: Resources.SUBJECT_DESCRIPTION_17_010, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1707, s1708 });
			var s1711 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_011, description: Resources.SUBJECT_DESCRIPTION_17_011, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1710, s1113 });
			var s1712 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_012, description: Resources.SUBJECT_DESCRIPTION_17_012, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0109 });
			var s1713 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_013, description: Resources.SUBJECT_DESCRIPTION_17_013, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0802, s1712 });
			var s1714 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_014, description: Resources.SUBJECT_DESCRIPTION_17_014, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0802, s1712 });
			var s1715 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_015, description: Resources.SUBJECT_DESCRIPTION_17_015, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1713, s1714 });
			var s1716 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_016, description: Resources.SUBJECT_DESCRIPTION_17_016, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1714 });
			var s1717 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_017, description: Resources.SUBJECT_DESCRIPTION_17_017, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1714, s1715 });
			var s1718 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_018, description: Resources.SUBJECT_DESCRIPTION_17_018, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1717 });
			var s1719 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_019, description: Resources.SUBJECT_DESCRIPTION_17_019, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0907, s1714, s1718 });
			var s1720 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_020, description: Resources.SUBJECT_DESCRIPTION_17_020, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0808, s1714, s1715 });
			var s1721 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_021, description: Resources.SUBJECT_DESCRIPTION_17_021, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s0901, s1714 });
			var s1722 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_022, description: Resources.SUBJECT_DESCRIPTION_17_022, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1721 });
			var s1723 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_023, description: Resources.SUBJECT_DESCRIPTION_17_023, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1618, s1721 });
			var s1724 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_17_024, description: Resources.SUBJECT_DESCRIPTION_17_024, enabled: true, full: true, college: c[16], requires: new SubjectMasterData[] { s1106, s1723 });

			c[17] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_18_NAME, description: Resources.COLLEGE_18_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0823, s0919, s0920, s0922, s1116, s1405, s1413, s1611 });
			var s1801 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_001, description: Resources.SUBJECT_DESCRIPTION_18_001, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s0806 });
			var s1802 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_002, description: Resources.SUBJECT_DESCRIPTION_18_002, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1611 });
			var s1803 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_003, description: Resources.SUBJECT_DESCRIPTION_18_003, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1801, s1802 });
			var s1804 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_004, description: Resources.SUBJECT_DESCRIPTION_18_004, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1802 });
			var s1805 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_005, description: Resources.SUBJECT_DESCRIPTION_18_005, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1802 });
			var s1806 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_006, description: Resources.SUBJECT_DESCRIPTION_18_006, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s0823, s1802 });
			var s1807 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_007, description: Resources.SUBJECT_DESCRIPTION_18_007, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1802 });
			var s1808 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_008, description: Resources.SUBJECT_DESCRIPTION_18_008, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1807 });
			var s1809 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_009, description: Resources.SUBJECT_DESCRIPTION_18_009, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1015 });
			var s1810 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_010, description: Resources.SUBJECT_DESCRIPTION_18_010, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1807, s1809 });
			var s1811 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_011, description: Resources.SUBJECT_DESCRIPTION_18_011, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1805, s1810 });
			var s1812 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_012, description: Resources.SUBJECT_DESCRIPTION_18_012, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s0803, s1811 });
			var s1813 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_013, description: Resources.SUBJECT_DESCRIPTION_18_013, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1811 });
			var s1814 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_014, description: Resources.SUBJECT_DESCRIPTION_18_014, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1116, s1811 });
			var s1815 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_015, description: Resources.SUBJECT_DESCRIPTION_18_015, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1413, s1811 });
			var s1816 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_016, description: Resources.SUBJECT_DESCRIPTION_18_016, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1405, s1408, s1811 });
			var s1817 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_017, description: Resources.SUBJECT_DESCRIPTION_18_017, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s0919, s0920, s1811 });
			var s1818 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_018, description: Resources.SUBJECT_DESCRIPTION_18_018, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s0907, s1817 });
			var s1819 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_019, description: Resources.SUBJECT_DESCRIPTION_18_019, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1811 });
			var s1820 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_020, description: Resources.SUBJECT_DESCRIPTION_18_020, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1813 });
			var s1821 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_021, description: Resources.SUBJECT_DESCRIPTION_18_021, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s0902 });
			var s1822 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_022, description: Resources.SUBJECT_DESCRIPTION_18_022, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1813, s1821 });
			var s1823 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_023, description: Resources.SUBJECT_DESCRIPTION_18_023, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1615, s1813 });
			var s1824 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_024, description: Resources.SUBJECT_DESCRIPTION_18_024, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1823 });
			var s1825 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_18_025, description: Resources.SUBJECT_DESCRIPTION_18_025, enabled: true, full: true, college: c[17], requires: new SubjectMasterData[] { s1814, s1823 });

			c[18] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_19_NAME, description: Resources.COLLEGE_19_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0110, s0808, s0812, s1812, s1814, s1815, s1816, s1819, s1822 });
			var s1901 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_001, description: Resources.SUBJECT_DESCRIPTION_19_001, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s0110 });
			var s1902 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_002, description: Resources.SUBJECT_DESCRIPTION_19_002, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s0802, s1901 });
			var s1903 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_003, description: Resources.SUBJECT_DESCRIPTION_19_003, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1901 });
			var s1904 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_004, description: Resources.SUBJECT_DESCRIPTION_19_004, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s0812, s1901 });
			var s1905 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_005, description: Resources.SUBJECT_DESCRIPTION_19_005, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1902 });
			var s1906 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_006, description: Resources.SUBJECT_DESCRIPTION_19_006, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1905 });
			var s1907 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_007, description: Resources.SUBJECT_DESCRIPTION_19_007, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s0808, s1905 });
			var s1908 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_008, description: Resources.SUBJECT_DESCRIPTION_19_008, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1905 });
			var s1909 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_009, description: Resources.SUBJECT_DESCRIPTION_19_009, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1813 });
			var s1910 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_010, description: Resources.SUBJECT_DESCRIPTION_19_010, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1814, s1909 });
			var s1911 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_011, description: Resources.SUBJECT_DESCRIPTION_19_011, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1816, s1909 });
			var s1912 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_012, description: Resources.SUBJECT_DESCRIPTION_19_012, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1819, s1909 });
			var s1913 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_013, description: Resources.SUBJECT_DESCRIPTION_19_013, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1909 });
			var s1914 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_014, description: Resources.SUBJECT_DESCRIPTION_19_014, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1912, s1913 });
			var s1915 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_015, description: Resources.SUBJECT_DESCRIPTION_19_015, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1822, s1909 });
			var s1916 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_016, description: Resources.SUBJECT_DESCRIPTION_19_016, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1915, s1913 });
			var s1917 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_017, description: Resources.SUBJECT_DESCRIPTION_19_017, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1403, s1915 });
			var s1918 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_018, description: Resources.SUBJECT_DESCRIPTION_19_018, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1915 });
			var s1919 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_019, description: Resources.SUBJECT_DESCRIPTION_19_019, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s0914, s1918 });
			var s1920 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_020, description: Resources.SUBJECT_DESCRIPTION_19_020, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1915 });
			var s1921 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_021, description: Resources.SUBJECT_DESCRIPTION_19_021, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1913 });
			var s1922 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_19_022, description: Resources.SUBJECT_DESCRIPTION_19_022, enabled: true, full: true, college: c[18], requires: new SubjectMasterData[] { s1905, s1921 });

			c[19] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_20_NAME, description: Resources.COLLEGE_20_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s0705, s0708, s0714, s0716, s0819, s1913 });
			var s2001 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_001, description: Resources.SUBJECT_DESCRIPTION_20_001, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s0704, s0806 });
			var s2002 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_002, description: Resources.SUBJECT_DESCRIPTION_20_002, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s0716, s2001 });
			var s2003 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_003, description: Resources.SUBJECT_DESCRIPTION_20_003, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2001, s0819 });
			var s2004 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_004, description: Resources.SUBJECT_DESCRIPTION_20_004, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s0708, s0705 });
			var s2005 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_005, description: Resources.SUBJECT_DESCRIPTION_20_005, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s0708, s0714 });
			var s2006 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_006, description: Resources.SUBJECT_DESCRIPTION_20_006, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2005, s2004 });
			var s2007 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_007, description: Resources.SUBJECT_DESCRIPTION_20_007, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2006, s1315, s1913 });
			var s2008 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_008, description: Resources.SUBJECT_DESCRIPTION_20_008, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2007, s2001 });
			var s2009 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_009, description: Resources.SUBJECT_DESCRIPTION_20_009, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2006, s0716, s2001 });
			var s2010 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_010, description: Resources.SUBJECT_DESCRIPTION_20_010, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2009 });
			var s2011 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_011, description: Resources.SUBJECT_DESCRIPTION_20_011, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s1314, s0716, s2001 });
			var s2012 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_012, description: Resources.SUBJECT_DESCRIPTION_20_012, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2009 });
			var s2013 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_013, description: Resources.SUBJECT_DESCRIPTION_20_013, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2009 });
			var s2014 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_014, description: Resources.SUBJECT_DESCRIPTION_20_014, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2009 });
			var s2015 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_015, description: Resources.SUBJECT_DESCRIPTION_20_015, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2009, s0716, s2001 });
			var s2016 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_016, description: Resources.SUBJECT_DESCRIPTION_20_016, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2015, s2014 });
			var s2017 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_017, description: Resources.SUBJECT_DESCRIPTION_20_017, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2011, s2009, s2015 });
			var s2018 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_018, description: Resources.SUBJECT_DESCRIPTION_20_018, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2015, s2012 });
			var s2019 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_019, description: Resources.SUBJECT_DESCRIPTION_20_019, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2018 });
			var s2020 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_020, description: Resources.SUBJECT_DESCRIPTION_20_020, enabled: true, full: true, college: c[19], requires: emptySubject);
			var s2021 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_021, description: Resources.SUBJECT_DESCRIPTION_20_021, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2020, s2009 });
			var s2022 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_022, description: Resources.SUBJECT_DESCRIPTION_20_022, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2021, s2014 });
			var s2023 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_023, description: Resources.SUBJECT_DESCRIPTION_20_023, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2021, s2012 });
			var s2024 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_024, description: Resources.SUBJECT_DESCRIPTION_20_024, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2023 });
			var s2025 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_025, description: Resources.SUBJECT_DESCRIPTION_20_025, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2013, s2020 });
			var s2026 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_026, description: Resources.SUBJECT_DESCRIPTION_20_026, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2025, s2009 });
			var s2027 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_027, description: Resources.SUBJECT_DESCRIPTION_20_027, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2026, s2014 });
			var s2028 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_028, description: Resources.SUBJECT_DESCRIPTION_20_028, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2001 });
			var s2029 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_029, description: Resources.SUBJECT_DESCRIPTION_20_029, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2028 });
			var s2030 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_030, description: Resources.SUBJECT_DESCRIPTION_20_030, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2028 });
			var s2031 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_031, description: Resources.SUBJECT_DESCRIPTION_20_031, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2020, s2012 });
			var s2032 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_20_032, description: Resources.SUBJECT_DESCRIPTION_20_032, enabled: true, full: true, college: c[19], requires: new SubjectMasterData[] { s2031 });

			c[20] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_21_NAME, description: Resources.COLLEGE_21_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s1614, s1813, s1911, s1918, s1921 });
			var s2101 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_001, description: Resources.SUBJECT_DESCRIPTION_21_001, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1614 });
			var s2102 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_002, description: Resources.SUBJECT_DESCRIPTION_21_002, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1813, s1810, s2101 });
			var s2103 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_003, description: Resources.SUBJECT_DESCRIPTION_21_003, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2102 });
			var s2104 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_004, description: Resources.SUBJECT_DESCRIPTION_21_004, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2101, s1913 });
			var s2105 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_005, description: Resources.SUBJECT_DESCRIPTION_21_005, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2104 });
			var s2106 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_006, description: Resources.SUBJECT_DESCRIPTION_21_006, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1921 });
			var s2107 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_007, description: Resources.SUBJECT_DESCRIPTION_21_007, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2106 });
			var s2108 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_008, description: Resources.SUBJECT_DESCRIPTION_21_008, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1813 });
			var s2109 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_009, description: Resources.SUBJECT_DESCRIPTION_21_009, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1909 });
			var s2110 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_010, description: Resources.SUBJECT_DESCRIPTION_21_010, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1918, s2109 });
			var s2111 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_011, description: Resources.SUBJECT_DESCRIPTION_21_011, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2108, s2109 });
			var s2112 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_012, description: Resources.SUBJECT_DESCRIPTION_21_012, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2111 });
			var s2115 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_015, description: Resources.SUBJECT_DESCRIPTION_21_015, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s1914, s1911 });
			var s2116 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_016, description: Resources.SUBJECT_DESCRIPTION_21_016, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2115 });

			c[21] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_22_NAME, description: Resources.COLLEGE_22_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s1514, s2102, s2105, s2107, s2108 });
			var s2201 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_001, description: Resources.SUBJECT_DESCRIPTION_22_001, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s1102, s1501 });
			var s2202 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_002, description: Resources.SUBJECT_DESCRIPTION_22_002, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s1502, s2201 });
			var s2203 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_003, description: Resources.SUBJECT_DESCRIPTION_22_003, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2101 });
			var s2204 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_004, description: Resources.SUBJECT_DESCRIPTION_22_004, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2101, s1502 });
			var s2205 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_005, description: Resources.SUBJECT_DESCRIPTION_22_005, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2102, s2203, s2204 });
			var s2206 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_006, description: Resources.SUBJECT_DESCRIPTION_22_006, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2102, s2203, s2204 });
			var s2207 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_007, description: Resources.SUBJECT_DESCRIPTION_22_007, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2204, s2102 });
			var s2208 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_008, description: Resources.SUBJECT_DESCRIPTION_22_008, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2205, s2206, s2207, s2202, s1514 });
			var s2209 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_009, description: Resources.SUBJECT_DESCRIPTION_22_009, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2206, s2107, s2106 });
			var s2210 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_010, description: Resources.SUBJECT_DESCRIPTION_22_010, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2204, s2104, s1514 });
			var s2211 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_22_011, description: Resources.SUBJECT_DESCRIPTION_22_011, enabled: true, full: true, college: c[21], requires: new SubjectMasterData[] { s2207, s2106, s2105, s2210 });

			c[22] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_23_NAME, description: Resources.COLLEGE_23_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s1704, s1709, s1717 });
			var s2301 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_001, description: Resources.SUBJECT_DESCRIPTION_23_001, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s1712 });
			var s2302 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_002, description: Resources.SUBJECT_DESCRIPTION_23_002, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2301 });
			var s2303 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_003, description: Resources.SUBJECT_DESCRIPTION_23_003, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s1712 });
			var s2304 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_004, description: Resources.SUBJECT_DESCRIPTION_23_004, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2303 });
			var s2305 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_005, description: Resources.SUBJECT_DESCRIPTION_23_005, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2304 });
			var s2306 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_006, description: Resources.SUBJECT_DESCRIPTION_23_006, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2302, s1714, s2303 });
			var s2307 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_007, description: Resources.SUBJECT_DESCRIPTION_23_007, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2303, s1714 });
			var s2308 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_008, description: Resources.SUBJECT_DESCRIPTION_23_008, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2303 });
			var s2309 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_009, description: Resources.SUBJECT_DESCRIPTION_23_009, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2303 });
			var s2310 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_010, description: Resources.SUBJECT_DESCRIPTION_23_010, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2106, s2304 });
			var s2311 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_011, description: Resources.SUBJECT_DESCRIPTION_23_011, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2107, s2305 });
			var s2312 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_012, description: Resources.SUBJECT_DESCRIPTION_23_012, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2304 });
			var s2313 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_013, description: Resources.SUBJECT_DESCRIPTION_23_013, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2312, s2305 });
			var s2314 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_014, description: Resources.SUBJECT_DESCRIPTION_23_014, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2312, s1717 });
			var s2315 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_015, description: Resources.SUBJECT_DESCRIPTION_23_015, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s1502, s1714 });
			var s2316 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_016, description: Resources.SUBJECT_DESCRIPTION_23_016, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2315, s2304 });

			c[23] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_24_NAME, description: Resources.COLLEGE_24_DESCRIPTION, enabled: true, full: true, requires: new SubjectMasterData[] { s1614, s1703, s1704, s1711, s1812, s2102, s2105, s2106, s1911 });
			var s2401 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_001, description: Resources.SUBJECT_DESCRIPTION_24_001, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s1711, s0807, s1703 });
			var s2402 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_002, description: Resources.SUBJECT_DESCRIPTION_24_002, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s1614, s1703 });
			var s2403 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_003, description: Resources.SUBJECT_DESCRIPTION_24_003, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s1811, s2102, s2402 });
			var s2404 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_004, description: Resources.SUBJECT_DESCRIPTION_24_004, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2402, s2104 });
			var s2405 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_005, description: Resources.SUBJECT_DESCRIPTION_24_005, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2404, s2105, s2403 });
			var s2406 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_006, description: Resources.SUBJECT_DESCRIPTION_24_006, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2404, s2105 });
			var s2407 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_007, description: Resources.SUBJECT_DESCRIPTION_24_007, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2406, s2108 });
			var s2408 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_008, description: Resources.SUBJECT_DESCRIPTION_24_008, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2407, s1908, s2403 });
			var s2409 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_009, description: Resources.SUBJECT_DESCRIPTION_24_009, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2408, s2407 });
			var s2410 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_010, description: Resources.SUBJECT_DESCRIPTION_24_010, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2409 });
			var s2411 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_011, description: Resources.SUBJECT_DESCRIPTION_24_011, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2410 });
			var s2412 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_012, description: Resources.SUBJECT_DESCRIPTION_24_012, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2409 });
			var s2413 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_013, description: Resources.SUBJECT_DESCRIPTION_24_013, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2412, s2410 });
			var s2414 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_014, description: Resources.SUBJECT_DESCRIPTION_24_014, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2102, s1812 });
			var s2415 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_015, description: Resources.SUBJECT_DESCRIPTION_24_015, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s1704, s1514 });
			var s2416 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_016, description: Resources.SUBJECT_DESCRIPTION_24_016, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s1913, s1910 });
			var s2417 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_017, description: Resources.SUBJECT_DESCRIPTION_24_017, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2416 });
			var s2418 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_018, description: Resources.SUBJECT_DESCRIPTION_24_018, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2415 });
			var s2420 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_020, description: Resources.SUBJECT_DESCRIPTION_24_020, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s1614, s2101 });
			var s2421 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_021, description: Resources.SUBJECT_DESCRIPTION_24_021, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2420, s2102 });

			var s2113 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_013, description: Resources.SUBJECT_DESCRIPTION_21_013, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2111, s2401 });
			var s2318 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_018, description: Resources.SUBJECT_DESCRIPTION_23_018, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2415 });
			var s2317 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_017, description: Resources.SUBJECT_DESCRIPTION_23_017, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s1704, s2302 });
			var s2319 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_019, description: Resources.SUBJECT_DESCRIPTION_23_019, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2318, s2302, s2317 });
			var s2320 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_23_020, description: Resources.SUBJECT_DESCRIPTION_23_020, enabled: true, full: true, college: c[22], requires: new SubjectMasterData[] { s2317, s2315 });
			var s2114 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_014, description: Resources.SUBJECT_DESCRIPTION_21_014, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2111, s2112, s2113 });
			var s2117 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_21_017, description: Resources.SUBJECT_DESCRIPTION_21_017, enabled: true, full: true, college: c[20], requires: new SubjectMasterData[] { s2116, s2114 });
			var s2419 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_24_019, description: Resources.SUBJECT_DESCRIPTION_24_019, enabled: true, full: true, college: c[23], requires: new SubjectMasterData[] { s2318, s2418 });

			CollegeMaster = c.OrderBy(x => x.CollegeId).ToArray();
			SubjectMaster =
				new SubjectMasterData[]
				{
					s0101, s0102, s0103, s0104, s0105, s0106, s0107, s0108, s0109, s0110,
					s0111, s0112, s0113, s0114, s0115, s0116, s0117, s0118, s0119, s0120,
					s0121,
					s0201, s0202, s0203, s0204, s0205, s0206, s0207, s0208, s0209, s0210,
					s0211, s0212, s0213, s0214, s0215, s0216, s0217, s0218, s0219, s0220,
					s0221, s0222, s0223,
					s0301, s0302, s0303, s0304, s0305, s0306, s0307, s0308, s0309, s0310,
					s0311, s0312, s0313, s0314, s0315, s0316, s0317, s0318, s0319, s0320,
					s0321, s0322, s0323,
					s0401, s0402, s0403, s0404, s0405, s0406, s0407, s0408, s0409, s0410,
					s0411, s0412, s0413, s0414, s0415, s0416, s0417, s0418, s0419, s0420,
					s0421, s0422, s0423, s0424, s0425, s0426, s0427, s0428, s0429, s0430,
					s0431, s0432,
					s0501, s0502, s0503, s0504, s0505, s0506, s0507, s0508, s0509, s0510,
					s0511, s0512, s0513, s0514, s0515, s0516, s0517, s0518, s0519, s0520,
					s0521, s0522, s0523, s0524, s0525, s0526, s0527, s0528, s0529, s0530,
					s0531, s0532, s0533,
					s0601, s0602, s0603, s0604, s0605, s0606, s0607, s0608, s0609, s0610,
					s0611, s0612, s0613, s0614, s0615, s0616, s0617, s0618, s0619, s0620,
					s0701, s0702, s0703, s0704, s0705, s0706, s0707, s0708, s0709, s0710,
					s0711, s0712, s0713, s0714, s0715, s0716,
					s0801, s0802, s0803, s0804, s0805, s0806, s0807, s0808, s0809, s0810,
					s0811, s0812, s0813, s0814, s0815, s0816, s0817, s0818, s0819, s0820,
					s0821, s0822, s0823,
					s0901, s0902, s0903, s0904, s0905, s0906, s0907, s0908, s0909, s0910,
					s0911, s0912, s0913, s0914, s0915, s0916, s0917, s0918, s0919, s0920,
					s0921, s0922, s0923,
					s1001, s1002, s1003, s1004, s1005, s1006, s1007, s1008, s1009, s1010,
					s1011, s1012, s1013, s1014, s1015, s1016,
					s1101, s1102, s1103, s1104, s1105, s1106, s1107, s1108, s1109, s1110,
					s1111, s1112, s1113, s1114, s1115, s1116, s1117, s1118,
					s1201, s1202, s1203, s1204, s1205, s1206, s1207, s1208, s1209, s1210,
					s1211, s1212, s1213,
					s1301, s1302, s1303, s1304, s1305, s1306, s1307, s1308, s1309, s1310,
					s1311, s1312, s1313, s1314, s1315, s1316,
					s1401, s1402, s1403, s1404, s1405, s1406, s1407, s1408, s1409, s1410,
					s1411, s1412, s1413, s1414,
					s1501, s1502, s1503, s1504, s1505, s1506, s1507, s1508, s1509, s1510,
					s1511, s1512, s1513, s1514, s1515,
					s1601, s1602, s1603, s1604, s1605, s1606, s1607, s1608, s1609, s1610,
					s1611, s1612, s1613, s1614, s1615, s1616, s1617, s1618,
					s1701, s1702, s1703, s1704, s1705, s1706, s1707, s1708, s1709, s1710,
					s1711, s1712, s1713, s1714, s1715, s1716, s1717, s1718, s1719, s1720,
					s1721, s1722, s1723, s1724,
					s1801, s1802, s1803, s1804, s1805, s1806, s1807, s1808, s1809, s1810,
					s1811, s1812, s1813, s1814, s1815, s1816, s1817, s1818, s1819, s1820,
					s1821, s1822, s1823, s1824, s1825,
					s1901, s1902, s1903, s1904, s1905, s1906, s1907, s1908, s1909, s1910,
					s1911, s1912, s1913, s1914, s1915, s1916, s1917, s1918, s1919, s1920,
					s1921, s1922,
					s2001, s2002, s2003, s2004, s2005, s2006, s2007, s2008, s2009, s2010,
					s2011, s2012, s2013, s2014, s2015, s2016, s2017, s2018, s2019, s2020,
					s2021, s2022, s2023, s2024, s2025, s2026, s2027, s2028, s2029, s2030,
					s2031, s2032,
					s2101, s2102, s2103, s2104, s2105, s2106, s2107, s2108, s2109, s2110,
					s2111, s2112, s2113, s2114, s2115, s2116, s2117,
					s2201, s2202, s2203, s2204, s2205, s2206, s2207, s2208, s2209, s2210,
					s2211,
					s2301, s2302, s2303, s2304, s2305, s2306, s2307, s2308, s2309, s2310,
					s2311, s2312, s2313, s2314, s2315, s2316, s2317, s2318, s2319, s2320,
					s2401, s2402, s2403, s2404, s2405, s2406, s2407, s2408, s2409, s2410,
					s2411, s2412, s2413, s2414, s2415, s2416, s2417, s2418, s2419, s2420,
					s2421,
				}
					.OrderBy(s => s.SubjectId).ToArray();
		}
	}
}
