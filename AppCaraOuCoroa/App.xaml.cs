using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCaraOuCoroa
{
    public partial class App : Application
    {
        private DateTime lastInteractionTime;
        private bool isRedirected;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            lastInteractionTime = DateTime.Now;
            isRedirected = false;
        }

        protected override void OnSleep()
        {
            // Quando o aplicativo entra em estado de suspensão (background), verifique o tempo de inatividade.
            TimeSpan inactivityDuration = DateTime.Now - lastInteractionTime;
            if (!isRedirected && inactivityDuration.TotalMilliseconds >= 20000)
            {
                MainPage = new NavigationPage(new MainPage());
                isRedirected = true;
            }
        }

        protected override void OnResume()
        {
            lastInteractionTime = DateTime.Now;
            isRedirected = false;
        }
    }
}
