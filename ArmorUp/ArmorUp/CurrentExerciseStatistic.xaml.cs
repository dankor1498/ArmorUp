﻿using Syncfusion.SfGauge.XForms;
using System;
using System.IO;
using System.Linq;

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
        private MainTable mainTable = App.Database.GetItem(Exercises.CurrentExercisesId);
        private ExerciseByDataViewModel exerciseByDataViewModel = new ExerciseByDataViewModel();

        public CurrentExerciseStatistic()
        {
            InitializeComponent();
            PrintInfoExercises();
        }

        private void PrintInfoExercises()
        {
            if (mainTable.Type == (byte)App.TypeExercises.Count)
            {
                ExercisesCountTableRepository exercisesCountTableRepository = new ExercisesCountTableRepository(Path.Combine(DBSaverLoader.documentsPath, mainTable.StringID + ".db"));
                if (exerciseByDataViewModel.exerciseInfoByDates.Count != exercisesCountTableRepository.Count)
                    exerciseByDataViewModel.exerciseInfoByDates.Clear();
                int tableCount = exercisesCountTableRepository.Count;
                if (tableCount != 0)
                {
                    ExerciseName.Text = mainTable.Name;
                    double percent = 0.0;
                    int progress = 0;
                    var arrayExercisesCountTable = exercisesCountTableRepository.GetItems();
                    if (tableCount >= 2)
                    {
                        percent = GetPercent(mainTable.Purpose, arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count);
                        progress = arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count - arrayExercisesCountTable[arrayExercisesCountTable.Length - 2].Count;
                    }
                    if (tableCount == 1)
                    {
                        percent = GetPercent(mainTable.Purpose, arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count);
                    }
                    PercentSFCircularGaugeLabel.Text = ((int)percent).ToString() + "%";
                    ProgresSFCircularGauge.Value = (int)percent;
                    CheckForProgress(ProgresLabelWithConclusion, ProgresSFCircularGauge, ProgresLabel, progress);
                    ProgresLabel.Text = $"{arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count}/{mainTable.Purpose}";
                    int CountOfExForChart = tableCount <= 20 ? tableCount : 20;
                    for (int i = 0, j = tableCount - 1; i < CountOfExForChart; i++, j--)
                    {
                        var exerciseHist = arrayExercisesCountTable[j];
                        var dataHist = exerciseHist.Data.ToString();
                        var percentHist = (int)GetPercent(mainTable.Purpose, arrayExercisesCountTable[j].Count);
                        ExerciseByDataStackLayout.Children.Add(CreateNewItem(dataHist, percentHist, arrayExercisesCountTable[j].Count.ToString()));
                    }
                    CountOfExForChart = tableCount <= 10 ? tableCount : 10;
                    int TableCount = tableCount - CountOfExForChart;
                    for (int i = CountOfExForChart - 1; i >= 0; --i)
                    {
                        var exerciseHist = arrayExercisesCountTable[TableCount];
                        if ((exerciseByDataViewModel.exerciseInfoByDates.Count != tableCount) && exerciseHist.Data.Month == DateTime.Now.Month)
                            exerciseByDataViewModel.exerciseInfoByDates.Add(new ExerciseInfoByDate() { Data = exerciseHist.Data.Day.ToString() + "/" + exerciseHist.Data.Month.ToString(), Count = exerciseHist.Count, Purpose = int.Parse(mainTable.Purpose) });
                        TableCount++;
                    }
                }
            }
            else if (mainTable.Type == (byte)App.TypeExercises.Approach)
            {
                ExercisesApproachTableRepository exercisesApproachTableRepository = new ExercisesApproachTableRepository(Path.Combine(DBSaverLoader.documentsPath, mainTable.StringID + ".db"));
                if (exerciseByDataViewModel.exerciseInfoByDates.Count != exercisesApproachTableRepository.Count)
                    exerciseByDataViewModel.exerciseInfoByDates.Clear();
                int tableCount = exercisesApproachTableRepository.Count;
                if (tableCount != 0)
                {
                    ExerciseName.Text = mainTable.Name;
                    double percent = 0.0;
                    int progress = 0;
                    var arrayExercisesApproachTable = exercisesApproachTableRepository.GetItems();
                    int Purpose = GetSum(mainTable.Purpose);
                    int LastCount = GetSum(arrayExercisesApproachTable[arrayExercisesApproachTable.Length - 1].Count);
                    if (tableCount >= 2)
                    {
                        percent = GetPercent(Purpose, LastCount);
                        progress = LastCount - GetSum(arrayExercisesApproachTable[arrayExercisesApproachTable.Length - 2].Count);
                    }
                    if (tableCount == 1)
                    {
                        percent = GetPercent(Purpose, LastCount);
                    }
                    PercentSFCircularGaugeLabel.Text = ((int)percent).ToString() + "%";
                    ProgresSFCircularGauge.Value = (int)percent;
                    CheckForProgress(ProgresLabelWithConclusion, ProgresSFCircularGauge, ProgresLabel, progress);
                    ProgresLabel.Text = $"{LastCount}/{Purpose}";
                    int CountOfExForChart = tableCount <= 20 ? tableCount : 20;                    
                    for (int i = 0, j = tableCount - 1; i < CountOfExForChart; i++, j--)
                    {
                        LastCount = GetSum(arrayExercisesApproachTable[j].Count);
                        var exerciseHist = arrayExercisesApproachTable[j];
                        var dataHist = $"{exerciseHist.Data.ToString()}\n{arrayExercisesApproachTable[j].Count}";
                        int count = GetSum(arrayExercisesApproachTable[j].Count);
                        var percentHist = (int)GetPercent(Purpose, count);
                        ExerciseByDataStackLayout.Children.Add(CreateNewItem(dataHist, percentHist, $"{LastCount}"));
                    }
                    CountOfExForChart = tableCount <= 10 ? tableCount : 10;
                    int TableCount = tableCount - CountOfExForChart;
                    for (int i = CountOfExForChart - 1; i >= 0; --i)
                    {
                        var exerciseHist = arrayExercisesApproachTable[TableCount];
                        int count = GetSum(arrayExercisesApproachTable[TableCount].Count);
                        if ((exerciseByDataViewModel.exerciseInfoByDates.Count != tableCount) && exerciseHist.Data.Month == DateTime.Now.Month)
                            exerciseByDataViewModel.exerciseInfoByDates.Add(new ExerciseInfoByDate() { Data = exerciseHist.Data.Day.ToString() + "/" + exerciseHist.Data.Month.ToString(), Count = count, Purpose = Purpose });
                        TableCount++;
                    }
                }
            }
            else if (mainTable.Type == (byte)App.TypeExercises.Time)
            {
                ExercisesTimeTableRepository exercisesTimeTableRepository = new ExercisesTimeTableRepository(Path.Combine(DBSaverLoader.documentsPath, mainTable.StringID + ".db"));
                if (exerciseByDataViewModel.exerciseInfoByDates.Count != exercisesTimeTableRepository.Count)
                    exerciseByDataViewModel.exerciseInfoByDates.Clear();
                int tableCount = exercisesTimeTableRepository.Count;
                if (tableCount != 0)
                {
                    ExerciseName.Text = mainTable.Name;
                    double percent = 0.0;
                    TimeSpan progress = new TimeSpan(0, 0, 0);
                    var arrayExercisesCountTable = exercisesTimeTableRepository.GetItems();
                    if (tableCount >= 2)
                    {
                        percent = GetPercent(mainTable.Purpose, arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count.TotalSeconds);
                        progress = arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count - arrayExercisesCountTable[arrayExercisesCountTable.Length - 2].Count;
                    }
                    if (tableCount == 1)
                    {
                        percent = GetPercent(mainTable.Purpose, arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count.TotalSeconds);
                    }
                    PercentSFCircularGaugeLabel.Text = ((int)percent).ToString() + "%";
                    ProgresSFCircularGauge.Value = (int)percent;
                    CheckForProgress(ProgresLabelWithConclusion, ProgresSFCircularGauge, ProgresLabel, (int)progress.TotalSeconds, true);
                    ProgresLabel.Text = $"{arrayExercisesCountTable[arrayExercisesCountTable.Length - 1].Count}/\n{new TimeSpan(0,0, int.Parse(mainTable.Purpose)).ToString()}";
                    int CountOfExForChart = tableCount <= 20 ? tableCount : 20;
                    for (int i = 0, j = tableCount - 1; i < CountOfExForChart; i++, j--)
                    {
                        var exerciseHist = arrayExercisesCountTable[j];
                        var dataHist = exerciseHist.Data.ToString();
                        var percentHist = (int)GetPercent(mainTable.Purpose, arrayExercisesCountTable[j].Count.TotalSeconds);
                        ExerciseByDataStackLayout.Children.Add(CreateNewItem(dataHist, percentHist, arrayExercisesCountTable[j].Count.ToString()));
                    }
                    CountOfExForChart = tableCount <= 10 ? tableCount : 10;
                    int TableCount = tableCount - CountOfExForChart;
                    for (int i = CountOfExForChart - 1; i >= 0; --i)
                    {
                        var exerciseHist = arrayExercisesCountTable[TableCount];
                        if ((exerciseByDataViewModel.exerciseInfoByDates.Count != tableCount) && exerciseHist.Data.Month == DateTime.Now.Month)
                            exerciseByDataViewModel.exerciseInfoByDates.Add(new ExerciseInfoByDate() { Data = exerciseHist.Data.Day.ToString() + "/" + exerciseHist.Data.Month.ToString(), Count = (int)exerciseHist.Count.TotalSeconds, Purpose = int.Parse(mainTable.Purpose) });
                        TableCount++;
                    }
                }
            }
        }

        private double GetPercent(string purpose, double count)
        {
            return count / Convert.ToDouble(purpose) * 100.0;
        }

        private double GetPercent(double purpose, double count)
        {
            return count / purpose * 100.0;
        }

        private int GetSum(string count)
        {
            return (from item in count.Split('/')
                    select int.Parse(item)).Sum();
        }

        private void CheckForProgress(Label label, RangePointer rangePointer, Label label1, int progress, bool flag = false)
        {            
            if (progress > 0)
            {
                label.TextColor = Color.Green;
                if (!flag) label.Text = "+" + $"{progress}" + " Молодець!";
                else label.Text = "+" + $"{progress}s" + " Молодець!";
                rangePointer.Color = Color.Green;
                label1.TextColor = Color.Green;
            }
            if (progress == 0)
            {
                label.TextColor = Color.White;
                if (!flag) label.Text = $"{progress}" + " Непогано.";
                else label.Text = $"{progress}s" + " Непогано.";
                rangePointer.Color = Color.FromHex("#205be6");
                label1.TextColor = Color.FromHex("#205be6");
            }
            if (progress < 0)
            {
                label.TextColor = Color.Red;
                if (!flag) label.Text = $"{progress}s" + " Можна краще!";
                else label.Text = label.Text = $"{progress}s" + " Можна краще!";
                rangePointer.Color = Color.Red;
                label1.TextColor = Color.Red;
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

        private StackLayout CreateNewItem(string data, int percent, string progress)
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