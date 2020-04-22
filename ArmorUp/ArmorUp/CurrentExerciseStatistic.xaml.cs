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
        public CurrentExerciseStatistic()
        {
            InitializeComponent();
            for (int i = 0; i < 2; ++i)
                ExerciseByDataStackLayout.Children.Add(CreateNewItem());
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
        private StackLayout CreateNewItem(/*some variable*/)
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
                Text = "14.07.2000"
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
                Text = "71%",
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
                Text = "+3",
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