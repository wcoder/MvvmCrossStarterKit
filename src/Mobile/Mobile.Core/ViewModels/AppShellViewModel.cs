using MvvmCross.Core.ViewModels;

namespace Mobile.Core.ViewModels
{
	public class AppShellViewModel : MvxViewModel
	{
		public IMvxCommand GoToFirstCommand { get; private set; }
		public IMvxCommand GoToSecondCommand { get; private set; }

		public AppShellViewModel()
		{
			GoToFirstCommand = new MvxCommand(() => ShowViewModel<FirstViewModel>());
			GoToSecondCommand = new MvxCommand(() => ShowViewModel<SecondViewModel>());
		}
	}
}
