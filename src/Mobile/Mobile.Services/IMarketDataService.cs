using System.Collections.Generic;
using System.Threading.Tasks;
using Mobile.Models;

namespace Mobile.Services
{
	public interface IMarketDataService
	{
		Task<IEnumerable<Market>> GetMarkets();
	}
}
