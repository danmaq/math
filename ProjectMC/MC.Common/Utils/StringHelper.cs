using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MC.Common.Utils
{
	/// <summary>
	/// 文字列関係のヘルパ クラス。
	/// </summary>
	static class StringHelper
	{
		/// <summary>
		/// 文字列を整形します。
		/// </summary>
		/// <param name="formattable">整形用文字列。</param>
		/// <returns>文字列。</returns>
		public static string Format(this FormattableString formattable) =>
			formattable?.ToString(CultureInfo.CurrentCulture);

		/// <summary>
		/// オブジェクトを JSON 形式でシリアライズします。
		/// </summary>
		/// <param name="obj">オブジェクト。</param>
		/// <returns>JSON 文字列。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		/// <exception cref="InvalidDataContractException">JSON 非対応の型である場合。</exception>
		public static string ToJson(object obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj));
			}
			var serializer = new DataContractJsonSerializer(obj.GetType());
			string body;
			using (var stream = new MemoryStream())
			{
				serializer.WriteObject(stream: stream, graph: obj);
				stream.Position = 0;
				body = new StreamReader(stream).ReadToEnd();
			}
			return body;
		}

		/// <summary>
		/// オブジェクトを JSON 文字列からデシリアライズします。
		/// </summary>
		/// <typeparam name="T">オブジェクトの型。</typeparam>
		/// <param name="json">JSON 文字列。</param>
		/// <returns>オブジェクト。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		/// <exception cref="InvalidDataContractException">JSON 非対応の型である場合。</exception>
		public static T FromJson<T>(string json)
		{
			if (json == null)
			{
				throw new ArgumentNullException(nameof(json));
			}
			var serializer = new DataContractJsonSerializer(typeof(T));
			T data;
			using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
			{
				data = (T)serializer.ReadObject(stream);
			}
			return data;
		}
	}
}
