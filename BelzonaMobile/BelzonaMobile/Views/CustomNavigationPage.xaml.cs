using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public partial class CustomNavigationPage : NavigationPage, INavigationPageOptions
    {
        public CustomNavigationPage()
        {
            InitializeComponent();
        }

        public bool ClearNavigationStackOnNavigation => false;
    }
}
