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
            InitializeComponent();

            MainPage = new NavigationPage(new ArmorUp.MainPage())
            {
                BarBackgroundColor = Color.FromHex("#65186e"),
            };
        }

        public static MainTableRepository database;

        public static MainTableRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new MainTableRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "table.db"));
                }
                return database;
            }
        }

        public static MainTable[] MainTableArray = Database.GetItems();
        public static void UpdateMainTableList()
        {
            MainTableArray = Database.GetItems();
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