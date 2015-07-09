﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MC.Common.Utils
{
	/// <summary>
	/// 文字列関係のヘルパ クラス。
	/// </summary>
	public static class StringHelper
	{
		/// <summary>
		/// <c>ToString()</c> メソッド用の文字列を生成します。
		/// </summary>
		/// <param name="className">クラス名。</param>
		/// <param name="arguments">引数名と値のペアリスト。</param>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static string CreateToString(
			object className, IEnumerable<KeyValuePair<string, object>> arguments) =>
			arguments
				.Select(
					p => string.Format(CultureInfo.CurrentCulture, @" ({0}: {1})", p.Key, p.Value))
				.Aggregate((className ?? "(Anonymous)").ToString(), (s, i) => s + i);

		/// <summary>
		/// オブジェクトを JSON 形式でシリアライズします。
		/// </summary>
		/// <param name="value">オブジェクト。</param>
		/// <returns>JSON 文字列。</returns>
		/// <exception cref="ArgumentNullException">引数が null である場合。</exception>
		/// <exception cref="InvalidDataContractException">JSON 非対応の型である場合。</exception>
		public static string ToJson(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}
			var serializer = new DataContractJsonSerializer(value.GetType());
			string body;
			using (var stream = new MemoryStream())
			{
				serializer.WriteObject(stream: stream, graph: value);
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
