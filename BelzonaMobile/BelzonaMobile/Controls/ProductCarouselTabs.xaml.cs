using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BelzonaMobile.Controls
{
    public partial class ProductCarouselTabs : ContentView
    {
        static void HandleValidateValueDelegate(BindableObject bindable, object value)
        {

        }

        public ProductCarouselTabs()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty PositionProperty = BindableProperty.Create(
        "Position",
            typeof(int),
            typeof(ProductCarouselTabs),
            0,
            defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (ProductCarouselTabs)bindable;
                if (newValue != oldValue)
                {
                    control.Position = (int)newValue;
                    
                }
                //Position = 
            }
        );
        int flag = 0;
        public int Position
        {
            get
            {
                return (int)GetValue(PositionProperty);
            }
            set
            {
                SetValue(PositionProperty, value);
                if (flag != value)
                {
					SetPosition(null);
                    }
                flag = value;
            }
        }




        void Handle_Clicked(object sender, System.EventArgs e)
        {
            SetPosition((Button)sender);

        }

        private void SetPosition(Button tapped = null)
        {
            if (tapped != null)
            {
                if (tapped == Tab0)
                    Position = 0;

                if (tapped == Tab1)
                    Position = 1;

                if (tapped == Tab2)
                    Position = 2;

                if (tapped == Tab3)
                    Position = 3;
            }
            Tab0.BackgroundColor = Tab1.BackgroundColor = Tab2.BackgroundColor = Tab3.BackgroundColor = (Color)Application.Current.Resources["BelzonaOrange"];

            switch (Position)
            {
                case 0:
                    Tab0.BackgroundColor = (Color)Application.Current.Resources["BelzonaSilver"];
                    break;
                case 1:
                    Tab1.BackgroundColor = (Color)Application.Current.Resources["BelzonaSilver"];
                    break;
                case 2:
                    Tab2.BackgroundColor = (Color)Application.Current.Resources["BelzonaSilver"];
                    break;
                case 3:
                    Tab3.BackgroundColor = (Color)Application.Current.Resources["BelzonaSilver"];
                    break;


                default:
                    break;
            }

        }
    }
}
