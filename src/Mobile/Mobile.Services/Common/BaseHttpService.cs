using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernHttpClient;

namespace Mobile.Services.Common
{
	public class BaseHttpService
	{
		public const string JsonContentType = "application/json";

		protected virtual async Task<T> LoadAsync<T>(IHttpDataLoader dataLoader) where T : class, new()
		{
			var parameters = dataLoader.GetParameters();
			var response = await GetResponseMessage(parameters);
			var data = await HandleResponse(response);

			return await dataLoader.Deserialize<T>(data);
		}

		protected virtual async Task<HttpResponseMessage> GetResponseMessage(HttpRequestParameters requestParams)
		{
			using (var httpClient = new HttpClient(new NativeMessageHandler()))
			{
				var requestMessage = await GetHttpRequestMessage(requestParams.Url, requestParams.Method, requestParams.Parameters);
				if (requestParams.Content != null && requestParams.ContentType != null)
				{
					requestMessage.Content = new StringContent(requestParams.Content, Encoding.UTF8, requestParams.ContentType);
				}
				var authHeader = requestParams.AuthHeader != null ? new AuthenticationHeaderValue("Basic", requestParams.AuthHeader) : null;
				PrepareHeaders(httpClient, requestMessage, authHeader);

				var response = await httpClient.SendAsync(requestMessage);
				return response;
			}
		}

		protected virtual async Task<HttpRequestMessage> GetHttpRequestMessage(string url,
			HttpMethod httpMethod, Dictionary<string, string> urlParameters = null)
		{
			if (urlParameters != null && urlParameters.Count > 0)
			{
				var builder = new UriBuilder(url);
				builder.Query = await new FormUrlEncodedContent(urlParameters).ReadAsStringAsync();
				url = builder.Uri.ToString();
			}
			return new HttpRequestMessage(httpMethod, url);
		}

		protected virtual void PrepareHeaders(HttpClient client,
			HttpRequestMessage requestMessage, AuthenticationHeaderValue auth = null)
		{
			requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
			if (auth != null)
			{
				requestMessage.Headers.Authorization = auth;
			}
		}

		protected virtual Task<string> HandleResponse(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				return response.Content.ReadAsStringAsync();
			}

			throw new WebException(
				string.Format("Request {0} to {1} failed with status {2}",
				response.RequestMessage.Method,
				response.RequestMessage.RequestUri,
				response.StatusCode));
		}
	}
}
