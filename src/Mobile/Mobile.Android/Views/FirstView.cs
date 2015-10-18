using Android.App;
using Cirrious.MvvmCross.Droid.Views;
using Mobile.Core.ViewModels;

namespace Mobile.Android.Views
{
	[Activity]
	public class FirstView : MvxActivity<FirstViewModel>
	{
		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			SetContentView(Resource.Layout.FirstView);
		}
	}
}