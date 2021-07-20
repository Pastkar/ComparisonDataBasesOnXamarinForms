using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Xamarin.Forms;
using AkavacheApp.Models;
using Akavache;
using System.Diagnostics;

namespace AkavacheApp
{
    public partial class MainPage : ContentPage
    {
        private Stopwatch stopwatch = new Stopwatch();
        private List<DataBaseModel> dataBaseModel = new List<DataBaseModel>();
            
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddOne(object sender, EventArgs e)
        {
            dataBaseModel.Clear();
            dataBaseModel.Add(new DataBaseModel() { Id = 1, Name ="фвіаф" });
            stopwatch.Start();
            await BlobCache.LocalMachine.InsertObject("test", dataBaseModel);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private async void DownloadBD(object sender, EventArgs e)
        {
            stopwatch.Start();
            var  test = await BlobCache.LocalMachine.GetAllObjects<List<DataBaseModel>>();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private async void AddThousand(object sender, EventArgs e)
        {
            dataBaseModel.Clear();
            for (int i = 0; i < 1000; i++)
            {
                dataBaseModel.Add(new DataBaseModel() { Id = i,Name = i.ToString() }) ;
            }
            stopwatch.Start();
            await BlobCache.LocalMachine.InsertObject("test", dataBaseModel);
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private async void AddMillion(object sender, EventArgs e)
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

        private async void ClearDB(object sender, EventArgs e)
        {
            stopwatch.Start();
            await BlobCache.LocalMachine.InvalidateAll();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }
    }
}
