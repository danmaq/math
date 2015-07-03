using System;
using System.Runtime.Serialization;
using MC.Common.Utils;

namespace MC.Common.Data.Serializable
{
	/// <summary>
	/// 挑戦回数と攻略回数を保持するデータ。
	/// </summary>
	[DataContract]
	public struct TryAndClear : IEquatable<TryAndClear>
	{
		/// <summary>
		/// 挑戦回数を取得および設定します。
		/// </summary>
		[DataMember]
		public int Tryed
		{
			get;
			set;
		}

		/// <summary>
		/// 攻略回数を取得および設定します。
		/// </summary>
		[DataMember]
		public int Cleard
		{
			get;
			set;
		}

		/// <summary>
		/// 勝率を取得します。
		/// </summary>
		public float Percentage => Cleard / (float)Tryed;

		/// <summary>
		/// 値同士が等しいかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しい場合、true。</returns>
		public static bool operator ==(TryAndClear valueA, TryAndClear valueB) =>
			valueA.Equals(valueB);

		/// <summary>
		/// 値同士が等しくないかどうかを判定します。
		/// </summary>
		/// <param name="valueA">値。</param>
		/// <param name="valueB">値。</param>
		/// <returns>値同士が等しくない場合、true。</returns>
		public static bool operator !=(TryAndClear valueA, TryAndClear valueB) =>
			!valueA.Equals(valueB);

		/// <summary>
		/// 値の文字列表現を取得します。
		/// </summary>
		/// <returns>値の文字列表現。</returns>
		public override string ToString() =>
			StringHelper.Format($@"{nameof(TryAndClear)} {Cleard}/{Tryed}");

		/// <summary>
		/// ハッシュコードを取得します。
		/// </summary>
		/// <returns>ハッシュコード。</returns>
		public override int GetHashCode() => Tryed.GetHashCode() ^ Cleard.GetHashCode();

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="obj">検証対象の値。</param>
		/// <returns>値が等しい場合、true。</returns>
		public override bool Equals(object obj) =>
			obj is TryAndClear ? Equals((TryAndClear)(obj)) : false;

		/// <summary>
		/// 値が等しいかどうかを検証します。
		/// </summary>
		/// <param name="others"></param>
		/// <returns>値が等しい場合、true。</returns>
		public bool Equals(TryAndClear others) => Tryed == others.Tryed && Cleard == others.Cleard;
	}
}
