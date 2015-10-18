using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Mobile.Core.ViewModels;

namespace Mobile.Android.Views
{
	[Activity(Label = "View for FirstViewModel")]
	public class FirstView : MvxActivity<FirstViewModel>
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.FirstView);
		}
	}
}