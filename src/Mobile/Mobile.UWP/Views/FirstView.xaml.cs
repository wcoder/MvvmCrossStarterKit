using Windows.UI.Xaml.Controls;
using Mobile.Core.ViewModels;

namespace Mobile.UWP.Views
{
	public sealed partial class FirstView
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

		private void Navigation_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (Section.IsSelected)
			{
				ViewModel.GoToSecondCommand.Execute(null);
			}
		}
	}
}
