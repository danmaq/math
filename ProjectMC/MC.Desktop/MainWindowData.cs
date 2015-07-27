using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MC.Desktop.Properties;

namespace MC.Desktop
{

	/// <summary>
	/// メインウィンドウ用のバインディング データ。
	/// </summary>
	class MainWindowData : ICloneable
	{

		/// <summary>
		/// 初期データ。
		/// </summary>
		public static MainWindowData Default
		{
			get;
		}
		= CreateDefault();

		/// <summary>
		/// タイトルを取得します。
		/// </summary>
		public string Title
		{
			get;
			private set;
		}
		= @"MATH.SC";

		/// <summary>
		/// アイコンを取得します。
		/// </summary>
		public ImageSource Icon
		{
			get;
			private set;
		}

		/// <summary>
		/// 最小化ボタンのキャプションを取得します。
		/// </summary>
		public string MinimizeCaption
		{
			get;
			private set;
		}
		= @"0";

		/// <summary>
		/// 最大化ボタンのキャプションを取得します。
		/// </summary>
		public string MaximizeCaption
		{
			get;
			private set;
		}
		= @"1";

		/// <summary>
		/// 閉じるボタンのキャプションを取得します。
		/// </summary>
		public string CloseCaption
		{
			get;
			private set;
		}
		= @"r";

		/// <summary>
		/// タイトルのキャプションを取得します。
		/// </summary>
		public string TitleCaption
		{
			get;
			private set;
		}
		= @"Version 0.0.0.0";

		/// <summary>
		/// 既定のデータを作成します。
		/// </summary>
		/// <returns>既定のデータ。</returns>
		private static MainWindowData CreateDefault()
		{
			var asm = Assembly.GetExecutingAssembly();
			var title = asm.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
			var ver = asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
			var icon = BitmapFrame.Create(asm.GetManifestResourceStream(Resources.RES_ICON));
			var titleCaption = Miscs.Format($@"{title} バージョン {ver}");
			return new MainWindowData().CopyTo(title, icon, titleCaption);
		}

		/// <summary>
		/// 複製します。
		/// </summary>
		/// <param name="title">タイトル。</param>
		/// <param name="icon">アイコン。</param>
		/// <param name="titleCaption">タイトルのキャプション。</param>
		/// <param name="minimizeCaption">最小化ボタンのキャプション。</param>
		/// <param name="maximizeCaption">最大化ボタンのキャプション。</param>
		/// <param name="closeCaption">閉じるボタンのキャプション。</param>
		/// <returns></returns>
		public MainWindowData CopyTo(
			string title = null,
			ImageSource icon = null,
			string titleCaption = null,
			string minimizeCaption = null,
			string maximizeCaption = null,
			string closeCaption = null) =>
			new MainWindowData()
			{
				Title = title ?? Title,
				Icon = icon ?? Icon,
				TitleCaption = titleCaption ?? TitleCaption,
				MinimizeCaption = minimizeCaption ?? MinimizeCaption,
				MaximizeCaption = maximizeCaption ?? MaximizeCaption,
				CloseCaption = closeCaption ?? CloseCaption,
			};

		public override string ToString() =>
			Miscs.Format($@"");

		/// <summary>
		/// 現在のインスタンスのコピーである新しいオブジェクトを作成します。
		/// </summary>
		/// <returns>このインスタンスのコピーである新しいオブジェクト。</returns>
		object ICloneable.Clone()
		{
			return CopyTo();
		}
	}
}
