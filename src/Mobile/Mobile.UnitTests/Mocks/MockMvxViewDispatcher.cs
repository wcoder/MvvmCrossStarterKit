using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;

namespace Mobile.UnitTests.Mocks
{
	public class MockMvxViewDispatcher : MvxMainThreadDispatcher, IMvxViewDispatcher
	{
		public List<IMvxViewModel> CloseRequests = new List<IMvxViewModel>();
		public List<MvxViewModelRequest> NavigateRequests = new List<MvxViewModelRequest>();

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			NavigateRequests.Add(request);
			return true;
		}

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			throw new NotImplementedException();
		}

		public bool RequestMainThreadAction(Action action)
		{
			action();
			return true;
		}
	}
}
