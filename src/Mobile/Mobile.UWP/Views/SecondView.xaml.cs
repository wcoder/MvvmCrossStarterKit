using Mobile.Core.ViewModels;
using MvvmCross.WindowsUWP.Views;

namespace Mobile.UWP.Views
{
	[MvxRegion("MainContent")]
	public sealed partial class SecondView
	{
		public new SecondViewModel ViewModel
		{
			get { return (SecondViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public SecondView()
		{
			InitializeComponent();
		}
	}
}
