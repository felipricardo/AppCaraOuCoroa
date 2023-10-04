using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaraOuCoroa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageJogo : ContentPage
    {
        public PageJogo()
        {
            InitializeComponent();
            Random r = new Random();
            int n = r.Next(1, 3);
            if (n == 1)
            {
                imgMoeda.Source = "moeda_cara";
            }
            else
            {
                imgMoeda.Source = "moeda_coroa";
            }

            // implementar o vibrar
            try
            {
                // Use default vibration length
                //Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
                DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}