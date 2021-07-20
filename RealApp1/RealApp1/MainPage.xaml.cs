using RealApp1.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealApp1
{
    public partial class MainPage : ContentPage
    {
        Realm _realm;
        DataBaseModel test;
        public MainPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
        }
        private void AddOne(object sender, EventArgs e)
        {             
            _realm.Write(() =>
            {
                return _realm.Add(test = new DataBaseModel() { Name = "I"});
            });
        }

        private void DownloadBD(object sender, EventArgs e)
        {
            var allFriends = _realm.All<DataBaseModel>();
        }

        private void AddThousand(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
                _realm.Write(() =>
                {
                    return _realm.Add(test = new DataBaseModel() { Name = i.ToString() });
                });
        }

        private void AddMillion(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000000; i++)
                _realm.Write(() =>
                {
                    return _realm.Add(test = new DataBaseModel() { Name = i.ToString() });
                });
        }

        private void ClearDB(object sender, EventArgs e)
        {
            _realm.Write(() => _realm.RemoveAll());
        }
    }
}
