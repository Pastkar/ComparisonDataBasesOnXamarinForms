using RealApp1.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private Stopwatch stopwatch = new Stopwatch();
        public MainPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
        }
        private void AddOne(object sender, EventArgs e)
        {
            stopwatch.Start();
            _realm.Write(() =>
            {
                return _realm.Add(test = new DataBaseModel() { Name = "I" });
            });
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
           
        }

        private void DownloadBD(object sender, EventArgs e)
        {
            stopwatch.Start();
            var allFriends = _realm.All<DataBaseModel>();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
           
        }

        private void AddThousand(object sender, EventArgs e)
        {
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
                _realm.Write(() =>
                {
                    return _realm.Add(test = new DataBaseModel() { Name = i.ToString() });
                });
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private void AddMillion(object sender, EventArgs e)
        {
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                _realm.Write(() =>
                {
                    return _realm.Add(test = new DataBaseModel() { Name = i.ToString() });
                }); 
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private void ClearDB(object sender, EventArgs e)
        {
            stopwatch.Start();
            _realm.Write(() => _realm.RemoveAll());
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
    }
}
