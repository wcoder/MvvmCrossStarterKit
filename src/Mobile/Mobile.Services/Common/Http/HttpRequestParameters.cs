using System.Collections.Generic;
using System.Net.Http;

namespace Mobile.Services.Common.Http
{
	public class HttpRequestParameters
	{
		public string Url { get; set; }

		public HttpMethod Method { get; set; }

		public Dictionary<string, string> Parameters { get; set; }

		public string ContentType { get; set; }

		public string Content { get; set; }

		public string AuthHeader { get; set; }

		public HttpRequestParameters()
		{
			Method = HttpMethod.Get;
		}
	}
}
