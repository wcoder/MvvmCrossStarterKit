using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mobile.Services.Common.Http
{
	public class NoCacheableHttpService : BaseHttpService
	{
		protected override void PrepareHeaders(HttpClient client, HttpRequestMessage requestMessage, AuthenticationHeaderValue auth = null)
		{
			base.PrepareHeaders(client, requestMessage, auth);

			client.DefaultRequestHeaders.Add("If-Modified-Since", DateTime.UtcNow.ToString("r")); //Disable caching
		}
	}
}

