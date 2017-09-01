using BelzonaMobile.Interfaces;
using Prism.Commands;
using Prism.Navigation;

namespace BelzonaMobile.ViewModels
{
	public class MainMasterPageViewModel : ViewModelBase
	{
	
        INavigationService navigationService;
		public MainMasterPageViewModel(INavigationService navigationService/*IThemeService ThemeService*/)
		{
			this.navigationService = navigationService;
			
		}
        
        public string LanguageTextDisplay {get{
                return App.LanguageResource(ElementName.Languages);
            }}
            
            public DelegateCommand ShowLanguageCommand => new DelegateCommand(ShowLanguage);

        private async void ShowLanguage()
        {
            await navigationService.NavigateAsync("CustomNavigationPage/GettingStarted");
        }
	}
}