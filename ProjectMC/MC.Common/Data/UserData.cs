using System;
using System.Diagnostics.CodeAnalysis;
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
			new UserData() { UserId = new Random().Next(), Name = @"danmaq", Comment = @"ぬるぽ" };

		/// <summary>ユーザIDを取得または設定します。</summary>
		public long UserId
		{
			get;
			set;
		}

		/// <summary>ニックネームを取得または設定します。</summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>一言を取得または設定します。</summary>
		public string Comment
		{
			get;
			set;
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
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format(
				$@"{nameof(UserData)} UID:{UserId}, Name:{Name}, Comment:{Comment}");

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
			UserId == others.UserId && Name == others.Name && Comment == others.Comment;

		/// <summary>
		/// データの一部、または全部を改変して複製します。
		/// </summary>
		/// <param name="userid">ユーザID。</param>
		/// <param name="name">ニックネーム。</param>
		/// <param name="comment">コメント。</param>
		/// <returns>新しい値。</returns>
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public UserData CopyTo(long? userid = null, string name = null, string comment = null) =>
			new UserData()
			{
				UserId = userid ?? UserId,
				Name = name ?? Name,
				Comment = comment ?? Comment,
			};

	}
}
