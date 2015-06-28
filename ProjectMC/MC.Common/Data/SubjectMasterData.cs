using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Data.Serializable;
using MC.Common.Utils;

namespace MC.Common.Data
{
	/// <summary>
	/// 教科マスタの単票データ。
	/// </summary>
	struct SubjectMasterData
	{

		/// <summary>学園名。</summary>
		private string name;

		/// <summary>解説。</summary>
		private string description;

		/// <summary>有効かどうか。</summary>
		private bool enabled;

		/// <summary>所属学園。</summary>
		private CollegeMasterData college;

		/// <summary>受講に必要な教科一覧。</summary>
		private IReadOnlyCollection<SubjectMasterData> requires;

		/// <summary>すべてのデータを読み込む関数。</summary>
		private Action readFull;

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="id">教科 ID。</param>
		public SubjectMasterData(int id)
			: this()
		{
			SubjectId = id;
			readFull = ReadFull;
		}

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="id">教科 ID。</param>
		/// <param name="name">教科名。</param>
		/// <param name="description">解説。</param>
		/// <param name="enabled">有効かどうか。</param>
		/// <param name="full">すべてのデータが割り当てられているかどうか。</param>
		/// <param name="college">所属学園。</param>
		/// <param name="requires">受講に必要な教科一覧。</param>
		public SubjectMasterData(
			int id,
			string name,
			string description,
			bool enabled,
			bool full,
			CollegeMasterData college,
			IReadOnlyCollection<SubjectMasterData> requires)
			: this()
		{
			SubjectId = id;
			this.name = name ?? string.Empty;
			this.description = description ?? string.Empty;
			this.enabled = enabled;
			this.college = college;
			this.requires = requires ?? new SubjectMasterData[0];
			readFull = full ? DelegateHelper.EmptyAction : new Action(ReadFull);
		}

		/// <summary>
		/// 教科 ID を取得します。
		/// </summary>
		public int SubjectId
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
		/// 所属学園を取得します。
		/// </summary>
		public CollegeMasterData College
		{
			get
			{
				readFull();
				return college;
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
		/// ID からマスタを仮作成します。
		/// </summary>
		/// <param name="id">ID。</param>
		/// <returns>仮作成されたマスタ。</returns>
		public static implicit operator SubjectMasterData(int id) =>
			new SubjectMasterData(id);

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(SubjectMasterData valueA, SubjectMasterData valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(SubjectMasterData valueA, SubjectMasterData valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値をインポートして、マスタを構成します。
		/// </summary>
		/// <param name="value">値。</param>
		/// <returns>マスタ情報。</returns>
		public static SubjectMasterData Import(Subject value)
		{
			var requires = value.RequireSubjects.Select(s => new SubjectMasterData(s)).ToArray();
			return
				new SubjectMasterData(
					id: value.SubjectId,
					name: value.Name,
					description: value.Description,
					enabled: value.Enabled,
					college: value.CollegeId,
					full: true,
					requires: requires);
		}

		/// <summary>
		/// 値をエクスポートします。
		/// </summary>
		/// <returns>エクスポートされた値。</returns>
		/// <exception cref="InvalidOperationException">完全読み込みされていないマスタをエクスポートすると、例外が発生します。</exception>
		public Subject Export()
		{
			if (readFull != DelegateHelper.EmptyAction)
			{
				throw new InvalidOperationException();
			}
			return
				new Subject()
				{
					SubjectId = SubjectId,
					Name = name,
					Description = description,
					Enabled = enabled,
					CollegeId = College.CollegeId,
					RequireSubjects = requires.Select(s => s.SubjectId).ToArray(),
				};
		}

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format($@"{nameof(SubjectMasterData)} ID:{SubjectId}, Name:{name}");

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			SubjectId.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is SubjectMasterData ? Equals((SubjectMasterData)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(SubjectMasterData others) =>
			SubjectId == others.SubjectId;

		/// <summary>
		/// すべてのデータを取得します。
		/// </summary>
		private void ReadFull()
		{
			var self = this;
			try
			{
				var master = MasterCache.SubjectMaster.First(s => self == s);
				name = master.Name;
				description = master.Description;
				enabled = master.Enabled;
				college = master.college;
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
