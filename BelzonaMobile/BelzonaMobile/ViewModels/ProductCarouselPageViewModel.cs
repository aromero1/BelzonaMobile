using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using BelzonaMobile.Views;
using Prism.Navigation;
using BelzonaMobile.Core.Models;

namespace BelzonaMobile.ViewModels
{
    public class ProductCarouselPageViewModel : ViewModelBase, INavigatedAware
    {
        INavigationService navigationService;
        IProductService productService;
        IYouTubeVideoService youtubeService;
        
        public ProductCarouselPageViewModel(INavigationService navigationService, IProductService productService ,IYouTubeVideoService youtubeService)
        {
            this.navigationService = navigationService;
            this.productService = productService;
            this.youtubeService = youtubeService;
        }
        private ObservableCollection<ContentView> sections;
        public ObservableCollection<ContentView> Sections
        {
            get { return sections; }
            set
            {
                SetProperty(ref sections, value);
            }
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters?.ContainsKey("product") == true)
            {
                Product = (ProductModel)parameters["product"];
                Product.ProductDetail = await productService.GetProductDetailAsync(App.SelectedLanguage.ID, product.ProductId);
              	Product.Documents = await productService.GetAllDocumentsAsync(App.SelectedLanguage.ID, Product.ProductId);
                Videos = await youtubeService.GetAllAsync(Product.Name);
             }
            Sections = new ObservableCollection<ContentView>();
            Sections.Add(new ProductDetailTab(){BindingContext = this});
            Sections.Add(new ProductDocumentTab(){BindingContext = this});
            Sections.Add(new ProductVideosTab() { BindingContext = this});
            Sections.Add(new ContentView() { Content = new Label() { Text = "Suggestions??" } });
        }

        ProductModel product;
        public ProductModel Product
        {
            get { return product; }
            set { SetProperty(ref product, value); }
        }
        
        IEnumerable<Item<Id>> videos;
        public IEnumerable<Item<Id>> Videos
        {
            get { return videos; }
            set { SetProperty(ref videos, value); }
        }
        
        ProductDocumentModel selectedDocument;
        public ProductDocumentModel SelectedDocument
        {
            get { return selectedDocument; }
            set { 
            SetProperty(ref selectedDocument, value);
                if (value != null)
                {
					navigationService.NavigateAsync("DocumentViewerPage", new NavigationParameters(){{"document", SelectedDocument}});
                }
             }
        }
        
        Item<Id> selectedVideo;
        public Item<Id> SelectedVideo
        {
            get { return selectedVideo; }
            set { 
            SetProperty(ref selectedVideo, value);
                if (value != null)
                {
                    navigationService.NavigateAsync("ProductVideoPlayer", new NavigationParameters(){{"video", SelectedVideo},{"title",Product.Name}});
                }
             }
        }
        
        int tabPosition;
        public int TabPosition
        {
            get { return tabPosition; }
            set { SetProperty(ref tabPosition, value); }
        }
    }

}
