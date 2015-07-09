using System.Collections.Generic;
using System.Collections.ObjectModel;
using MC.MockServer.Properties;

namespace MC.MockServer.Question
{
	/// <summary>
	/// 問題用リソース。
	/// </summary>
	static class QuestionResource
	{

		/// <summary>ステージ 1_1 用回答候補。</summary>
		internal static readonly IReadOnlyList<IReadOnlyList<string>> Selection0101 =
			new ReadOnlyCollection<IReadOnlyList<string>>(
				new IReadOnlyList<string>[]
				{
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM0_0, Resources.NUM0_1, Resources.NUM0_2, Resources.NUM0_4
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM1_0, Resources.NUM1_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM2_0, Resources.NUM2_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM3_0, Resources.NUM3_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM4_0, Resources.NUM4_2, Resources.NUM4_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM5_0, Resources.NUM5_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM6_0, Resources.NUM6_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM7_0, Resources.NUM7_2, Resources.NUM7_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM8_0, Resources.NUM8_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM9_0, Resources.NUM9_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUMA_0, Resources.NUMA_1, Resources.NUMA_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUMB_0, Resources.NUMB_1, Resources.NUMB_2,
						}),
				});


		/// <summary>ステージ 1_2 用回答候補。</summary>
		internal static readonly IReadOnlyList<IReadOnlyList<string>> Selection0102 =
			new ReadOnlyCollection<IReadOnlyList<string>>(
				new IReadOnlyList<string>[]
				{
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM0_0,
							Resources.NUM0_1,
							Resources.NUM0_2,
							Resources.NUM0_3,
							Resources.NUM0_4
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM1_0, Resources.NUM1_1, Resources.NUM1_2, Resources.NUM1_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM2_0, Resources.NUM2_1, Resources.NUM2_2, Resources.NUM2_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM3_0, Resources.NUM3_1, Resources.NUM3_2, Resources.NUM3_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM4_0,
							Resources.NUM4_1,
							Resources.NUM4_2,
							Resources.NUM4_3,
							Resources.NUM4_4,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM5_0, Resources.NUM5_1, Resources.NUM5_2, Resources.NUM5_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM6_0, Resources.NUM6_1, Resources.NUM6_2, Resources.NUM6_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM7_0,
							Resources.NUM7_1,
							Resources.NUM7_2,
							Resources.NUM7_3,
							Resources.NUM7_4,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM8_0, Resources.NUM8_1, Resources.NUM8_2, Resources.NUM8_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUM9_0, Resources.NUM9_1, Resources.NUM9_2, Resources.NUM9_3,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUMA_0, Resources.NUMA_1, Resources.NUMA_2,
						}),
					new ReadOnlyCollection<string>(
						new string[]
						{
							Resources.NUMB_0, Resources.NUMB_1, Resources.NUMB_2,
						}),
				});
	}
}
