using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Services.Common;
using Mobile.Services.Identities;
using Mobile.Services.Loaders;
using Mobile.Services.DataModels;
using Mobile.Models;

namespace Mobile.Services
{
	public class MarketDataService : BaseHttpService, IMarketDataService
	{
		private const string FakeApiUrl = "https://dl.dropboxusercontent.com/u/30506652/data/data.json";

		public async Task<IEnumerable<Market>> GetMarkets()
		{
			var identity = new MarketsIdentity
			{
				ServerUrl = FakeApiUrl
			};

			var data = await LoadAsync<MarketsDataModel>(new MarketsDataLoader(identity));

			return data.Markets;
		}
	}
}
