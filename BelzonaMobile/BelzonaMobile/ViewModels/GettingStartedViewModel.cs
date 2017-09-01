using BelzonaMobile.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using BelzonaMobile.Interfaces;

namespace BelzonaMobile.ViewModels
{
    public class GettingStartedViewModel : ViewModelBase
    {
        private ILanguageService languageService;
        private IThemeService themeService;
        private INavigationService navigationService;
        public GettingStartedViewModel(INavigationService navigationService, ILanguageService languageService, IThemeService ThemeService)
        {
            this.languageService = languageService;
            this.themeService = ThemeService;
            this.navigationService = navigationService;
            themeService.setMainTheme();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            Languages = await languageService.GetAllAsync();
        }

        private LanguageModel selectedLanguage;

        public LanguageModel SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                SetProperty(ref selectedLanguage, value);
                if (value != null)
                {
                    App.SelectedLanguage = value;
                    navigate();
                }
            }
        }

        private IEnumerable<LanguageModel> languages;

        public IEnumerable<LanguageModel> Languages
        {
            get { return languages; }
            set { SetProperty(ref languages, value); }
        }

        private async void  navigate (){
            await navigationService.NavigateAsync("//MainMasterPage/CustomNavigationPage/HomePage", null, false, true);
        }



	}
}
