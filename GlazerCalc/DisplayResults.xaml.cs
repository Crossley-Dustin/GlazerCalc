using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DisplayResults : Page
    {
        private WindowGlazer _window;

        public DisplayResults()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Cast parameter to Window object and save to local variable.
            _window = (WindowGlazer)e.Parameter;
        }

        private void ReturnToMain_Button_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main page.
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            Height.Text = _window.Height.ToString() + " meters";
            Width.Text = _window.Width.ToString() + " meters";
            Quantity.Text = _window.Quantity.ToString() + " windows";
            WindowColor.Text = _window.Color;
            WoodLength.Text = _window.WoodLength.ToString() + " feet";
            GlassArea.Text = _window.GlassArea.ToString() + " square meters";
            OrderDate.Text = _window.DateOrdered.ToString();
        }
    }
}
