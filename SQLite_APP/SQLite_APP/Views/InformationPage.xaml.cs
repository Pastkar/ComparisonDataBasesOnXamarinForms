using SQLite_APP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformationPage : ContentPage
    {
        private Stopwatch stopwatch = new Stopwatch();
        public InformationPage()
        {
            InitializeComponent();
        }
        private void SaveFriend(object sender, EventArgs e)
        {
            stopwatch.Start();
            var friend = (DataBaseModel)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                App.Database.SaveItem(friend);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            this.Navigation.PopModalAsync();

        }
        private void AddThousend(object sender, EventArgs e)
        {
            stopwatch.Start();
            DataBaseModel friend;
            for (int i = 0; i < 1000; i++)
            {
                friend = new DataBaseModel() { Name = i.ToString() };
                App.Database.SaveItem(friend);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            this.Navigation.PopModalAsync();
        }
        private void AddMillion(object sender, EventArgs e)
        {
            stopwatch.Start();
            DataBaseModel friend;
            for (int i = 0; i < 1000000; i++)
            {
                friend = new DataBaseModel() { Name = i.ToString() };
                App.Database.SaveItem(friend);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            this.Navigation.PopModalAsync();
        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (DataBaseModel)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopModalAsync();
        }
        
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}
