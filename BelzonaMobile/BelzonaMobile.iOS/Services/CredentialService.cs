using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using BelzonaMobile.Core.Models;

namespace BelzonaMobile.iOS.Services
{
	public class CredentialService : ICredentialService
	{
		public void SaveToken(string username, string Token) { }
		public string GetToken() { return "Token"; }
		public void DeleteToken() { }
	}
}