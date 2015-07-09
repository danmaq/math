using System.IO;

namespace MC.Common.Data.IO
{
	/// <summary>
	/// PCL は直接の I/O ができないので、ストリーム経由で読み書きするための仕組みを定義します。
	/// </summary>
	public interface IIOWrapper
	{

		/// <summary>
		/// 読み込み専用ストリーム。呼び出し側が Dispose の責任を負います。
		/// </summary>
		Stream ReadStream { get; }

		/// <summary>
		/// 書き込み専用ストリーム。呼び出し側が Dispose の責任を負います。
		/// </summary>
		Stream WriteStream { get; }
	}
}
