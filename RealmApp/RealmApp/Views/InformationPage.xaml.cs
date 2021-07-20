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
    public partial class InformationPage : ContentPage
    {
        Realm _realm;
        Transaction _transaction;
        

        public InformationPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
            _transaction = _realm.BeginWrite();
        }
        private void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Model)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                if (friend.Id == null)
                {
                    friend.Id = Guid.NewGuid().ToString();
                    _realm.Add(friend);
                }

                _transaction.Commit();
            }
            this.Navigation.PopModalAsync();
        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Model)BindingContext;
            _realm.Remove(friend);
            _transaction.Commit();

            Navigation.PopModalAsync();
        }

        protected override void OnDisappearing()
        {
            _transaction?.Dispose();
            base.OnDisappearing();
        }
    }
}