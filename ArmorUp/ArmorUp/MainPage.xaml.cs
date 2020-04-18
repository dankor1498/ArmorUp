using System;   
using Xamarin.Forms;

namespace ArmorUp
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            DBSaverLoader dBSaverLoader = new DBSaverLoader();
            try
            {
                ExercisesDB.CurrentExercisesList = dBSaverLoader.LOAD_USER();
            }
            catch (Exception) { }

            Detail = new NavigationPage(new ProfilePage());
            IsPresented = false;
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            DBSaverLoader dBSaverLoader = new DBSaverLoader();
            if (ExercisesDB.CurrentExercisesList.ExercisesList.Count != 0)
                dBSaverLoader.SAVE_USER(ExercisesDB.CurrentExercisesList);
        }
    }
}
