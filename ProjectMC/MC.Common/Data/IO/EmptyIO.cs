using System.IO;

namespace MC.Common.Data.IO
{
	/// <summary>
	/// 空の I/O ラッパー。
	/// </summary>
	sealed class EmptyIO : IIOWrapper
	{
		/// <summary>既定のメモリサイズ。</summary>
		private const int Size = ushort.MaxValue;

		/// <summary>
		/// シングルトン オブジェクト。
		/// </summary>
		public static IIOWrapper Instance
		{
			get;
		}
		= new EmptyIO();

		/// <summary>
		/// 読み込み専用ストリームを取得します。
		/// 呼び出し側が Dispose の責任を負ってください。
		/// </summary>
		public Stream ReadStream => new MemoryStream(Size);

		/// <summary>
		/// 書き込み専用ストリームを取得します。
		/// 呼び出し側が Dispose の責任を負ってください。
		/// </summary>
		public Stream WriteStream => new MemoryStream(Size);
	}
}
