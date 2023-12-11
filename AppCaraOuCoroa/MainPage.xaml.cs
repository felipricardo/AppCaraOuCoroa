using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppCaraOuCoroa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btJogar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var duration = TimeSpan.FromSeconds(0.5);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }

            await Navigation.PushAsync(new PageJogo());
        }
    }
}
