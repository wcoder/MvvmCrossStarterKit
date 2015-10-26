using System.Threading.Tasks;

namespace Mobile.Services.Common
{
	public interface IHttpDataLoader
	{
		HttpRequestParameters GetParameters();
		Task<TResult> Deserialize<TResult>(string response) where TResult : class, new();
	}
}
