using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //ExerciseName - Label назва вправи.
    //ProgresLabelWithConclusion - Label - з успіхом в який потрібно виводити приріст і відповідно до приросту похвалу(Зелений) - неодобрення(Червоний).
    //PercentSFCircularGaugeLabel - Label - який в прогрес барі - вивести процент виконання відповідно до вправи.
    //ProgresSFCircularGauge.Value int - передати відсоток в форматі інта для виведення в прогрес барі.
    //ProgresLabel - Label - передати стрінг в форматі 45/90 де (90 - ціль) (45 - остання виконана кількість).
    //ExerciseByDataStackLayout - динамічно створювати елементи в які передавати дату/процент/приріст для відповідних значень.
    public partial class CurrentExerciseStatistic : ContentPage
    {
        //Json with name and other information
        private ExercisesCount currentExercises = DBSaverLoader.LOAD_EXERCISE(Exercises.CurrentExercisesId, App.Database);
        //Data base with count for exercise
        private ExercisesTableRepository exercisesTableRepository = new ExercisesTableRepository(
            Path.Combine(DBSaverLoader.documentsPath, App.Database.GetItem(Exercises.CurrentExercisesId).StringID + ".db"));

        public CurrentExerciseStatistic()
        {
            InitializeComponent();

            ExerciseName.Text = currentExercises.Name;
            var percent = GetPercent(currentExercises);

            PercentSFCircularGaugeLabel.Text = percent.ToString() + "%";
            ProgresSFCircularGauge.Value = (int)percent;
            CheckForProgress(ProgresLabelWithConclusion, currentExercises);
            ProgresLabel.Text = GetProgressInCorrectFormat(currentExercises);

            var array = exercisesTableRepository.GetItems();

            for (int i = 0; i < exercisesTableRepository.Count; ++i)
            {
                var exerciseHist = array[i];
                //data
                var dataHist = exerciseHist.Data.ToString();
                //percent
                var percentHist = GetPercent(currentExercises, exerciseHist);
                //Progress
                string progressHist = "0";
                if (i != 0)
                    progressHist = GetProgress(array, i);
                ExerciseByDataStackLayout.Children.Add(CreateNewItem(dataHist, percentHist, progressHist));
            }
        }
        private string GetProgressInCorrectFormat(ExercisesCount mainTable)
        {
            var lastItem = exercisesTableRepository.Count == 0 ? null : exercisesTableRepository.GetItem(exercisesTableRepository.Count);
            return $"{lastItem.Count}/{mainTable.Purpose}";
        }
        private double GetPercent(ExercisesCount mainTable, ExercisesTable exercisesTable)
        {
            double percent = 0.0;
            if (exercisesTableRepository.Count > 0)
                percent = (double)exercisesTable.Count / Convert.ToDouble(mainTable.Purpose) * 100.0;
            return percent;
        }
        private double GetPercent(ExercisesCount mainTable)
        {
            double percent = 0.0;
            var lastItem = exercisesTableRepository.Count == 0 ? null : exercisesTableRepository.GetItem(exercisesTableRepository.Count);
            if (exercisesTableRepository.Count >= 2)
            {
                var penultItem = exercisesTableRepository.GetItem(exercisesTableRepository.Count - 1);
                percent = (double)lastItem.Count / Convert.ToDouble(mainTable.Purpose) * 100.0;
            }
            if (exercisesTableRepository.Count == 1)
                percent = (double)lastItem.Count / Convert.ToDouble(mainTable.Purpose) * 100.0;
            return percent;
        }
        private string GetProgress(ExercisesTable[] exercisesTables, int id)
        {
            string result = "";
            int progressRes = exercisesTables[id].Count - exercisesTables[id - 1].Count;
            if (progressRes > 0)
                result = "+" + progressRes;
            else
                result = progressRes.ToString();
            return result;
        }
        private int GetProgress(ExercisesCount mainTable)
        {
            int progress = 0;
            var lastItem = exercisesTableRepository.Count == 0 ? null : exercisesTableRepository.GetItem(exercisesTableRepository.Count);
            if (exercisesTableRepository.Count >= 2)
            {
                var penultItem = exercisesTableRepository.GetItem(exercisesTableRepository.Count - 1);
                progress = lastItem.Count - penultItem.Count;
            }
            return progress;
        }
        private void CheckForProgress(Label label, ExercisesCount mainTable)
        {
            int progress = GetProgress(mainTable);
            if (progress > 0)
            {
                label.TextColor = Color.Green;
                label.Text = "+" + $"{progress}" + " Good job!";
            }
            else
            {
                label.TextColor = Color.Red;
                label.Text = $"{progress}" + " Bad job!";
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
        private StackLayout CreateNewItem(string data, double percent, string progress)
        {
            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(5),
                WidthRequest = 350,
                HeightRequest = 60
            };
            Frame frame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                IsClippedToBounds = true,
                WidthRequest = 230,
                HeightRequest = 60
            };
            Button button = new Button()
            {
                WidthRequest = 90,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White,
                Text = data
            };
            frame.Content = button;
            Frame frame1 = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                IsClippedToBounds = true,
                WidthRequest = 60,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626")
            };
            Label label = new Label()
            {
                Text = percent + "%",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            frame1.Content = label;
            Frame frame2 = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                IsClippedToBounds = true,
                WidthRequest = 60,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626")
            };
            Label label2 = new Label()
            {
                Text = progress,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            frame2.Content = label2;

            stackLayout.Children.Add(frame);
            stackLayout.Children.Add(frame1);
            stackLayout.Children.Add(frame2);

            return stackLayout;
        }
    }
}