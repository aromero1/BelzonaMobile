using System;
using System.Collections.Generic;
using System.Linq;
using BelzonaMobile.Core.Models;
using Prism.Commands;
using Prism.Navigation;
namespace BelzonaMobile.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {

        private INavigationService navigationService;
        private IProductService productService;
        private ISeriesService seriesService;
        
        public ProductPageViewModel(INavigationService navigationService, IProductService productService, ISeriesService seriesService)
        {
            this.navigationService = navigationService;
            this.productService =  productService;
            this.seriesService = seriesService;
        }
        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            var products = await productService.GetAllProductsAsync(App.SelectedLanguage.ID);
			var series = (await seriesService.GetAllAsync(App.SelectedLanguage.ID)).ToDictionary(f => f.Id);

            ProductList = products.OrderBy(f => f.SeriesId).GroupBy(f => series.ContainsKey(f.SeriesId) ? series[f.SeriesId] : null);

        }
        IEnumerable<IGrouping<SeriesModel, ProductModel>> productList;

        public IEnumerable<IGrouping<SeriesModel, ProductModel>> ProductList
        {
            get { return productList; }
            set { SetProperty(ref productList, value); }
        }

        public string PageTitle
        {
            get
            {
                return App.LanguageResource(ElementName.ProductPageTitle);
            }
        }
        
        bool showSearchBar;

        public bool ShowSearchBar
        {
            get { return showSearchBar; }
            set { SetProperty(ref showSearchBar, value); }
        }
        
        ProductModel productSelected;
        public ProductModel ProductSelected
        {
            get { return productSelected; }
            set 
            { 
                SetProperty(ref productSelected, value);
                if (value != null)
                {
                    navigationService.NavigateAsync("ProductCarouselPage", new NavigationParameters() { { "product", value } });
                }
            }
        }
        
        string searchIcon;

        public string SearchIcon
        {
            get { 
            return !ShowSearchBar ? "SearchToolBarIcon" :"SearchToolBarIconClose" ; 
            }
            
        }

        
        
        public DelegateCommand ShowSearchCommand => new DelegateCommand(ShowSearch);

        void ShowSearch()
        {
            ShowSearchBar = !ShowSearchBar;
            RaisePropertyChanged("SearchIcon");
        }
        
    }
}
