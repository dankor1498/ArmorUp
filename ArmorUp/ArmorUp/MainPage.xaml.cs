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
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "ExercisesList.json");
            if (File.Exists(path))
            {
                DBSaverLoader dBSaverLoader = new DBSaverLoader();
                try
                {
                    ExercisesDB.CurrentExercisesList = dBSaverLoader.LOAD_USER();
                }
                catch (Exception) { }
            }
            else
            {
                ExercisesDB.CurrentExercisesList = new ExercisesDB();
            }
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
