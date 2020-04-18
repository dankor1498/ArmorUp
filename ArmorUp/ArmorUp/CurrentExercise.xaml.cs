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
        public CurrentExercise()
        {
            InitializeComponent();
            //MissionLabel.Text = Exercises.CurrentExercises.Percent.ToString() + "%";
            //InfoEditor.Text = Exercises.CurrentExercises.Name;
            //UsfullLinkEditor.Text = Exercises.CurrentExercises.Name;
            //ProgressForToday.Text = Exercises.CurrentExercises.Sucsess;
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