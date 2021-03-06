﻿using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace ArmorUp
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQzMzg4QDMxMzgyZTMxMmUzME04UFpEaGZSZlBPcXpBaVBFS0ZBbFFPNVJXbkFVcEtvNnNBWlBlOXhNaEE9");

            InitializeComponent();            

            MainPage = new NavigationPage(new ArmorUp.MainPage())
            {
                BarBackgroundColor = Color.FromHex("#65186e"),
            };
        }
        public static string UserImagePath = CrossSettings.Current.GetValueOrDefault("UserImagePath", null);
        public enum TypeExercises : byte { Count = 1, Approach, Time };
        public static int Pivot = 20;
        
        public static MainTableRepository database;

        public static MainTableRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new MainTableRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "table1.db"));
                }
                return database;
            }
        }

        public static MainTable[] MainTableArray = Database.GetItems();
        public static void UpdateMainTableList()
        {
            MainTableArray = Database.GetItems();
        }

        public static int iteratorQuote = CrossSettings.Current.GetValueOrDefault("IteratorQuote", 0);
        public static Quote CurrentQuote;

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