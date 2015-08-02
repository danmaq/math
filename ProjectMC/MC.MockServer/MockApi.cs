using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MC.Common.Utils;

namespace MC.MockServer
{
	using API = Func<string, IEnumerable<string>, string, object>;
	using APIWithoutParams = Func<string, string, object>;
	using PairedAPIParams = Tuple<string, IEnumerable<string>>;

	/// <summary>
	/// モック サーバの API 呼び出し窓口。
	/// </summary>
	sealed class MockApi
	{

		/// <summary>API 一覧。</summary>
		private readonly Dictionary<string, API> Apis =
			new Dictionary<string, API>()
			{
				["/v1/master"] = (m, p, b) => MasterStore.Instance.Export(),
				["/v1/question"] = (m, p, b) => null,
			};

		/// <summary>
		/// API を呼び出します。
		/// </summary>
		/// <param name="path">API へのパス。</param>
		/// <param name="method">HTTP メソッド。</param>
		/// <param name="content">ボディ。</param>
		/// <returns>API の戻り値。</returns>
		public Tuple<bool, string> CallApi(string path, string method, string content)
		{
			var api = ParsePath(path);
			var result = api != null;
			return Tuple.Create(result, result ? StringHelper.ToJson(api(method, content)) : null);
		}

		/// <summary>
		/// パスを分解して、合致した API にパラメータを部分適用します。
		/// </summary>
		/// <param name="path">パス。</param>
		/// <returns>パラメータを部分適用された API。</returns>
		private APIWithoutParams ParsePath(string path)
		{
			var keys = Apis.Keys;
			var found = DecompositePath(path).FirstOrDefault(a => keys.Any(k => a.Item1 == k));
			APIWithoutParams parted = (m, c) => Apis[found.Item1](m, found.Item2, c);
			return found == null ? null : parted;
		}

		/// <summary>
		/// パスを分解して、API エンドポイントとパラメータに分割します。
		/// </summary>
		/// <param name="path">パス。</param>
		/// <returns>API エンドポイントとパラメータ一覧。</returns>
		private static IEnumerable<PairedAPIParams> DecompositePath(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}
			yield return Tuple.Create(item1: path, item2: Enumerable.Empty<string>());
			var param = new List<string>();
			while (!(path == string.Empty || path == @"/"))
			{
				var splited = SplitPath(path);
				path = splited.Item1;
				param.Add(splited.Item2);
				yield return Tuple.Create<string, IEnumerable<string>>(item1: path, item2: param);
			}
		}

		/// <summary>
		/// パスをディレクトリとファイルに分割します。
		/// </summary>
		/// <param name="path">パス。</param>
		/// <returns>ディレクトリとファイルの組。</returns>
		private static Tuple<string, string> SplitPath(string path) =>
			Tuple.Create(item1: Path.GetDirectoryName(path), item2: Path.GetFileName(path));
	}
}
