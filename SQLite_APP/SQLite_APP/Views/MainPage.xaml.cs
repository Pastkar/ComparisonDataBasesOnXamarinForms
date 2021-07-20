

using RealmExample.ViewModels;
using SQLite_APP;
using SQLite_APP.Models;
using SQLite_APP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DataBaseModel selectedFriend = (DataBaseModel)e.SelectedItem;
            InformationPage friendPage = new InformationPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushModalAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            DataBaseModel friend = new DataBaseModel();
            InformationPage friendPage = new InformationPage();
            friendPage.BindingContext = friend;
            await Navigation.PushModalAsync(friendPage);
        }
        private async void DeleteAllFriends(object sender, EventArgs e)
        {
            App.Database.DeleteAll();
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}
