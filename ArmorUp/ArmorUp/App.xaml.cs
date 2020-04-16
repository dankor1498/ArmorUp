﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ArmorUp.MainPage())
            {
                BarBackgroundColor = Color.FromHex("#65186e")
            };
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
