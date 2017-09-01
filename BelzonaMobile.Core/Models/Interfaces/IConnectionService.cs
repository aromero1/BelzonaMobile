using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelzonaMobile.Core.Models
{
	public interface IConnectionService
	{
		bool IsAuthenticated();
		Task<bool> AuthenticateAsync(string username, string password);
		Task<T> GetAsync<T>(string requestUri, Dictionary<string, string> urlParams = null);
		Task PostAsync(string requestUri, object content, Dictionary<string, string> urlParams = null);
		Task<T> PostAsync<T>(string requestUri, object content, Dictionary<string, string> urlParams = null);
		Task PutAsync(string requestUri, object content, Dictionary<string, string> urlParams = null);
		Task<T> PutAsync<T>(string requestUri, object content, Dictionary<string, string> urlParams = null);
		Task DeleteAsync(string requestUri, Dictionary<string, string> urlParams = null);
		Task<T> DeleteAsync<T>(string requestUri, Dictionary<string, string> urlParams = null);
	}
}
