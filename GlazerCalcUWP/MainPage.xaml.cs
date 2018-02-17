using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalcUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double width, height, woodLength, glassArea;
        int quantity;
        string tint;
        const double MIN_WIDTH = 0.5;
        const double MAX_WIDTH = 5.0;
        const double MIN_HEIGHT = 0.75;
        const double MAX_HEIGHT = 3.0;
        DateTime orderDate;
    
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void tintColor_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void validateWidth(object sender, KeyRoutedEventArgs e)
        {
            string errorMessage = "";

            if (widthBox.Text == "")
            {
                errorMessage = "Width field can't be empty.";
            }
            else if (Double.TryParse(widthBox.Text, out width))
            {

                if (Convert.ToDouble(widthBox.Text) < MIN_WIDTH || Convert.ToDouble(widthBox.Text) > MAX_WIDTH)
                {
                    errorMessage = "Width must be between " + MIN_WIDTH +
                    " and " + MAX_WIDTH + " meters.";
                }
                else
                {
                    errorMessage = "";
                }
            }
            else
            {
                errorMessage = "Width field must be a valid number.";
            }

            errorsWidth.Text = errorMessage;
        }

        private void validateHeight(object sender, KeyRoutedEventArgs e)
        {
            string errorMessage = "";

            if (heightBox.Text == "")
            {
                errorMessage = "Height field can't be empty.";
            }
            else if (Double.TryParse(heightBox.Text, out width))
            {

                if (Convert.ToDouble(heightBox.Text) < MIN_HEIGHT || Convert.ToDouble(heightBox.Text) > MAX_HEIGHT)
                {
                    errorMessage = "Height must be between " + MIN_HEIGHT +
                    " and " + MAX_HEIGHT + " meters.";
                }
                else
                {
                    errorMessage = "";
                }
            }
            else
            {
                errorMessage = "Height field must be a valid number.";
            }

            errorsHeight.Text = errorMessage;
        }


        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (errorsWidth.Text == "" && errorsHeight.Text == "" && widthBox.Text != "" && heightBox.Text != "")
            {
                orderDate = DateTime.Now;
                width = Convert.ToDouble(widthBox.Text);
                height = Convert.ToDouble(heightBox.Text);
                
                if (tintColor1.IsChecked == true)
                {
                    tint = tintColor1.Content.ToString();

                }
                else if (tintColor2.IsChecked == true)
                {
                    tint = tintColor2.Content.ToString();

                }
                else if (tintColor3.IsChecked == true)
                {
                    tint = tintColor3.Content.ToString();

                }

                quantity = Convert.ToInt32(quantityBox.Text);


                woodLength = 2 * (width + height) * 3.25;
                glassArea = 2 * (width * height);

                var dialog = new MessageDialog("\nOrder Date: " + orderDate.ToString("dd MMM yyyy") + "\nWidth: " + width + " meter(s) \nHeight: " + height + " meter(s) \nTint: " + tint + "\nQuantity: " + quantity + "\n\nThe length of the wood required is " + woodLength + " feet. \nThe area of the glass required is " + glassArea + " square meters.", "Order Details");
                await dialog.ShowAsync();

            }
            else
            {
                if (widthBox.Text == "")
                {
                    errorsWidth.Text = "Width field can't be empty.";
                }
                
                if (heightBox.Text == "")
                {
                    errorsHeight.Text = "Height field can't be empty.";
                }
            }
        }



    }
}
