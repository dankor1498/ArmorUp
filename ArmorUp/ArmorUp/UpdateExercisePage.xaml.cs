using Syncfusion.XForms.Pickers;
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
        SfTimePicker timePicker;
        Entry entry = new Entry();
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
                TypeLabel.Text += "Вправа на кількість";
                type = App.TypeExercises.Count;
                UpdateStackLayout.Children.Add(AddEntryFrame(exercisesCount.Purpose.ToString()));
            }
            else if(exercises is ExercisesApproach)
            {
                ExercisesApproach exercisesApproach = (ExercisesApproach)exercises;
                NameEntry.Text = exercisesApproach.Name;
                InformationEditor.Text = exercisesApproach.Information;
                NameLinkEntry.Text = exercisesApproach.LinkName;
                UrlLinkEntry.Text = exercisesApproach.LinkURL;
                TypeLabel.Text += "Вправа на підходи";
                for (int i = 0; i < exercisesApproach.ApproachList.Count; i++)
                {
                    UpdateStackLayout.Children.Add(AddEntryFrame(exercisesApproach.ApproachList[i].ToString()));
                }
                type = App.TypeExercises.Approach;
            }
            else if (exercises is ExercisesTime)
            {
                ExercisesTime exercisesTime = (ExercisesTime)exercises;

                Frame frame = new Frame()
                {
                    BackgroundColor = Color.Black,
                    Padding = 2,
                };
                StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
                Image image = new Image()
                {
                    Source = "ExMission.jpg",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Aspect = Aspect.AspectFill,
                    HeightRequest = 40,
                    WidthRequest = 40
                };
                entry.Text = exercisesTime.Time.TotalSeconds.ToString();
                entry.TextColor = Color.White;
                entry.BackgroundColor = Color.Black;
                entry.HorizontalOptions = LayoutOptions.FillAndExpand;
                stackLayout.Children.Add(image);
                stackLayout.Children.Add(entry);
                frame.Content = stackLayout;

                NameEntry.Text = exercisesTime.Name;
                InformationEditor.Text = exercisesTime.Information;
                NameLinkEntry.Text = exercisesTime.LinkName;
                UrlLinkEntry.Text = exercisesTime.LinkURL;
                TypeLabel.Text += "Вправа на час";
                type = App.TypeExercises.Time;
                UpdateStackLayout.Children.Add(frame);
                UpdateStackLayout.Children.Add(CreateNewTimePicker());
            }
        }
        private Frame AddEntryFrame(string text)
        {
            Frame frame = new Frame()
            {
                BackgroundColor = Color.Black,
                Padding = 2,
            };
            StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Image image = new Image()
            {
                Source = "ExMission.jpg",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Aspect = Aspect.AspectFill,
                HeightRequest = 40,
                WidthRequest = 40
            };
            Entry entry = new Entry()
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = text
            };
            stackLayout.Children.Add(image);
            stackLayout.Children.Add(entry);
            frame.Content = stackLayout;
            return frame;
        }
        private SfTimePicker CreateNewTimePicker()
        {
            ExercisesTime currentExercises = (ExercisesTime)exercises;
            timePicker = new SfTimePicker()
            {
                PickerMode = PickerMode.Default,
                ShowHeader = false,
                EnableLooping = true,
                IsOpen = true,
                HeightRequest = 200,
                WidthRequest = 200,
                Time = new TimeSpan(currentExercises.Time.Hours, currentExercises.Time.Minutes, currentExercises.Time.Seconds)
            };
            timePicker.TimeSelected += TimePicker_TimeSelected;
            return timePicker;
        }
        private void TimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
        {
            var time = e.NewValue.ToString().Split(':');
            int hour = Int32.Parse(time[0]) * 3600;
            int minute = Int32.Parse(time[1]) * 60;
            int second = Int32.Parse(time[2]);
            entry.Text = (hour + minute + second).ToString();
        }

        private void UpdateApproachButton_Clicked(object sender, EventArgs e)
        {
            if (type == App.TypeExercises.Count)
            {
                Frame frame = UpdateStackLayout.Children[0] as Frame;
                StackLayout stackLayout = frame.Content as StackLayout;
                Entry entry = stackLayout.Children[1] as Entry;
                if (NameEntry != null && entry != null)
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
                int Count = UpdateStackLayout.Children.Count;
                List<int> result = new List<int>();
                for (int i = 0; i < Count - 1; i++)
                {
                    if (UpdateStackLayout.Children[i] == null) return;
                    Frame frame = UpdateStackLayout.Children[i] as Frame;
                    StackLayout stackLayout = frame.Content as StackLayout;
                    Entry entry = stackLayout.Children[1] as Entry;
                    result.Add(Int32.Parse(entry.Text));
                }
                Frame frame1 = UpdateStackLayout.Children[Count - 1] as Frame;
                StackLayout stackLayout1 = frame1.Content as StackLayout;
                Entry entry1 = stackLayout1.Children[1] as Entry;
                result.Add(Int32.Parse(entry1.Text));
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
                Frame frame = UpdateStackLayout.Children[0] as Frame;
                StackLayout stackLayout = frame.Content as StackLayout;
                Entry entry = stackLayout.Children[1] as Entry;
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