using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentExercise : ContentPage
    {
        private App.TypeExercises type;         
        private object objectExercises = DBSaverLoader.LOAD_EXERCISE(Exercises.CurrentExercisesId, App.Database);
        
        public CurrentExercise()
        {
            InitializeComponent();
            PrintInfoExercises();            
        }

        private void PrintInfoExercises()
        {
            Button button = new Button();
            button.Text = "Відправити";
            button.Clicked += SendButton_Clicked;
            if (objectExercises is ExercisesCount)
            {
                ExercisesCount currentExercises = (ExercisesCount)objectExercises;
                InfoEditor.Text = String.Format($"{currentExercises.Name}\n{currentExercises.Information}");
                UsfullLinkEditor.Text = String.Format($"{currentExercises.LinkName}\n{currentExercises.LinkURL}");
                MissionLabel.Text = currentExercises.PurposeToString();
                type = App.TypeExercises.Count;
                ResultStackLayout.Children.Add(new Entry() { BackgroundColor = Color.White });
            }
            if (objectExercises is ExercisesApproach)
            {
                ExercisesApproach currentExercises = (ExercisesApproach)objectExercises;
                InfoEditor.Text = String.Format($"{currentExercises.Name}\n{currentExercises.Information}");
                UsfullLinkEditor.Text = String.Format($"{currentExercises.LinkName}\n{currentExercises.LinkURL}");
                MissionLabel.Text = currentExercises.PurposeToString();
                for (int i = 0; i < currentExercises.ApproachList.Count; i++)
                {
                    ResultStackLayout.Children.Add(new Entry() { BackgroundColor = Color.White });
                }
                type = App.TypeExercises.Approach;
            }
            if (objectExercises is ExercisesTime)
            {
                ExercisesTime currentExercises = (ExercisesTime)objectExercises;
                InfoEditor.Text = String.Format($"{currentExercises.Name}\n{currentExercises.Information}");
                UsfullLinkEditor.Text = String.Format($"{currentExercises.LinkName}\n{currentExercises.LinkURL}");
                MissionLabel.Text = $"{currentExercises.Time.ToString()} = {currentExercises.PurposeToString()}s";
                ResultStackLayout.Children.Add(new Entry() { BackgroundColor = Color.White });
                type = App.TypeExercises.Time;
            }
            ResultStackLayout.Children.Add(button);
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
            int progress = 0;
            if (type == App.TypeExercises.Count)
            {
                progress = int.Parse((ResultStackLayout.Children[0] as Entry).Text);
                var exercisesCountTableRepository = new ExercisesCountTableRepository(Path.Combine(DBSaverLoader.documentsPath, App.Database.GetItem(Exercises.CurrentExercisesId).StringID + ".db"));
                exercisesCountTableRepository.SaveItem(new ExercisesCountTable { Count = progress, Data = DateTime.Now });
                int count = exercisesCountTableRepository.Count;
                if(count > App.Pivot)
                {
                    exercisesCountTableRepository.DeleteFirst();
                }
            }
            else if(type == App.TypeExercises.Approach)
            {
                string result = "";
                int Count = ResultStackLayout.Children.Count;
                for (int i = 0; i < Count - 2; i++)
                {
                    result += string.Format($"{(ResultStackLayout.Children[i] as Entry).Text}/");
                }
                result += (ResultStackLayout.Children[Count - 2] as Entry).Text;
                var exercisesApproachTableRepository = new ExercisesApproachTableRepository(Path.Combine(DBSaverLoader.documentsPath, App.Database.GetItem(Exercises.CurrentExercisesId).StringID + ".db"));
                exercisesApproachTableRepository.SaveItem(new ExercisesApproachTable { Count = result, Data = DateTime.Now });
                int count = exercisesApproachTableRepository.Count;
                if (count > App.Pivot)
                {
                    exercisesApproachTableRepository.DeleteFirst();
                }
            }
            else if (type == App.TypeExercises.Time)
            {
                progress = int.Parse((ResultStackLayout.Children[0] as Entry).Text);
                var exercisesTimeTableRepository = new ExercisesTimeTableRepository(Path.Combine(DBSaverLoader.documentsPath, App.Database.GetItem(Exercises.CurrentExercisesId).StringID + ".db"));
                exercisesTimeTableRepository.SaveItem(new ExercisesTimeTable { Count = new TimeSpan(0, 0, progress), Data = DateTime.Now });
                int count = exercisesTimeTableRepository.Count;
                if (count > App.Pivot)
                {
                    exercisesTimeTableRepository.DeleteFirst();
                }
            }
            Navigation.PushAsync(new StatisticPage());
        }
    }
}