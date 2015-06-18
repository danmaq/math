using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MC.Common.Data;
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

		public IReadOnlyCollection<CollegeMasterData> CollegeMaster
		{
			get;
			private set;
		}

		public IReadOnlyCollection<SubjectMasterData> SubjectMaster
		{
			get;
			private set;
		}

		/// <summary>
		/// データを構築します。
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals")]
		private void Setup()
		{
			var id = 0;
			var emptySubject = new List<SubjectMasterData>().AsReadOnly();
			var c = new CollegeMasterData[24];
			c[0] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_01_NAME, description: Resources.COLLEGE_01_DESCRIPTION, enabled: true, requires: emptySubject);
			var s0101 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_001, description: Resources.SUBJECT_DESCRIPTION_01_001, enabled: true, college: c[0], requires: emptySubject);
			var s0102 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_002, description: Resources.SUBJECT_DESCRIPTION_01_002, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0101 });
			var s0103 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_003, description: Resources.SUBJECT_DESCRIPTION_01_003, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0101 });
			var s0104 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_004, description: Resources.SUBJECT_DESCRIPTION_01_004, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0102 });
			var s0105 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_005, description: Resources.SUBJECT_DESCRIPTION_01_005, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0102 });
			var s0106 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_006, description: Resources.SUBJECT_DESCRIPTION_01_006, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0105 });
			var s0107 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_007, description: Resources.SUBJECT_DESCRIPTION_01_007, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0102 });
			var s0108 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_008, description: Resources.SUBJECT_DESCRIPTION_01_008, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0107 });
			var s0109 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_009, description: Resources.SUBJECT_DESCRIPTION_01_009, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0101 });
			var s0110 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_010, description: Resources.SUBJECT_DESCRIPTION_01_010, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0109 });
			var s0111 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_011, description: Resources.SUBJECT_DESCRIPTION_01_011, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0110 });
			var s0112 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_012, description: Resources.SUBJECT_DESCRIPTION_01_012, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0109, s0106 });
			var s0113 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_013, description: Resources.SUBJECT_DESCRIPTION_01_013, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0109, s0108 });
			var s0114 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_014, description: Resources.SUBJECT_DESCRIPTION_01_014, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0112, s0113 });
			var s0115 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_015, description: Resources.SUBJECT_DESCRIPTION_01_015, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0106, s0111 });
			var s0116 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_016, description: Resources.SUBJECT_DESCRIPTION_01_016, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0112, s0115 });
			var s0117 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_017, description: Resources.SUBJECT_DESCRIPTION_01_017, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0111, s0108 });
			var s0118 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_018, description: Resources.SUBJECT_DESCRIPTION_01_018, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0113, s0117 });
			var s0119 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_019, description: Resources.SUBJECT_DESCRIPTION_01_019, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0110, s0111 });
			var s0120 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_020, description: Resources.SUBJECT_DESCRIPTION_01_020, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0119 });
			var s0121 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_01_021, description: Resources.SUBJECT_DESCRIPTION_01_021, enabled: true, college: c[0], requires: new SubjectMasterData[] { s0120 });
			c[1] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_02_NAME, description: Resources.COLLEGE_02_DESCRIPTION, enabled: true, requires: new SubjectMasterData[] { s0104, s0114, s0116, s0118, s0119 });
			var s0201 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_001, description: Resources.SUBJECT_DESCRIPTION_02_001, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0116 });
			var s0202 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_002, description: Resources.SUBJECT_DESCRIPTION_02_002, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0104, s0201 });
			var s0203 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_003, description: Resources.SUBJECT_DESCRIPTION_02_003, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0201 });
			var s0204 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_004, description: Resources.SUBJECT_DESCRIPTION_02_004, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0203 });
			var s0205 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_005, description: Resources.SUBJECT_DESCRIPTION_02_005, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0201 });
			var s0206 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_006, description: Resources.SUBJECT_DESCRIPTION_02_006, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0104, s0205 });
			var s0207 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_007, description: Resources.SUBJECT_DESCRIPTION_02_007, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0205 });
			var s0208 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_008, description: Resources.SUBJECT_DESCRIPTION_02_008, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0207 });
			var s0209 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_009, description: Resources.SUBJECT_DESCRIPTION_02_009, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0201, s0205, s0114 });
			var s0210 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_010, description: Resources.SUBJECT_DESCRIPTION_02_010, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0209 });
			var s0211 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_011, description: Resources.SUBJECT_DESCRIPTION_02_011, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0210 });
			var s0212 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_012, description: Resources.SUBJECT_DESCRIPTION_02_012, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0104, s0116 });
			var s0213 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_013, description: Resources.SUBJECT_DESCRIPTION_02_013, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0212, s0119 });
			var s0214 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_014, description: Resources.SUBJECT_DESCRIPTION_02_014, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0213, s0111 });
			var s0215 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_015, description: Resources.SUBJECT_DESCRIPTION_02_015, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0214, s0118 });
			var s0216 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_016, description: Resources.SUBJECT_DESCRIPTION_02_016, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0215, s0119 });
			var s0217 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_017, description: Resources.SUBJECT_DESCRIPTION_02_017, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0216, s0111 });
			var s0218 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_018, description: Resources.SUBJECT_DESCRIPTION_02_018, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0204 });
			var s0219 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_019, description: Resources.SUBJECT_DESCRIPTION_02_019, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0218, s0119 });
			var s0220 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_020, description: Resources.SUBJECT_DESCRIPTION_02_020, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0219, s0213 });
			var s0221 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_021, description: Resources.SUBJECT_DESCRIPTION_02_021, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0205 });
			var s0222 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_022, description: Resources.SUBJECT_DESCRIPTION_02_022, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0221 });
			var s0223 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_02_023, description: Resources.SUBJECT_DESCRIPTION_02_023, enabled: true, college: c[1], requires: new SubjectMasterData[] { s0222 });
			c[2] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_03_NAME, description: Resources.COLLEGE_03_DESCRIPTION, enabled: true, requires: new SubjectMasterData[] { s0102 });
			var s0301 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_001, description: Resources.SUBJECT_DESCRIPTION_03_001, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0102 });
			var s0302 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_002, description: Resources.SUBJECT_DESCRIPTION_03_002, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0301 });
			var s0303 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_003, description: Resources.SUBJECT_DESCRIPTION_03_003, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0301 });
			var s0304 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_004, description: Resources.SUBJECT_DESCRIPTION_03_004, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0303 });
			var s0305 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_005, description: Resources.SUBJECT_DESCRIPTION_03_005, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0304 });
			var s0306 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_006, description: Resources.SUBJECT_DESCRIPTION_03_006, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0307 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_007, description: Resources.SUBJECT_DESCRIPTION_03_007, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0302, s0304 });
			var s0308 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_008, description: Resources.SUBJECT_DESCRIPTION_03_008, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0309 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_009, description: Resources.SUBJECT_DESCRIPTION_03_009, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0308, s0303 });
			var s0310 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_010, description: Resources.SUBJECT_DESCRIPTION_03_010, enabled: true, college: c[2], requires: emptySubject);
			var s0311 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_011, description: Resources.SUBJECT_DESCRIPTION_03_011, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0310 });
			var s0312 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_012, description: Resources.SUBJECT_DESCRIPTION_03_012, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0311 });
			var s0313 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_013, description: Resources.SUBJECT_DESCRIPTION_03_013, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0310 });
			var s0314 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_014, description: Resources.SUBJECT_DESCRIPTION_03_014, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0315 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_015, description: Resources.SUBJECT_DESCRIPTION_03_015, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0314 });
			var s0316 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_016, description: Resources.SUBJECT_DESCRIPTION_03_016, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0314, s0304 });
			var s0317 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_017, description: Resources.SUBJECT_DESCRIPTION_03_017, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0307, s0315 });
			var s0318 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_018, description: Resources.SUBJECT_DESCRIPTION_03_018, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0302 });
			var s0319 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_019, description: Resources.SUBJECT_DESCRIPTION_03_019, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0307, s0318 });
			var s0320 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_020, description: Resources.SUBJECT_DESCRIPTION_03_020, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0319 });
			var s0321 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_021, description: Resources.SUBJECT_DESCRIPTION_03_021, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0320 });
			var s0322 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_022, description: Resources.SUBJECT_DESCRIPTION_03_022, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0319, s0309 });
			var s0323 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_03_023, description: Resources.SUBJECT_DESCRIPTION_03_023, enabled: true, college: c[2], requires: new SubjectMasterData[] { s0318 });
			c[4] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_05_NAME, description: Resources.COLLEGE_05_DESCRIPTION, enabled: true, requires: new SubjectMasterData[] { s0220, s0223 });
			c[3] = new CollegeMasterData(id: id++, name: Resources.COLLEGE_04_NAME, description: Resources.COLLEGE_04_DESCRIPTION, enabled: true, requires: new SubjectMasterData[] { s0120, s0218, s0222, s0307 });
			var s0401 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_001, description: Resources.SUBJECT_DESCRIPTION_04_001, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0110 });
			var s0402 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_002, description: Resources.SUBJECT_DESCRIPTION_04_002, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0401, s0119 });
			var s0403 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_003, description: Resources.SUBJECT_DESCRIPTION_04_003, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0110, s0307 });
			var s0404 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_004, description: Resources.SUBJECT_DESCRIPTION_04_004, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0403, s0402, s0120 });
			var s0405 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_005, description: Resources.SUBJECT_DESCRIPTION_04_005, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0119 });
			var s0406 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_006, description: Resources.SUBJECT_DESCRIPTION_04_006, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0405 });
			var s0407 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_007, description: Resources.SUBJECT_DESCRIPTION_04_007, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0110 });
			var s0408 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_008, description: Resources.SUBJECT_DESCRIPTION_04_008, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0407 });
			var s0409 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_009, description: Resources.SUBJECT_DESCRIPTION_04_009, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0110 });
			var s0410 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_010, description: Resources.SUBJECT_DESCRIPTION_04_010, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0409, s0110 });
			var s0411 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_011, description: Resources.SUBJECT_DESCRIPTION_04_011, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0222, s0402, s0404, s0410 });
			var s0412 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_012, description: Resources.SUBJECT_DESCRIPTION_04_012, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0408, s0411 });
			var s0413 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_013, description: Resources.SUBJECT_DESCRIPTION_04_013, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0304, s0119 });
			var s0414 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_014, description: Resources.SUBJECT_DESCRIPTION_04_014, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0413, s0301 });
			var s0415 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_015, description: Resources.SUBJECT_DESCRIPTION_04_015, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0413, s0308 });
			var s0416 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_016, description: Resources.SUBJECT_DESCRIPTION_04_016, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0307, s0404, s0201 });
			var s0417 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_017, description: Resources.SUBJECT_DESCRIPTION_04_017, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0404, s0305, s0221 });
			var s0418 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_018, description: Resources.SUBJECT_DESCRIPTION_04_018, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0417 });
			var s0419 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_019, description: Resources.SUBJECT_DESCRIPTION_04_019, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0416, s0317 });
			var s0420 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_020, description: Resources.SUBJECT_DESCRIPTION_04_020, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0419, s0210, s0222 });
			var s0421 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_021, description: Resources.SUBJECT_DESCRIPTION_04_021, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0419 });
			var s0422 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_022, description: Resources.SUBJECT_DESCRIPTION_04_022, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0311, s0515 });
			var s0423 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_023, description: Resources.SUBJECT_DESCRIPTION_04_023, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0416, s0422 });
			var s0424 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_024, description: Resources.SUBJECT_DESCRIPTION_04_024, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0312, s0413, s0525 });
			var s0425 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_025, description: Resources.SUBJECT_DESCRIPTION_04_025, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0423, s0313 });
			var s0426 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_026, description: Resources.SUBJECT_DESCRIPTION_04_026, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0405, s0110, s0319 });
			var s0427 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_027, description: Resources.SUBJECT_DESCRIPTION_04_027, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0426, s0120 });
			var s0428 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_028, description: Resources.SUBJECT_DESCRIPTION_04_028, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0427, s0319, s0416 });
			var s0429 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_029, description: Resources.SUBJECT_DESCRIPTION_04_029, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0320, s0428, s0423 });
			var s0430 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_030, description: Resources.SUBJECT_DESCRIPTION_04_030, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0429, s0321 });
			var s0431 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_031, description: Resources.SUBJECT_DESCRIPTION_04_031, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0313, s0428, s0423 });
			var s0432 = new SubjectMasterData(id: id++, name: Resources.SUBJECT_NAME_04_032, description: Resources.SUBJECT_DESCRIPTION_04_032, enabled: true, college: c[3], requires: new SubjectMasterData[] { s0616, s0404, s0427 });

			CollegeMaster = c;
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
				};
        }
	}
}
