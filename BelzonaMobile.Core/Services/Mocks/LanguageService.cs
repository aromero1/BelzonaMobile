using BelzonaMobile.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelzonaMobile.Core.Services.Mocks
{
	public class LanguageService : ILanguageService
	{
		//private IConnectionService connectrionservice;

		public async Task<IEnumerable<LanguageModel>> GetAllAsync()
		{
			await Task.Delay(50);

			var res = new LanguageModel[] {
				new LanguageModel() { ID = 1, IsDefault = false, Name = "English - UK" },
				new LanguageModel() { ID = 2, IsDefault = true, Name = "English - USA" },
				new LanguageModel() { ID = 3, IsDefault = false, Name = "Español - América Latina" },
				new LanguageModel() { ID = 4, IsDefault = false, Name = "Español - Europa" },
				new LanguageModel() { ID = 5, IsDefault = false, Name = "Français" },
				new LanguageModel() { ID = 6, IsDefault = false, Name = "Deutsch" },
				new LanguageModel() { ID = 7, IsDefault = false, Name = "Pусский" },//Russian
				new LanguageModel() { ID = 8, IsDefault = false, Name = "中文" },//Chinese

			};
			
			return res;
		}
	}
}