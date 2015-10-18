using System;
using System.Collections.Generic;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace Mobile.Tests.Mocks
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
