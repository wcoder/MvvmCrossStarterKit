using MvvmCross.Uwp.Views;
using Mobile.Core.ViewModels;

namespace Mobile.UWP.Views
{
	[MvxRegion("MainContent")]
	public sealed partial class SecondView : MvxWindowsPage
    {
		public new SecondViewModel ViewModel
		{
			get => (SecondViewModel) base.ViewModel;
		    set => base.ViewModel = value;
		}

		public SecondView()
		{
			InitializeComponent();
		}
	}
}
