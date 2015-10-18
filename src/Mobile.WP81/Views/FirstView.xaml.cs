using Cirrious.MvvmCross.WindowsCommon.Views;
using Mobile.Core.ViewModels;

namespace Mobile.WP81.Views
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
