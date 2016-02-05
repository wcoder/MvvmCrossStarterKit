using Mobile.Core.ViewModels;
using Mobile.UnitTests.Mocks;
using NUnit.Framework;

namespace Mobile.UnitTests.ViewModels
{
	[TestFixture]
	public class FirstViewModelTest : MvxTest
	{
		[Test]
		public void GoCausesNoNavigationAfterChangeHello()
		{
			ClearAll();

			var mockNavigation = CreateMockNavigation();
			var dataService = new MockMarketDataService();
			var viewModel = new FirstViewModel(dataService);
			var hello = "Test string";

			viewModel.Hello = hello;

			Assert.AreEqual(0, mockNavigation.NavigateRequests.Count);
		}

		[Test]
		public void ChangesHello()
		{
			ClearAll();

			var dataService = new MockMarketDataService();
			var viewModel = new FirstViewModel(dataService);
			var hello = "Test string";

			viewModel.Hello = hello;

			Assert.AreEqual(hello, viewModel.Hello);
		}
	}
}
