using System;   
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
            DBSaverLoader dBSaverLoader = new DBSaverLoader();
            if (ExercisesDB.CurrentExercisesList.ExercisesList.Count != 0)
                dBSaverLoader.SAVE_USER(ExercisesDB.CurrentExercisesList);
        }
    }
}
