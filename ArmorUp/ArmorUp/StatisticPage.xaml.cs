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
    public partial class StatisticPage : ContentPage
    {
        public StatisticPage()
        {
            InitializeComponent();
            foreach (var item in App.MainTableList)
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

        private StackLayout AddStatisticByExercise(MainTable mainTable)
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
                Source = "sport.jpg",
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
                Text = mainTable.Name,
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
                Text = "50%",
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
                Text = "+4",
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            //done 4
            SucsessFrame.Content = SucsessLabel;

            stackLayout.Children.Add(PictureFrame);
            stackLayout.Children.Add(TextFrame);
            stackLayout.Children.Add(PercentFrame);
            stackLayout.Children.Add(SucsessFrame);

            return stackLayout;
        }
        private void YourButtonClick(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            //StackLayout stack = button.Parent.Parent as StackLayout;
            //int ButtonIndex = ExercisesStackLayout.Children.IndexOf(stack);
            //Exercises.CurrentExercises = ExercisesList[ButtonIndex];
            //Navigation.PushAsync(new CurrentExercise());
        }
    }
}