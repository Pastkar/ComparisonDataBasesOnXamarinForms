using RealApp1.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealApp1.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        #region private properties
        private DataBaseModel dataBaseModel;
        private Stopwatch stopwatch = new Stopwatch();
        private Realm _realm;
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
            _realm.Write(() =>
            {
                return _realm.Add(dataBaseModel = new DataBaseModel() { Name = "I" });
            });
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnAddThousand()
        {
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
                _realm.Write(() =>
                {
                    return _realm.Add(dataBaseModel = new DataBaseModel() { Name = i.ToString() });
                });
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnAddMillion()
        {
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                _realm.Write(() =>
                {
                    return _realm.Add(dataBaseModel = new DataBaseModel() { Name = i.ToString() });
                });
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnClearDB()
        {
            stopwatch.Start();
            _realm.Write(() => _realm.RemoveAll());
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private void OnDownloadBD()
        {
            stopwatch.Start();
            var allOdject = _realm.All<DataBaseModel>();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        #endregion
        public MainPageViewModel()
        {
            _realm = Realm.GetInstance();
            AddOne = new Command(OnAddOne);
            AddThousand = new Command(OnAddThousand);
            AddMillion = new Command(OnAddMillion);
            ClearDB = new Command(OnClearDB);
            DownloadBD = new Command(OnDownloadBD);
        }
    }
}
