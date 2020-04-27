using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateExercisePage : ContentPage
    {
        private object exercises = DBSaverLoader.LOAD_EXERCISE(Exercises.CurrentExercisesId, App.Database);
        private App.TypeExercises type;
        public UpdateExercisePage()
        {
            InitializeComponent();
            PrintInfoExercises();
        }

        private void PrintInfoExercises()
        {
            if(exercises is ExercisesCount)
            {
                ExercisesCount exercisesCount = (ExercisesCount)exercises;
                NameEntry.Text = exercisesCount.Name;
                InformationEditor.Text = exercisesCount.Information;
                NameLinkEntry.Text = exercisesCount.LinkName;
                UrlLinkEntry.Text = exercisesCount.LinkURL;
                TypeLabel.Text += "Count";
                type = App.TypeExercises.Count;
                PurposeStackLayout.Children.Add(new Entry() { Text = exercisesCount.Purpose.ToString() });
            }
            else if(exercises is ExercisesApproach)
            {
                ExercisesApproach exercisesApproach = (ExercisesApproach)exercises;
                NameEntry.Text = exercisesApproach.Name;
                InformationEditor.Text = exercisesApproach.Information;
                NameLinkEntry.Text = exercisesApproach.LinkName;
                UrlLinkEntry.Text = exercisesApproach.LinkURL;
                TypeLabel.Text += "Approach";
                for (int i = 0; i < exercisesApproach.ApproachList.Count; i++)
                {
                    PurposeStackLayout.Children.Add(new Entry() { Text = exercisesApproach.ApproachList[i].ToString() });
                }
                type = App.TypeExercises.Approach;
            }
            else if (exercises is ExercisesTime)
            {
                ExercisesTime exercisesTime = (ExercisesTime)exercises;
                NameEntry.Text = exercisesTime.Name;
                InformationEditor.Text = exercisesTime.Information;
                NameLinkEntry.Text = exercisesTime.LinkName;
                UrlLinkEntry.Text = exercisesTime.LinkURL;
                TypeLabel.Text += "Count";
                type = App.TypeExercises.Time;
                PurposeStackLayout.Children.Add(new Entry() { Text = exercisesTime.Time.TotalSeconds.ToString() });
            }
        }

        private void UpdateApproachButton_Clicked(object sender, EventArgs e)
        {
            if (type == App.TypeExercises.Count)
            {
                Entry entry = PurposeStackLayout.Children[0] as Entry;
                if(NameEntry != null && entry != null)
                {
                    DBSaverLoader.UPDATE_EXERCISE(Exercises.CurrentExercisesId, new ExercisesCount()
                    {
                        Name = NameEntry.Text,
                        Information = InformationEditor.Text,
                        LinkName = NameLinkEntry.Text,
                        LinkURL = UrlLinkEntry.Text,
                        Purpose = Int32.Parse(entry.Text)
                    }, App.Database);
                    App.UpdateMainTableList();
                }                
            }
            else if (type == App.TypeExercises.Approach)
            {
                int Count = PurposeStackLayout.Children.Count;
                List<int> result = new List<int>();
                for (int i = 0; i < Count - 1; i++)
                {
                    if (PurposeStackLayout.Children[i] == null) return;
                    result.Add(Int32.Parse((PurposeStackLayout.Children[i] as Entry).Text));
                }
                result.Add(Int32.Parse((PurposeStackLayout.Children[Count - 1] as Entry).Text));
                if (NameEntry != null)
                {
                    DBSaverLoader.UPDATE_EXERCISE(Exercises.CurrentExercisesId, new ExercisesApproach()
                    {
                        Name = NameEntry.Text,
                        Information = InformationEditor.Text,
                        LinkName = NameLinkEntry.Text,
                        LinkURL = UrlLinkEntry.Text,
                        ApproachList = result
                    }, App.Database);
                    App.UpdateMainTableList();
                }
            }
            else if (type == App.TypeExercises.Time)
            {
                Entry entry = PurposeStackLayout.Children[0] as Entry;
                if (NameEntry != null && entry != null)
                {
                    DBSaverLoader.UPDATE_EXERCISE(Exercises.CurrentExercisesId, new ExercisesTime()
                    {
                        Name = NameEntry.Text,
                        Information = InformationEditor.Text,
                        LinkName = NameLinkEntry.Text,
                        LinkURL = UrlLinkEntry.Text,
                        Time = new TimeSpan(0, 0, Int32.Parse(entry.Text))
                    }, App.Database);
                    App.UpdateMainTableList();
                }
            }
            Navigation.PushAsync(new ProfilePage());
        }
    }
}