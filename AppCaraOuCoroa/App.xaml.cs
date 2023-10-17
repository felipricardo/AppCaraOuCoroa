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
            // Quando o aplicativo é iniciado, registre o tempo da última interação.
            lastInteractionTime = DateTime.Now;
            isRedirected = false;
        }

        protected override void OnSleep()
        {
            // Quando o aplicativo entra em estado de suspensão (background), verifique o tempo de inatividade.
            TimeSpan inactivityDuration = DateTime.Now - lastInteractionTime;
            if (!isRedirected && inactivityDuration.TotalMilliseconds >= 20000) // 20 segundos
            {
                // O usuário está inativo por mais de 20 segundos, redirecione para a tela de login.
                MainPage.Navigation.PushAsync(new MainPage()); // Substitua LogonPage pela sua página de login.
                isRedirected = true;
            }
        }

        protected override void OnResume()
        {
            // Quando o aplicativo retorna ao primeiro plano, atualize o tempo da última interação.
            lastInteractionTime = DateTime.Now;
            isRedirected = false;
        }
    }
}
