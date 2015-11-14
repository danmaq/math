using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MC.Common.Utils;
using MC.MockServer.Question;

using API = System.Func<string, System.Collections.Generic.IEnumerable<string>, string, object>;
using APIWithoutParams = System.Func<string, string, object>;
using PairedAPIParams = System.Tuple<string, System.Collections.Generic.IEnumerable<string>>;

namespace MC.MockServer
{

	/// <summary>
	/// モック サーバの API 呼び出し窓口。
	/// </summary>
	sealed class MockApi
	{

		/// <summary>API 一覧。</summary>
		private readonly Dictionary<string, API> Apis =
			new Dictionary<string, API>()
			{
				[@"/v1/user"] = UserManager.Instance.Facade,
				[@"/v1/master"] = (m, p, b) => MasterStore.Instance.Export(),
				[@"/v1/question"] = (m, p, b) => QuestionStore.Instance.CreateQuestion(p),
				[@"/v1/answer"] = (m, p, b) => QuestionStore.Instance.JudgeQuestion(p),
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
			var obj = api == null ? null : api(method, content);
			var result = obj != null;
			return Tuple.Create(result, result ? StringHelper.ToJson(obj) : null);
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
				param.Insert(index: 0, item: splited.Item2);
				yield return new PairedAPIParams(item1: path, item2: param);
			}
		}

		/// <summary>
		/// パスをディレクトリとファイルに分割します。
		/// </summary>
		/// <param name="path">パス。</param>
		/// <returns>ディレクトリとファイルの組。</returns>
		private static Tuple<string, string> SplitPath(string path) =>
			Tuple.Create(
				item1: Path.GetDirectoryName(path).Replace(oldValue: @"\", newValue: @"/"),
				item2: Path.GetFileName(path));
	}
}
