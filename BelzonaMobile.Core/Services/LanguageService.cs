using BelzonaMobile.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelzonaMobile.Core.Services
{
	public class LanguageService : ILanguageService
	{
		private IConnectionService connectionservice;

		public LanguageService(IConnectionService connectionservice)
		{
			this.connectionservice = connectionservice;
		}
		public Task<IEnumerable<LanguageModel>> GetAllAsync()
		{
			return connectionservice.GetAsync<IEnumerable<LanguageModel>>("api/language");
		}
	}
}