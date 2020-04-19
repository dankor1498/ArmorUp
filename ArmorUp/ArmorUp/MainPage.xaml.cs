using System;
using System.IO;
using Xamarin.Forms;

namespace ArmorUp
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new ProfilePage());
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
