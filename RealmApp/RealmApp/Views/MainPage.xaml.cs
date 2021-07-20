using RealmApp.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private Realm _realm;

        public MainPage()
        {

            _realm = Realm.GetInstance();
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = _realm.All<Model>();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void TapItem(object sender, ItemTappedEventArgs e)
        {
            Model selectedFriend = (Model)e.Item;
            InformationPage friendPage = new InformationPage
            {
                BindingContext = selectedFriend
            };
            await Navigation.PushModalAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            //InformationPage friendPage = new InformationPage
            //{
            //    BindingContext = new Model()
            //};
            await Navigation.PushModalAsync(new InformationPage());
        }
    }
}