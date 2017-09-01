namespace BelzonaMobile.Core.Models
{
	public interface ICredentialService
	{
		void SaveToken(string username, string Token);
		string GetToken();
		void DeleteToken();
	}
}
