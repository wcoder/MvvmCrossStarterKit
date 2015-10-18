using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Mobile.iOS.Views
{
	[Register("FirstView")]
	public class FirstView : MvxViewController
	{
		public override void ViewDidLoad()
		{
			View = new UIView { BackgroundColor = UIColor.White };
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
			{
				EdgesForExtendedLayout = UIRectEdge.None;
			}

			var textField = new UITextField(new CGRect(10, 10, 300, 40));
			textField.BorderStyle = UITextBorderStyle.Line;
			Add(textField);

			var label = new UILabel(new CGRect(10, 50, 300, 40));
			Add(label);

			var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
			set.Bind(label).To(vm => vm.Hello);
			set.Bind(textField).To(vm => vm.Hello);
			set.Apply();
		}
	}
}