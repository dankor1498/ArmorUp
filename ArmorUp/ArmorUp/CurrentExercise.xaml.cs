using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentExercise : ContentPage
    {
        private ExercisesCount currentExercises = DBSaverLoader.LOAD_EXERCISE(Exercises.CurrentExercisesId, App.Database);

        private ExercisesTableRepository exercisesTableRepository = new ExercisesTableRepository(
            Path.Combine(DBSaverLoader.documentsPath, App.Database.GetItem(Exercises.CurrentExercisesId).StringID + ".db"));

        public CurrentExercise()
        {
            InitializeComponent();
            MissionLabel.Text = currentExercises.Purpose.ToString();
            InfoEditor.Text = String.Format($"{currentExercises.Name}\n{currentExercises.Information}");
            UsfullLinkEditor.Text = String.Format($"{currentExercises.LinkName}\n{currentExercises.LinkURL}");
        }

        private void NewExercisePage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewExercisePage());
        }

        private void StatisticsButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StatisticPage());
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            exercisesTableRepository.SaveItem(new ExercisesTable { Count = int.Parse(ProgressForToday.Text), Data = DateTime.Now });
            Navigation.PushAsync(new StatisticPage());
        }
    }
}