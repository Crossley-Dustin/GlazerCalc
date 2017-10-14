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
using Windows.System;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static double MIN_HEIGHT = .75;
        private static double MAX_HEIGHT = 3;
        private static double MIN_WIDTH = .5;
        private static double MAX_WIDTH = 5;

        public MainPage()
        {
            this.InitializeComponent();
        }


        private void Height_TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // If any key other than a number or tab, handle, which cancels key and returns back to field
            if (!ValidDimensionKey(sender, e))
                e.Handled = true;
        }

        private void Width_TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // If any key other than a number or tab, handle, which cancels key and returns back to field
            if (!ValidDimensionKey(sender,e))
                e.Handled = true;
        }

        private bool ValidDimensionKey(object sender, KeyRoutedEventArgs e)
        {
            // Returns false if key is anything other than a number, period, or tab, otherwise true
            if (!(e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9)
                && !(e.Key >= VirtualKey.NumberPad0 && e.Key <= VirtualKey.NumberPad9)
                && !(e.Key == VirtualKey.Decimal) 
                && !((int)e.Key == 190)
                && !(e.Key == VirtualKey.Tab)
                )
                return false;
            else
                return true;
        }

        private void Validate_Height(double Height)
        {
            // Check value is within range
            if (Height < MIN_HEIGHT || Height > MAX_HEIGHT)
            {
                ContentDialog HeightMsg = new ContentDialog
                {
                    Title = "Height value out of range.",
                    CloseButtonText = "OK"
                };

                if (Height < MIN_HEIGHT)
                    HeightMsg.Content = "Height must be above " + MIN_HEIGHT + ".";
                if (Height > MAX_HEIGHT)
                    HeightMsg.Content = "Height must be below " + MAX_HEIGHT + ".";

                DisplayDialog(HeightMsg);
            }
        }

        private void Validate_Width(double Width)
        {
            // Check value is within range
            if (Width < MIN_WIDTH || Width > MAX_WIDTH)
            {
                ContentDialog WidthMsg = new ContentDialog
                {
                    Title = "Width value out of range.",
                    CloseButtonText = "OK"
                };

                if (Width < MIN_WIDTH)
                    WidthMsg.Content = "Width must be above " + MIN_WIDTH + ".";
                if (Width > MAX_WIDTH)
                    WidthMsg.Content = "Width must be below " + MAX_WIDTH + ".";

                DisplayDialog(WidthMsg);
            }
        }

        private async void DisplayDialog(ContentDialog dialogueInfo)
        {
            // Wait for dialog box, use details from provided object. Had to put it here for async purposes.
            ContentDialogResult result = await dialogueInfo.ShowAsync();
        }


        private void Height_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Cast sender object as a TextBox.
            TextBox _target = sender as TextBox;
            // Parse text value to a number.
            double.TryParse(_target.Text, out double Height);
            // Validate height value.
            Validate_Height(Height);
        }

        private void Width_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Cast sender object as a TextBox.
            TextBox _target = sender as TextBox;
            // Parse text value to a number.
            double.TryParse(_target.Text, out double Width);
            // Validate width value.
            Validate_Width(Width);
        }

        private void Results_Button_Click(object sender, RoutedEventArgs e)
        {
            // Gather up details into an object
            WindowGlazer windowGlazer = new WindowGlazer
            {
                Height = System.Convert.ToDouble(Height_TextBox.Text),
                Width = System.Convert.ToDouble(Width_TextBox.Text),
                Quantity = Quantity_Slider.Value,
                Color = this.ColorSelection(),
                DateOrdered = DateTime.Now
            };

            this.Frame.Navigate(typeof(DisplayResults), windowGlazer);
        }

        private string ColorSelection()
        {
            // Return the color selected with radio buttons.
            string ColorSelected = string.Empty;
            if ((bool)WinColor_Black_Radio.IsChecked)
                ColorSelected = "Black";
            if ((bool)WinColor_Blue_Radio.IsChecked)
                ColorSelected = "Blue";
            if ((bool)WinColor_Brown_Radio.IsChecked)
                ColorSelected = "Brown";

            return ColorSelected;
        }
    }
}
