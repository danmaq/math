using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Utils;

namespace MC.Common.Data
{
	/// <summary>
	/// 学園マスタの単票データ。
	/// </summary>
	struct CollegeMasterData
	{

		/// <summary>学園名。</summary>
		private string name;

		/// <summary>解説。</summary>
		private string description;

		/// <summary>有効かどうか。</summary>
		private bool enabled;

		/// <summary>受講に必要な教科一覧。</summary>
		private IReadOnlyCollection<SubjectMasterData> requires;

		/// <summary>すべてのデータを読み込む関数。</summary>
		private Action readFull;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="id">学園 ID。</param>
		public CollegeMasterData(int id)
			: this()
		{
			CollegeId = id;
			readFull = ReadFull;
		}

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="id">学園 ID。</param>
		/// <param name="name">学園名。</param>
		/// <param name="description">解説。</param>
		/// <param name="enabled">有効かどうか。</param>
		/// <param name="full">すべてのデータが割り当てられているかどうか。</param>
		/// <param name="requires">受講に必要な教科一覧。</param>
		public CollegeMasterData(
			int id,
			string name,
			string description,
			bool enabled,
			bool full,
			IReadOnlyCollection<SubjectMasterData> requires)
			: this()
		{
			CollegeId = id;
			this.name = name ?? string.Empty;
			this.description = description ?? string.Empty;
			this.enabled = enabled;
			this.requires = requires ?? new SubjectMasterData[0];
			readFull = full ? DelegateHelper.EmptyAction : new Action(ReadFull);
		}

		/// <summary>
		/// IDを取得します。
		/// </summary>
		public int CollegeId
		{
			get;
			private set;
		}

		/// <summary>
		/// 教科名を取得します。
		/// </summary>
		public string Name
		{
			get
			{
				readFull();
				return name;
			}
		}

		/// <summary>
		/// 解説を取得します。
		/// </summary>
		public string Description
		{
			get
			{
				readFull();
				return description;
			}
		}

		/// <summary>
		/// 有効かどうかを取得します。
		/// </summary>
		public bool Enabled
		{
			get
			{
				readFull();
				return enabled;
			}
		}

		/// <summary>
		/// 必要教科を取得します。
		/// </summary>
		public IReadOnlyCollection<SubjectMasterData> Requires
		{
			get
			{
				readFull();
				return requires;
			}
		}

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(CollegeMasterData valueA, CollegeMasterData valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(CollegeMasterData valueA, CollegeMasterData valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format($@"{nameof(CollegeMasterData)} ID:{CollegeId}, Name:{name})");

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			CollegeId.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is CollegeMasterData ? Equals((CollegeMasterData)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(CollegeMasterData others) =>
			CollegeId == others.CollegeId;

		/// <summary>
		/// すべてのデータを取得します。
		/// </summary>
		private void ReadFull()
		{
			var self = this;
			try
			{
				var master = MasterCache.Instance.CollegeMaster.First(c => self == c);
				name = master.Name;
				description = master.Description;
				enabled = master.Enabled;
				requires = master.Requires;
				readFull = DelegateHelper.EmptyAction;
			}
			catch
			{
				throw new InvalidOperationException();
			}
		}
	}
}
