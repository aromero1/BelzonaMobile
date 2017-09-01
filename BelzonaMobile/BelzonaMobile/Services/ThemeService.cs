using BelzonaMobile.Interfaces;
using BelzonaMobile.Themes;
using System.Linq;
using Xamarin.Forms;

namespace BelzonaMobile.Services
{
	public class ThemeService : IThemeService
	{
		public void setMainTheme()
		{
			initializeResources();
			var masterTheme = new MasterTheme();
			addStyles(masterTheme.Resources);
		}
		private static void addStyles(ResourceDictionary resources)
		{
			foreach (var item in resources)
			{
				if (Application.Current.Resources.ContainsKey(item.Key))
				{
					Application.Current.Resources[item.Key] = item.Value;
				}
				else
				{
					Application.Current.Resources.Add(item.Key, item.Value);
				}
			}
		}
		private static void initializeResources()
		{
			if (Application.Current.Resources != null)
			{
				foreach (var item in Application.Current.Resources.ToList())
				{
					Application.Current.Resources[item.Key] = null;
				}
				Application.Current.Resources.Clear();
			}
			else
			{
				Application.Current.Resources = new ResourceDictionary();
			}
		}
	}
}