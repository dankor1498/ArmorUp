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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            try
            {
                foreach (var exercises in ExercisesDB.CurrentExercisesList.ExercisesList)
                {
                    AllExercisesStackLayout.Children.Add(AddExercisesToProfilePage(exercises));
                }
            }
            catch (Exception) { }
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
        private StackLayout AddExercisesToProfilePage(Exercises exercises)
        {
            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(5)
            };
            Frame frame = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 5, 0, 5),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Button button = new Button()
            {
                Text = exercises.Name,
                WidthRequest = 95,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White
            };
            button.Clicked += YourButtonClick;

            Frame frame1 = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 5, 0, 5),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Button button1 = new Button()
            {
                Text = "Del",
                WidthRequest = 5,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White
            };
            button1.Clicked += DeleteExerciseButton_Click;

            frame.Content = button;
            frame1.Content = button1;
            stackLayout.Children.Add(frame);
            stackLayout.Children.Add(frame1);

            return stackLayout;
        }
        private void YourButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            StackLayout stack = button.Parent.Parent as StackLayout;
            int ButtonIndex = AllExercisesStackLayout.Children.IndexOf(stack);
            Exercises.CurrentExId = ButtonIndex;
            Exercises.CurrentExercises = ExercisesDB.CurrentExercisesList.ExercisesList[ButtonIndex];
            Navigation.PushAsync(new CurrentExercise());
        }
        private void DeleteExerciseButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            StackLayout stack = button.Parent.Parent as StackLayout;
            int ButtonIndex = AllExercisesStackLayout.Children.IndexOf(stack);
            ExercisesDB.CurrentExercisesList.ExercisesList.RemoveAt(ButtonIndex);
            Navigation.PushAsync(new ProfilePage());
        }
    }
}