using BelzonaMobile.Core.Models;
using BelzonaMobile.Interfaces;
using BelzonaMobile.Resources;
using BelzonaMobile.Services;
using BelzonaMobile.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Linq;
using BelzonaMobile.ViewModels;

namespace BelzonaMobile
{
	public partial class App : PrismApplication
	{
		public static LanguageModel SelectedLanguage { get; set; }
        public static double DeviceWidth { get; set; }
        public static double DeviceHeight { get; set; }
		public static string ProductsImageUrl = "http://www.belzona.com/assets/data/images/products/gallery/";

		public App(IPlatformInitializer initializer = null) : base(initializer)
		{
		}

		public static string LanguageResource(ElementName element)
		{
			var resource = LanguageResources.TextResources.FirstOrDefault(f => f.ElementName == element && f.LanguageId == SelectedLanguage.ID).ToString();

			if (resource == null)
			{
				resource = LanguageResources.TextResources.FirstOrDefault(f => f.ElementName == element && f.LanguageId == 1).ToString();
			}

			return resource;
		}

		protected override void OnInitialized()
		{
			InitializeComponent();

			//NavigationService.NavigateAsync("MainMasterPage/CustomNavigationPage/HomePage");
			NavigationService.NavigateAsync("GettingStarted");
		}

		protected override void RegisterTypes()
		{
			//services
			Container.RegisterType(typeof(IThemeService), typeof(ThemeService), new ContainerControlledLifetimeManager());
			Container.RegisterType(typeof(ILanguageService), typeof(BelzonaMobile.Core.Services.Mocks.LanguageService), new ContainerControlledLifetimeManager());
			Container.RegisterType(typeof(IProductService), typeof(BelzonaMobile.Core.Services.Mocks.ProductService), new ContainerControlledLifetimeManager());
			Container.RegisterType(typeof(ISeriesService), typeof(BelzonaMobile.Core.Services.Mocks.SeriesService), new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof(IYouTubeVideoService), typeof(BelzonaMobile.Core.Services.Mocks.YouTubeVideoService), new ContainerControlledLifetimeManager());
			Container.RegisterType(typeof(IConnectionService), typeof(BelzonaMobile.Core.Services.ConnectionService), new ContainerControlledLifetimeManager());

			//Pages
			Container.RegisterTypeForNavigation<CustomNavigationPage>();
			Container.RegisterTypeForNavigation<MainMasterPage>();
			Container.RegisterTypeForNavigation<HomePage>();
			Container.RegisterTypeForNavigation<GettingStarted>();
			Container.RegisterTypeForNavigation<ProductPage>();
			Container.RegisterTypeForNavigation<ProductCarouselPage>();
			Container.RegisterTypeForNavigation<DocumentViewerPage>();
			Container.RegisterTypeForNavigation<ProductVideoPlayer>();
		}
	}
}