using BelzonaMobile.Core.Models;
using System.Collections.Generic;
using Prism.Navigation;
using BelzonaMobile.Core.Services;
using System;
using Prism.Commands;
using System.Linq;
using BelzonaMobile.Resources;

namespace BelzonaMobile.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        INavigationService navigationService;
       


        public HomePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public DelegateCommand GotoProductsCommand => new DelegateCommand(GotoProducts);

        private async void GotoProducts()
        {
            await navigationService.NavigateAsync("ProductPage", null, false, true);
        }

       
        public string ProductButtonTitle 
        {
            get{  return App.LanguageResource(ElementName.ProductButton);}

        }
		public string IndustriesButtonTitle
		{
			get { return App.LanguageResource(ElementName.IndustriesButton); }

		}
		public string ApplicationsButtonTitle
		{
			get { return App.LanguageResource(ElementName.ApplicationButton); }

		}
		public string VideosButtonTitle
		{
            get { return App.LanguageResource(ElementName.VideoButton); }

		}
    }


}
