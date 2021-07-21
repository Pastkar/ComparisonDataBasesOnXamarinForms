using SQLiteApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQLiteApplication.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        #region private properties
        private DataBaseModel friend; 
        private Stopwatch stopwatch = new Stopwatch();

        #endregion

        #region command
        public ICommand AddOne { get; private set; }
        public ICommand AddThousand { get; private set; }
        public ICommand AddMillion { get; private set; }
        public ICommand ClearDB { get; private set; }
        public ICommand DownloadBD { get; private set; }
        #endregion

        #region private methods
        private void OnAddOne()
        {
            stopwatch.Start();
            friend = new DataBaseModel() { Name ="i" };
            App.Database.SaveItem(friend);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnAddThousand()
        {
            stopwatch.Start();    
            for (int i = 0; i < 1000; i++)
            {
                friend = new DataBaseModel() { Name = i.ToString() };
                App.Database.SaveItem(friend);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnAddMillion()
        {
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                friend = new DataBaseModel() { Name = i.ToString() };
                App.Database.SaveItem(friend);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnClearDB()
        {
            stopwatch.Start();
            App.Database.DeleteAll();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnDownloadBD()
        {
            stopwatch.Start();
            var ObjectsList = App.Database.GetItems(); 
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        #endregion
        public MainPageViewModel()
        {
            AddOne = new Command(OnAddOne);
            AddThousand = new Command(OnAddThousand);
            AddMillion = new Command(OnAddMillion);
            ClearDB = new Command(OnClearDB);
            DownloadBD = new Command(OnDownloadBD);
        }
    }
}
