using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Desktop
{
	class MainWindowData : ICloneable
	{

		public string MinimizeCaption
		{
			get;
			private set;
		}
		= "0";

		public string MaximizeCaption
		{
			get;
			private set;
		}
		= "0";

		public string CloseCaption
		{
			get;
			private set;
		}
		= "0";

		public string Caption
		{
			get;
			private set;
		}
		="Version 0.0.0.0";

		public MainWindowData CopyTo() =>
			new MainWindowData()
			{

			};

		public object Clone()
		{
			throw new NotImplementedException();
		}
	}
}
