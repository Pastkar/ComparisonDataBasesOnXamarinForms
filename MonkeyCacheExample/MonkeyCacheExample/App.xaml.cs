using MonkeyCache.FileStore;
using MonkeyCacheExample.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyCacheExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Barrel.ApplicationId = "date_base";
            Barrel.Current.EmptyAll();
            MainPage = new StartWorkView();
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
