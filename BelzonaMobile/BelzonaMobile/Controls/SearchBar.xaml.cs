using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BelzonaMobile.Controls
{
    public partial class SearchBar : ContentView
    {
        public SearchBar()
        {
            InitializeComponent();
        }
        
         public static readonly BindableProperty IsShowingProperty = BindableProperty.Create(
            "IsShowing",
            typeof(bool),
            typeof(SearchBar),
            false,
            propertyChanged: onIsShowingChanged,
            defaultBindingMode: BindingMode.TwoWay
            );
            
             private async static void onIsShowingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var searchbar = (SearchBar)bindable;
            var res = (bool)newValue;
            
            if (!res)
                await searchbar.TranslateTo(0, 0, 350, Easing.SpringOut);
            else
                await searchbar.TranslateTo(0, 80, 350, Easing.SpringOut);

            

            //await Task.Delay(1000);
            //await searchbar.TranslateTo(0, 50, 350, Easing.BounceOut);

            //searchbar.IsShowing = false;
        }

        public bool IsShowing
        {
            get
            {
                return (bool)GetValue(IsShowingProperty);
            }
            private set
            {
                SetValue(IsShowingProperty, value);
            }
        }
            
            
            
            
            
        
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        "Text",
            typeof(string),
            typeof(SearchBar),
            string.Empty
            
        );
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty,value);
            }
        }
        
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        "SearchCommand",
            typeof(ICommand),
            typeof(HomeMenuButton),
            null
        );

        public ICommand SearchCommand
        {
            get
            {
                return (ICommand)GetValue(SearchCommandProperty);
            }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }
    }
}
