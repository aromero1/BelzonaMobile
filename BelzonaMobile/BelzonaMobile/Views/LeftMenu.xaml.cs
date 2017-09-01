using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace BelzonaMobile.Views
{
    public partial class LeftMenu : ContentPage
    {
        public LeftMenu()
        {
            InitializeComponent();
           
            switch (Device.RuntimePlatform)
            {
                case "iOS": Icon = "burger";
                    break;
                default:
                    break;
            }


        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            Debug.WriteLine(BindingContext);
        }

      //  public static readonly BindableProperty CommandProperty =
      //BindableProperty.Create("Command", typeof(ICommand), typeof(LeftMenu), defaultBindingMode: BindingMode.TwoWay);

      //  public ICommand Command
      //  {
      //      get { return (ICommand)GetValue(CommandProperty); }
      //      set { SetValue(CommandProperty, value); }
      //  }

      //  public string Icon
      //  {
      //      get { return icon.Text; }
      //      set { icon.Text = value; }
      //  }

      //  public string Text
      //  {
      //      get { return textLabel.Text; }
      //      set { textLabel.Text = value; }
      //  }

    }
}
