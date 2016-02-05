using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Models;
using Mobile.Services;

namespace Mobile.UnitTests.Mocks
{
	public class MockMarketDataService : IMarketDataService
	{
		private IEnumerable<Market> _data;

		public MockMarketDataService()
		{
			_data = new List<Market>();
		}

		public MockMarketDataService(IEnumerable<Market> data)
		{
			_data = data;
		}

		public async Task<IEnumerable<Market>> GetMarkets()
		{
			return await Task.Factory.StartNew(() => _data);
		}
	}
}
