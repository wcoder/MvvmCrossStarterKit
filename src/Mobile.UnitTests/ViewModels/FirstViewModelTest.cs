using Mobile.Core.ViewModels;
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
			var viewModel = new FirstViewModel();
			var hello = "Test string";

			viewModel.Hello = hello;

			Assert.AreEqual(0, mockNavigation.NavigateRequests.Count);
		}

		[Test]
		public void ChangesHello()
		{
			ClearAll();

			var viewModel = new FirstViewModel();
			var hello = "Test string";

			viewModel.Hello = hello;

			Assert.AreEqual(hello, viewModel.Hello);
		}
	}
}
