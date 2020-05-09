using System;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticPage : ContentPage
    {
        public StatisticPage()
        {
            InitializeComponent();
            foreach (var item in App.MainTableArray)
            {
                ExercisesStackLayout.Children.Add(AddStatisticByExercise(item));
            }
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


        private StackLayout AddStatisticFromScreen(string name, int id, int progress, double percent, string picture, bool flag = false)
        {
            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            Frame PictureFrame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(5),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.Start
            };
            Image image = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Source = picture,
                HeightRequest = 60,
                WidthRequest = 60,
                Aspect = Aspect.AspectFill
            };
            //done 1
            PictureFrame.Content = image;

            Frame TextFrame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 5, 0, 5),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Button ExercisesButton = new Button()
            {
                ClassId = id.ToString(),
                Text = name,
                WidthRequest = 100,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White,
            };
            ExercisesButton.Clicked += YourButtonClick;
            //Done 2
            TextFrame.Content = ExercisesButton;

            Frame PercentFrame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(2, 5, 0, 5),
                BackgroundColor = Color.FromHex("#262626"),
                WidthRequest = 60
            };
            Label PercentLabel = new Label()
            {
                Text = (int)percent + "%",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            //Done 3
            PercentFrame.Content = PercentLabel;

            Frame SucsessFrame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(2, 5, 5, 5),
                BackgroundColor = Color.FromHex("#262626"),
                WidthRequest = 60
            };
            
            Label SucsessLabel = new Label()
            {
                Text = progress > 0 ? "+" + progress : progress.ToString(),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            if (flag) SucsessLabel.Text = progress > 0 ? $"+{progress}s" : progress.ToString() + 's';
            //done 4
            SucsessFrame.Content = SucsessLabel;

            stackLayout.Children.Add(PictureFrame);
            stackLayout.Children.Add(TextFrame);
            stackLayout.Children.Add(PercentFrame);
            stackLayout.Children.Add(SucsessFrame);

            return stackLayout;
        }

        private StackLayout AddStatisticByExercise(MainTable mainTable)
        {
            int progress = 0;
            double percent = 0.0;
            if (mainTable.Type == (byte)App.TypeExercises.Count)
            {
                ExercisesCountTableRepository exercisesCountTableRepository = new ExercisesCountTableRepository(Path.Combine(DBSaverLoader.documentsPath, mainTable.StringID + ".db"));
                int exercisesTableLength = exercisesCountTableRepository.Count;
                if (exercisesTableLength == 0)
                {
                    return AddStatisticFromScreen(mainTable.Name, mainTable.ID, 0, 0.0, "count.jpg");
                }
                ExercisesCountTable lastItem = exercisesCountTableRepository.GetItem(exercisesCountTableRepository.StartPosition + exercisesTableLength - 1);
                double purpose = double.Parse(mainTable.Purpose);
                if (exercisesTableLength >= 2)
                {
                    ExercisesCountTable penultItem = exercisesCountTableRepository.GetItem(exercisesCountTableRepository.StartPosition + exercisesTableLength - 2);
                    progress = lastItem.Count - penultItem.Count;
                    percent = (double)lastItem.Count / purpose * 100.0;
                }
                if (exercisesTableLength == 1)
                {
                    percent = (double)lastItem.Count / purpose * 100.0;
                }
            }
            else if (mainTable.Type == (byte)App.TypeExercises.Approach)
            {
                ExercisesApproachTableRepository exercisesApproachTableRepository = new ExercisesApproachTableRepository(Path.Combine(DBSaverLoader.documentsPath, mainTable.StringID + ".db"));
                int exercisesTableLength = exercisesApproachTableRepository.Count;
                if (exercisesTableLength == 0)
                {
                    return AddStatisticFromScreen(mainTable.Name, mainTable.ID, 0, 0.0, "approach.jpg");
                }
                int lastItem = (from item in exercisesApproachTableRepository.GetItem(exercisesApproachTableRepository.StartPosition + exercisesTableLength - 1).Count.Split('/')
                                select int.Parse(item)).Sum();
                double purpose = (from item in mainTable.Purpose.Split('/') select double.Parse(item)).Sum();
                if (exercisesTableLength >= 2)
                {
                    int penultItem = (from item in exercisesApproachTableRepository.GetItem(exercisesApproachTableRepository.StartPosition + exercisesTableLength - 2).Count.Split('/')
                                      select int.Parse(item)).Sum();
                    progress = lastItem - penultItem;
                    percent = (double)lastItem / purpose * 100.0;
                }
                if (exercisesTableLength == 1)
                {
                    percent = (double)lastItem / purpose * 100.0;
                }
            }
            else if (mainTable.Type == (byte)App.TypeExercises.Time)
            {
                ExercisesTimeTableRepository exercisesTimeTableRepository = new ExercisesTimeTableRepository(Path.Combine(DBSaverLoader.documentsPath, mainTable.StringID + ".db"));
                int exercisesTableLength = exercisesTimeTableRepository.Count;
                TimeSpan progressTime = new TimeSpan(0, 0, 0);
                if (exercisesTableLength == 0)
                {
                    return AddStatisticFromScreen(mainTable.Name, mainTable.ID, 0, 0.0, "timer.jpg");
                }
                ExercisesTimeTable lastItem = exercisesTimeTableRepository.GetItem(exercisesTimeTableRepository.StartPosition + exercisesTableLength - 1);
                double purpose = double.Parse(mainTable.Purpose);
                if (exercisesTableLength >= 2)
                {
                    ExercisesTimeTable penultItem = exercisesTimeTableRepository.GetItem(exercisesTimeTableRepository.StartPosition + exercisesTableLength - 2);
                    progressTime = lastItem.Count - penultItem.Count;
                    percent = (double)lastItem.Count.TotalSeconds / purpose * 100.0;
                }
                if (exercisesTableLength == 1)
                {
                    percent = (double)lastItem.Count.TotalSeconds / purpose * 100.0;
                }
                return AddStatisticFromScreen(mainTable.Name, mainTable.ID, (int)progressTime.TotalSeconds, percent, "timer.jpg", true);
            }
            string photo = "";
            if (mainTable.Type == (byte)App.TypeExercises.Time)
                photo = "timer.jpg";
            if (mainTable.Type == (byte)App.TypeExercises.Approach)
                photo = "approach.jpg";
            if (mainTable.Type == (byte)App.TypeExercises.Count)
                photo = "count.jpg";
            return AddStatisticFromScreen(mainTable.Name, mainTable.ID, progress, percent, photo);
        }

        private void YourButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Exercises.CurrentExercisesId = int.Parse(button.ClassId);
            Navigation.PushAsync(new CurrentExerciseStatistic());
        }
    }
}