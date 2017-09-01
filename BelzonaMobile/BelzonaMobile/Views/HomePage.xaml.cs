using BelzonaMobile.Controls;
using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            if (App.DeviceWidth == 0)
            {
                App.DeviceWidth = width;
                App.DeviceHeight = height;
            }
            base.OnSizeAllocated(width, height);

        }


    }
}
