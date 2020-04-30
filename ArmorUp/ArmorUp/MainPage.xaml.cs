using Plugin.Settings;
using System;
using System.IO;
using Xamarin.Forms;

namespace ArmorUp
{
    public partial class MainPage : MasterDetailPage
    {
        public static string User = CrossSettings.Current.GetValueOrDefault("User", null);

        public MainPage()
        {
            InitializeComponent();
            
            if (User == null)
            {
                Detail = new NavigationPage(new StartPage());
            }
            else
            {
                Detail = new NavigationPage(new ProfilePage());
            }  

            IsPresented = false;
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < ExercisesTest.exercisesTest.Count; i++)
            {
                DBSaverLoader.SAVE_EXERCISE(ExercisesTest.exercisesTest[i], App.Database);                
            }
            App.UpdateMainTableList();
            Navigation.PushAsync(new ProfilePage());
        }
    }
}
