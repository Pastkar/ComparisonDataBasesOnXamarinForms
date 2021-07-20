using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AkavacheApp
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();
            Akavache.Registrations.Start("ApplicationName");
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
