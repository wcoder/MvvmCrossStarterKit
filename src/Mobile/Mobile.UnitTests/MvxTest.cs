using Mobile.UnitTests.Mocks;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;

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
