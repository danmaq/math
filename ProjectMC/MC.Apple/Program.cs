using MonoTouch.UIKit;

namespace MC
{
	/// <summary>
	/// �G���g�� �|�C���g�̂��߂̃N���X�B
	/// </summary>
	public class Application
	{
		/// <summary>
		/// This is the main entry point of the application.
		/// </summary>
		/// <param name="args">�R�}���h ���C�������B</param>
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(
				args: args, principalClassName: null, delegateClassName: @"AppDelegate");
		}
	}
}

