using System.Threading.Tasks;
using Newtonsoft.Json;
using Mobile.Models;
using Mobile.Services.DataModels;
using Mobile.Services.Identities;
using Mobile.Services.Common.Http;

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
			var requestParams = new HttpRequestParameters
			{
				Url = _identity.ServerUrl
			};

			// set request type

			// serialize content

			// set auth value

			// and etc.

			return requestParams;
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
