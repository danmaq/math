using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MC.Common.Collection;
using MC.Common.Data.Serializable;
using MC.Common.Utils;

namespace MC.Common.Data
{
	/// <summary>
	/// ユーザ アカウント情報。
	/// </summary>
	public struct UserData
	{

		/// <summary>既定のデータ。</summary>
		public static readonly UserData Default =
			new UserData()
			{
				UserId = new Random().Next(),
				Name = @"danmaq",
				Comment = @"ぬるぽ",
				Admission = new List<CollegeMasterData>(),
				Tryed = new Dictionary<SubjectMasterData, TryAndClear>(),
			};

		/// <summary>
		/// ユーザIDを取得します。
		/// </summary>
		public long UserId
		{
			get;
			private set;
		}

		/// <summary>
		/// ニックネームを取得します。
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// 一言を取得します。
		/// </summary>
		public string Comment
		{
			get;
			private set;
		}

		/// <summary>
		/// 入学した学園一覧を取得します。
		/// </summary>
		public IList<CollegeMasterData> Admission
		{
			get;
			private set;
		}

		/// <summary>
		/// 挑戦した講義一覧を取得します。
		/// </summary>
		public IDictionary<SubjectMasterData, TryAndClear> Tryed
		{
			get;
			private set;
		}

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(UserData valueA, UserData valueB) => valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(UserData valueA, UserData valueB) => !valueA.Equals(valueB);

		/// <summary>
		/// 値をインポートして、マスタを構成します。
		/// </summary>
		/// <param name="value">値。</param>
		/// <returns>マスタ情報。</returns>
		public static UserData Import(User value) =>
			new UserData()
			{
				UserId = value.UserId,
				Name = value.Name,
				Comment = value.Comment,
				Admission = value.Admission.Select(i => new CollegeMasterData(i)).ToList(),
				Tryed =
					value.Tryed.ToDictionary(
						keySelector: s => new SubjectMasterData(id: s.Key),
						elementSelector: s => s.Value),
			};

		/// <summary>
		/// 値をエクスポートします。
		/// </summary>
		/// <returns>エクスポートされた値。</returns>
		/// <exception cref="InvalidOperationException">完全読み込みされていないマスタをエクスポートすると、例外が発生します。</exception>
		public User Export() =>
			new User()
			{
				UserId = UserId,
				Name = Name,
				Comment = Comment,
				Admission = Admission.Select(m => m.CollegeId).ToArray(),
				Tryed =
					Tryed
						.ToDictionary(
							keySelector: s => s.Key.SubjectId, elementSelector: s => s.Value)
						.ToArray(),
			};

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.CreateToString(
				className: nameof(UserData),
				arguments:
					new Dictionary<string, object>()
					{
						[nameof(UserId)] = UserId,
						[nameof(Name)] = Name,
						[nameof(Comment)] = Comment,
						[nameof(Admission)] = Admission.ToStringCollection(),
						[nameof(Tryed)] = Tryed.ToStringCollection(),
					});

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() =>
			UserId.GetHashCode() ^ Name.GetHashCode() ^ Comment.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is UserData ? Equals((UserData)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(UserData others) =>
			UserId == others.UserId &&
			Name == others.Name &&
			Comment == others.Comment &&
			Admission.SequenceEqual(others.Admission) &&
			Tryed.SequenceEqual(others.Tryed);

		/// <summary>
		/// データの一部、または全部を改変して複製します。
		/// </summary>
		/// <param name="userid">ユーザID。</param>
		/// <param name="name">ニックネーム。</param>
		/// <param name="comment">コメント。</param>
		/// <returns>新しい値。</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public UserData CopyTo(long? userid = null, string name = null, string comment = null)
		{
			var result = 
				new UserData()
				{
					UserId = userid ?? UserId,
					Name = name ?? Name,
					Comment = comment ?? Comment,
				};
			((List<CollegeMasterData>)result.Admission).AddRange(Admission);
			result.Tryed = new Dictionary<SubjectMasterData, TryAndClear>(Tryed);
			return result;
		}
	}
}
