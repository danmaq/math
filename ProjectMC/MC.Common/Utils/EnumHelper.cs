using System;
using System.Linq;

namespace MC.Common.Utils
{
	/// <summary>
	/// 列挙体のヘルパ関数です。
	/// </summary>
	public static class EnumHelper
	{
		/// <summary>
		/// 列挙体の最大値を求めます。
		/// </summary>
		/// <typeparam name="T">列挙体の型。</typeparam>
		/// <returns>列挙体の最大値。</returns>
		/// <exception cref="ArgumentException"><typeparamref name="T"/> が列挙体でない場合。</exception>
		public static T Max<T>() where T : struct => Enum.GetValues(typeof(T)).Cast<T>().Max();

		/// <summary>
		/// 列挙体の全件数を求めます。
		/// </summary>
		/// <param name="type">列挙体の型。</param>
		/// <returns>列挙体の最大値。</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> が列挙体でない場合。</exception>
		public static int Length(Type type) => Enum.GetValues(type).Length;
	}
}
