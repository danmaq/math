using System;
using System.Globalization;
using System.Reflection;

namespace MC.Desktop
{
	/// <summary>
	/// 雑多な関数群クラス。
	/// </summary>
	static class Miscs
	{

		/// <summary>
		/// 文字列を整形します。
		/// </summary>
		/// <param name="format">整形フォーマット。</param>
		/// <returns>整形された文字列。</returns>
		public static string Format(this FormattableString format) =>
			format.ToString(CultureInfo.CurrentCulture);

		/// <summary>
		/// 指定したアセンブリに適用されたカスタム属性を取得します。
		/// </summary>
		/// <typeparam name="T">検索対象とするカスタム属性の型または基本型。</typeparam>
		/// <param name="assembly">モジュールの再利用可能なコレクションを記述するアセンブリ。</param>
		/// <returns>単一のカスタム属性への参照。該当する属性がない場合は null。</returns>
		/// <exception cref="ArgumentNullException"><paramref name="assembly"/> が null である場合。</exception>
		/// <exception cref="AmbiguousMatchException">要求された属性が複数見つかった場合。</exception>
		public static T GetCustomAttribute<T>(this Assembly assembly) where T : Attribute =>
			Attribute.GetCustomAttribute(element: assembly, attributeType: typeof(T)) as T;
	}
}
