using Akavache;
using AkavacheApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AkavacheApp.ViewModels
{
    class MainPageViewModel : BaseViewModel
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
        private async void OnAddOne()
        {
            dataBaseModel.Clear();
            dataBaseModel.Add(new DataBaseModel() { Id = 1, Name = "фвіаф" });
            stopwatch.Start();
            await BlobCache.LocalMachine.InsertObject("test", dataBaseModel);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

        }
        private async void OnAddThousand()
        {
            dataBaseModel.Clear();
            for (int i = 0; i < 1000; i++)
            {
                dataBaseModel.Add(new DataBaseModel() { Id = i, Name = i.ToString() });
            }
            stopwatch.Start();
            await BlobCache.LocalMachine.InsertObject("test", dataBaseModel);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();

        }
        private async void OnAddMillion()
        {
            dataBaseModel.Clear();
            for (int i = 0; i < 1000000; i++)
            {
                dataBaseModel.Add(new DataBaseModel() { Id = i, Name = i.ToString() });
            }
            stopwatch.Start();
            await BlobCache.LocalMachine.InsertObject("test", dataBaseModel);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private async void OnClearDB()
        {
            stopwatch.Start();
            await BlobCache.LocalMachine.InvalidateAll();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
        private async void OnDownloadBD()
        {
            stopwatch.Start();
            var test = await BlobCache.LocalMachine.GetAllObjects<List<DataBaseModel>>();
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
