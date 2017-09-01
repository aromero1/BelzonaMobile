using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BelzonaMobile.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LeftMenuItem : ContentView
	{
        
		public LeftMenuItem ()
		{
            
			InitializeComponent ();
		}
		public string Icon 
		{
			get
			{
				return icon.Text;
			}
			set
			{
				icon.Text = value;
			}
		}
		public static readonly BindableProperty TextProperty = BindableProperty.Create(
		"Text",
			typeof(string),
			typeof(LeftMenuItem),
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
				SetValue(TextProperty, value);
			}
		}
        
        public static readonly BindableProperty ShowLaguageCommandProperty = BindableProperty.Create(
        "ShowLaguageCommand",
            typeof(ICommand),
            typeof(LeftMenuItem),
            null
        );

        public ICommand ShowLaguageCommand
        {
            get
            {
                return (ICommand)GetValue(ShowLaguageCommandProperty);
            }
            set
            {
                SetValue(ShowLaguageCommandProperty, value);
            }
        }
        
	}
	
}