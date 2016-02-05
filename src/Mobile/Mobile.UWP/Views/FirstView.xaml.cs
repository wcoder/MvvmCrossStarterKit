using Mobile.Core.ViewModels;
using MvvmCross.WindowsUWP.Views;

namespace Mobile.UWP.Views
{
	public sealed partial class FirstView : MvxWindowsPage
	{
		public new FirstViewModel ViewModel
		{
			get { return (FirstViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public FirstView()
		{
			InitializeComponent();
		}
	}
}
