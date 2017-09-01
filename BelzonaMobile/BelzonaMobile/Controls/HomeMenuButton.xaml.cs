using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace BelzonaMobile.Controls
{
    public partial class HomeMenuButton : ContentView
    {
        public HomeMenuButton()
        {
            InitializeComponent();
        }




        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        "Text",
            typeof(string),
            typeof(HomeMenuButton),
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

		public static readonly BindableProperty IconProperty = BindableProperty.Create(
		"Icon",
			typeof(string),
			typeof(HomeMenuButton),
			string.Empty
		);



		public string Icon
		{
			get
			{
				return (string)GetValue(IconProperty);
			}
			set
			{
				SetValue(IconProperty, value);
			}
		}
        
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        "Command",
            typeof(ICommand),
            typeof(HomeMenuButton),
            null
        );



        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }




    }
}
