using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentExercise : ContentPage
    {
        ExercisesCount currentExercises = DBSaverLoader.LOAD_EXERCISE(Exercises.CurrentExercisesId, App.Database);
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
    }
}