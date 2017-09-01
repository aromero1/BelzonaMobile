using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BelzonaMobile.Core.Models;

namespace BelzonaMobile.Droid.Services
{
	public class CredentialService : ICredentialService
	{
		public void SaveToken(string username, string Token) { }
		public string GetToken() { return "Token"; }
		public void DeleteToken() { }
	}
}