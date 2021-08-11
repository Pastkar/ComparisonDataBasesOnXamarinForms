﻿using SQLiteApplication.Models;
using SQLiteApplication.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteApplication
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "DataBase.db";
        public static DBRepository database;
        public static DBRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}