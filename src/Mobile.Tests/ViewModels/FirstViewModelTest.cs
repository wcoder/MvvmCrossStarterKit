using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mobile.Core.ViewModels;

namespace Mobile.Tests.ViewModels
{
	[TestClass]
	public class FirstViewModelTest : MvxTest
	{
		[TestMethod]
		public void GoCausesNoNavigationAfterChangeHello()
		{
			ClearAll();

			var mockNavigation = CreateMockNavigation();
			var viewModel = new FirstViewModel();
			var hello = "Test string";

			viewModel.Hello = hello;

			Assert.AreEqual(0, mockNavigation.NavigateRequests.Count);
		}

		[TestMethod]
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
