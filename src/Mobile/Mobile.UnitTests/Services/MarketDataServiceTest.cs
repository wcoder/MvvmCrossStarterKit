using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Mobile.Models;
using Mobile.UnitTests.Mocks;

namespace Mobile.UnitTests.Services
{
	[TestFixture]
	public class MarketDataServiceTest : MvxTest
	{
		[Test]
		public async Task MarketDataService_GetEmptyData()
		{
			var dataService = new MockMarketDataService();

			var response = await dataService.GetMarkets();

			Assert.AreEqual(0, response.Count());
		}

		[Test]
		public async Task MarketDataService_GetList()
		{
			var data = new List<Market>
			{
				new Market(),
				new Market()
			};
			var dataService = new MockMarketDataService(data);

			var response = await dataService.GetMarkets();

			Assert.AreEqual(data.Count, response.Count());
		}

		// TODO: add tests for DataLoaders
	}
}
