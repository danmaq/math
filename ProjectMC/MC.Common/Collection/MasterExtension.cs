using System;
using System.Collections.Generic;
using System.Linq;
using MC.Common.Data;

namespace MC.Common.Collection
{
	/// <summary>
	/// 各種マスタの拡張機能。
	/// </summary>
	static class MasterExtension
	{

		/// <summary>
		/// ユーザ情報から選択可能な学園を抽出するシーケンスを取得します。
		/// </summary>
		/// <param name="collegeMaster">マスタ データ。</param>
		/// <param name="user">ユーザ情報。</param>
		/// <returns>学園一覧を抽出するシーケンス。</returns>
		/// <exception cref="ArgumentNullException">マスタが null である場合。</exception>
		public static IEnumerable<CollegeMasterData> AvailableCollege(
			this IEnumerable<CollegeMasterData> collegeMaster, UserData user)
		{
			if (collegeMaster == null)
			{
				throw new ArgumentNullException(nameof(collegeMaster));
			}
			return (
				from master in collegeMaster
				from cleard in user.Cleard
				where
					master.Requires.Count == 0 ||
					(cleard.Item2 > 0 && master.Requires.Any(s => s == cleard.Item1))
				select master)
					.Concat(user.Admission)
					.OrderBy(c => c.CollegeId)
					.Distinct();
		}

		/// <summary>
		/// ユーザ情報、学園情報から選択可能な講義をを抽出するシーケンスを取得します。
		/// </summary>
		/// <param name="subjectMaster">マスタ データ。</param>
		/// <param name="user">ユーザ情報。</param>
		/// <param name="college">学園情報。</param>
		/// <returns>講義一覧を抽出するシーケンス。</returns>
		/// <exception cref="ArgumentNullException">マスタが null である場合。</exception>
		public static IEnumerable<SubjectMasterData> AvailableSubjects(
			this IEnumerable<SubjectMasterData> subjectMaster,
			UserData user,
			CollegeMasterData college)
		{
			if (subjectMaster == null)
			{
				throw new ArgumentNullException(nameof(subjectMaster));
			}
			return (
				from master in subjectMaster
				from cleard in user.Cleard
				where
					college == master.College &&
					(master.Requires.Count == 0 ||
						(cleard.Item2 > 0 && master.Requires.Any(s => s == cleard.Item1)))
				select master)
					.OrderBy(s => s.SubjectId)
					.Distinct();
		}
	}
}
