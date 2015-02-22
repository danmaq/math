using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
	public static class BDDTablesExtension
	{

		public static BDDTables<T> Create<T>(IDictionary<Tuple<string, BDDType>, Action<T>> testTable) where T : new() =>
			Create(initializer: () => new T(), testTable: testTable);

		public static BDDTables<T> Create<T>(Func<T> initializer, IDictionary<Tuple<string, BDDType>, Action<T>> testTable) =>
			new BDDTables<T>(initializer: initializer, testTable: testTable);
	}
}
