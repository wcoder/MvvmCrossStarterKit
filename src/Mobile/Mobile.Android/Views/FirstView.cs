using Android.App;
using Mobile.Core.ViewModels;
using MvvmCross.Droid.Views;

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