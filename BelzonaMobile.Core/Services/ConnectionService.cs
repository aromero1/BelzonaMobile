using Newtonsoft.Json;
using BelzonaMobile.Core.Models;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BelzonaMobile.Core.Services
{
	public class ConnectionService : IConnectionService
	{
		private static HttpClient client;
		private static string host = "";
		private ICredentialService credentialService;
		private IPageDialogService dialogService;

		static ConnectionService()
		{
			var handler = new HttpClientHandler();
			//handler.AutomaticDecompression = System.Net.Http.DecompressionMethods.GZip;
			client = new HttpClient(handler);
			client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
		}

		public ConnectionService(ICredentialService credentialService, IPageDialogService dialogService)
		{
			this.credentialService = credentialService;
			this.dialogService = dialogService;
		}

		public bool IsAuthenticated()
		{
			var token = credentialService.GetToken();

			if (client.DefaultRequestHeaders.Authorization == null && string.IsNullOrEmpty(token))
				return false;

			if (client.DefaultRequestHeaders.Authorization != null)
				return true;

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			return true;
		}

		public async Task<bool> AuthenticateAsync(string username, string password)
		{
			var content = new FormUrlEncodedContent(
				new Dictionary<string, string>()
					{ {"grant_type", "password"}, {"username", username}, {"password", password} });

			HttpResponseMessage response = null;

			try
			{
				response = await client.PostAsync(host + "token", content).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				await handleError(ex);
				return false;
			}

			if (response.IsSuccessStatusCode)
			{
				var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				var token = JsonConvert.DeserializeObject<TokenModel>(str);

				credentialService.DeleteToken();
				credentialService.SaveToken(username, token.access_token);

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

				return true;
			}

			return false;
		}

		public async Task<T> GetAsync<T>(string requestUri, Dictionary<string, string> urlParams = null)
		{
			var urlp = await handleUrlParams(urlParams).ConfigureAwait(false);

			HttpResponseMessage response;

			try
			{
				response = await client.GetAsync(host + requestUri + (urlp ?? string.Empty)).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				await handleError(ex);
				return default(T);
			}

			if (response.IsSuccessStatusCode)
				return await handleResponse<T>(response).ConfigureAwait(false);

			await handleHttpError(response).ConfigureAwait(false);

			return default(T);
		}

		public Task PostAsync(string requestUri, object content, Dictionary<string, string> urlParams = null)
		{
			return handlePostPutAsync<object>(requestUri, content, urlParams, false);
		}

		public Task<T> PostAsync<T>(string requestUri, object content, Dictionary<string, string> urlParams = null)
		{
			return handlePostPutAsync<T>(requestUri, content, urlParams);
		}

		public Task PutAsync(string requestUri, object content, Dictionary<string, string> urlParams = null)
		{
			return handlePostPutAsync<object>(requestUri, content, urlParams, false, false);
		}

		public Task<T> PutAsync<T>(string requestUri, object content, Dictionary<string, string> urlParams = null)
		{
			return handlePostPutAsync<T>(requestUri, content, urlParams, true, false);
		}

		public Task DeleteAsync(string requestUri, Dictionary<string, string> urlParams = null)
		{
			return handleDeleteAsync<object>(requestUri, urlParams, false);
		}

		public Task<T> DeleteAsync<T>(string requestUri, Dictionary<string, string> urlParams = null)
		{
			return handleDeleteAsync<T>(requestUri, urlParams);
		}

		private Task handleError(Exception ex)
		{
			return dialogService.DisplayAlertAsync("Error de Conexion", ex.Message, "Ok");
		}

		private async Task<T> handleDeleteAsync<T>(string requestUri, Dictionary<string, string> urlParams = null, bool handleResponse = true)
		{
			var urlp = await handleUrlParams(urlParams).ConfigureAwait(false);

			HttpResponseMessage response;

			try
			{
				response = await client.DeleteAsync(host + requestUri + (urlp ?? string.Empty)).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				await handleError(ex);
				return default(T);
			}

			if (response.IsSuccessStatusCode)
				return handleResponse ? await handleResponse<T>(response).ConfigureAwait(false) : default(T);

			await handleHttpError(response).ConfigureAwait(false);

			return default(T);
		}

		private async Task<T> handlePostPutAsync<T>(string requestUri, object content, Dictionary<string, string> urlParams, bool handleResponse = true, bool isPost = true)
		{
			var urlp = await handleUrlParams(urlParams).ConfigureAwait(false);

			StringContent strcontent = null;

			strcontent = await handleContent(content, strcontent).ConfigureAwait(false);

			HttpResponseMessage response;

			try
			{
				if (isPost)
					response = await client.PostAsync(host + requestUri + (urlp ?? string.Empty), strcontent).ConfigureAwait(false);
				else
					response = await client.PutAsync(host + requestUri + (urlp ?? string.Empty), strcontent).ConfigureAwait(false);
			}
			catch (Exception ex)
			{
				await handleError(ex);
				return default(T);
			}

			if (response.IsSuccessStatusCode)
				return handleResponse ? await handleResponse<T>(response).ConfigureAwait(false) : default(T);

			await handleHttpError(response).ConfigureAwait(false);

			return default(T);
		}

		private async Task<StringContent> handleContent(object content, StringContent strcontent)
		{
			if (content != null)
			{
				var str = await Task.Run(() => JsonConvert.SerializeObject(content)).ConfigureAwait(false);
				strcontent = new StringContent(str, Encoding.UTF8, "application/json");
			}

			return strcontent;
		}

		private async Task<string> handleUrlParams(Dictionary<string, string> urlParams)
		{
			string urlp = null;

			if (urlParams != null)
			{
				var content = new FormUrlEncodedContent(urlParams);
				urlp = "?" + (await content.ReadAsStringAsync().ConfigureAwait(false));
			}

			return urlp;
		}

		private async Task<T> handleResponse<T>(HttpResponseMessage response)
		{
			var str = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			T data = default(T);
			data = JsonConvert.DeserializeObject<T>(str);

			return data;
		}

		private static async Task handleHttpError(HttpResponseMessage response)
		{
			var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			if (string.IsNullOrEmpty(error))
				throw new HttpRequestException(response.StatusCode.ToString());
			var status = JsonConvert.DeserializeObject<StatusMessage>(error);

			throw new HttpRequestException(status.Message);
		}
	}

	class StatusMessage
	{
		public string Message { get; set; }
	}

	class TokenModel : IEntityModel
	{
		public string access_token { get; set; }
	}
}
