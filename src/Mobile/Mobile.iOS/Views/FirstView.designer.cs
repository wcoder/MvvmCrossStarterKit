// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Mobile.iOS.Views
{
	[Register ("FirstView")]
	partial class FirstView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField textFeild { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel textLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (textFeild != null) {
				textFeild.Dispose ();
				textFeild = null;
			}
			if (textLabel != null) {
				textLabel.Dispose ();
				textLabel = null;
			}
		}
	}
}
