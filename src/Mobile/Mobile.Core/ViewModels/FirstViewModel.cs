using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Mobile.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		public ICommand GoToSecondCommand { get; private set; }

		public FirstViewModel()
		{
			GoToSecondCommand = new MvxCommand(() => ShowViewModel<SecondViewModel>());
		}
	}
}
