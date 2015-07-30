using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using MC.Common.Utils;
using MC.Core.Data;

namespace MC.Desktop.Pages
{
	/// <summary>
	/// ボタンにバインディングするための選択肢データ。
	/// </summary>
	sealed class SelectionData
	{

		/// <summary>
		/// ボタン実行用のアクションのラッパー。
		/// </summary>
		private class Command : ICommand
		{
			/// <summary><c>CanExecute()</c> メソッドが変化した際に発生するイベント。</summary>
			public event EventHandler CanExecuteChanged = DelegateHelper.EmptyHandler;

			/// <summary>
			/// コンストラクタ。
			/// </summary>
			/// <param name="action">ラッピングするアクション。</param>
			public Command(Action action)
			{
				Action = action;
			}

			/// <summary>
			/// ラッピングするアクションを取得します。
			/// </summary>
			private Action Action
			{
				get;
			}

			/// <summary>
			/// 現在の状態でこのコマンドを実行できるかどうかを判定します。
			/// </summary>
			/// <param name="parameter">コマンドで使用されたデータ。</param>
			/// <returns>このコマンドを実行できる場合、true。</returns>
			public bool CanExecute(object parameter) => Action != null;

			/// <summary>
			/// コマンドの起動時に呼び出されます。
			/// </summary>
			/// <param name="parameter">コマンドで使用されたデータ。</param>
			public void Execute(object parameter)
			{
				Action();
			}
		}

		/// <summary>
		/// コンストラクタ。
		/// </summary>
		/// <param name="source">ソースとなる選択肢。</param>
		public SelectionData(Selection source)
		{
			Caption = source.Caption;
			Description = source.Description;
			Action = new Command(source.Select);
		}

		/// <summary>
		/// 表題を取得します。
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string Caption
		{
			get;
		}

		/// <summary>
		/// 解説文を取得します。
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string Description
		{
			get;
		}

		/// <summary>
		/// 実行されるアクションを取得します。
		/// </summary>
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ICommand Action
		{
			get;
		}
	}
}
