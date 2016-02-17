using System;

using UIKit;
using MvvmCross.iOS.Views;
using Mobile.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace Mobile.iOS.Views
{
	[MvxFromStoryboard]
	public partial class FirstView : MvxViewController<FirstViewModel>
	{
		public FirstView(IntPtr handle) : base(handle)
		{
		}

		void CreateBindings()
		{
			this.CreateBinding(textFeild).To((FirstViewModel vm) => vm.Hello).Apply();
			this.CreateBinding(textLabel).To((FirstViewModel vm) => vm.Hello).Apply();
		}
	
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			CreateBindings();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


