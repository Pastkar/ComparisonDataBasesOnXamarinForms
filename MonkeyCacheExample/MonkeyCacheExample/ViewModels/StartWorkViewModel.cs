using MonkeyCache.FileStore;
using MonkeyCacheExample.Models;
using RealmExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeyCacheExample.ViewModels
{
    class StartWorkViewModel : BaseViewModel
    {
        #region private properties
        private List<DataBaseModel> dataBaseModel = new List<DataBaseModel>();
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
            dataBaseModel.Clear();
            stopwatch.Start();
            dataBaseModel.Add(new DataBaseModel("afsas"));
            Barrel.Current.Add(key: Constants.UserKey, data: dataBaseModel, expireIn: TimeSpan.FromDays(60));
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

        }
        private void OnAddThousand()
        {
            dataBaseModel.Clear();
            for (int i = 0; i < 1000; i++)
            {
                dataBaseModel.Add(new DataBaseModel(i.ToString()));
            }
            stopwatch.Start();
            Barrel.Current.Add(key: Constants.UserKey, data: dataBaseModel, expireIn: TimeSpan.FromDays(60));
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

        }
        private void OnAddMillion()
        {
            dataBaseModel.Clear();
            for (int i = 0; i < 1000000; i++)
            {
                dataBaseModel.Add(new DataBaseModel(i.ToString()));
            }
            stopwatch.Start();
            Barrel.Current.Add(key: Constants.UserKey, data: dataBaseModel, expireIn: TimeSpan.FromDays(60));
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnClearDB()
        {
            stopwatch.Start();
            Barrel.Current.EmptyAll();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnDownloadBD()
        {
            stopwatch.Start();
            var dataBase = Barrel.Current.Get<IEnumerable<DataBaseModel>>(key: Constants.UserKey)?.ToList();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        #endregion
        public StartWorkViewModel()
        {
            AddOne = new Command(OnAddOne);
            AddThousand = new Command(OnAddThousand);
            AddMillion = new Command(OnAddMillion);
            ClearDB = new Command(OnClearDB);
            DownloadBD = new Command(OnDownloadBD);
        }
    }
}
