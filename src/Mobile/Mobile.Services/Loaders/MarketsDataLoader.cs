using System.Threading.Tasks;
using Mobile.Services.Common;
using Mobile.Services.Identities;
using Newtonsoft.Json;
using Mobile.Models;
using Mobile.Services.DataModels;

namespace Mobile.Services.Loaders
{
	public class MarketsDataLoader : IHttpDataLoader
	{
		private readonly MarketsIdentity _identity;

		public MarketsDataLoader(MarketsIdentity identity)
		{
			_identity = identity;
		}

		public HttpRequestParameters GetParameters()
		{
			return new HttpRequestParameters
			{
				Url = _identity.ServerUrl
			};
		}

		public async Task<TResult> Deserialize<TResult>(string response) where TResult : class, new()
		{
			var result = await Task.Factory.StartNew<TResult>(() =>
			{
				var data = JsonConvert.DeserializeObject<MarketResponse>(response);

				return new MarketsDataModel { Markets = data.markets } as TResult;
			});
			return result;
		}
	}
}
