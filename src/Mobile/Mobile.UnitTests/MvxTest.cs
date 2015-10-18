using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Test.Core;
using Cirrious.MvvmCross.Views;
using Mobile.UnitTests.Mocks;

namespace Mobile.UnitTests
{
	public class MvxTest : MvxIoCSupportingTest
	{
		protected MockMvxViewDispatcher CreateMockNavigation()
		{
			var dispatcher = new MockMvxViewDispatcher();
			Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(dispatcher);
			Ioc.RegisterSingleton<IMvxViewDispatcher>(dispatcher);
			return dispatcher;
		}
	}
}
