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
    public partial class ProfilePage : ContentPage
    {
        //Test Test Test
        static List<Exercises> ExercisesList = new List<Exercises>()
        {
            new Exercises("jumping", "sport.jpg", 100, "+3"),
            new Exercises("skating", "sport.jpg", 69, "+7"),
            new Exercises("long jump", "sport.jpg", 50, "-1"),
            new Exercises("pulling up", "sport.jpg", 31, "-9"),
            new Exercises("push-ups", "sport.jpg", 71, "+5"),
            new Exercises("squatting", "sport.jpg", 100, "+3")
        };
        public ProfilePage()
        {
            InitializeComponent();
            if (ExercisesList.Count != 0)
            {
                foreach (var exercises in ExercisesList)
                    AllExercisesStackLayout.Children.Add(AddExercisesToProfilePage(exercises));
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
                WidthRequest = 100,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White
            };
            button.Clicked += YourButtonClick;

            frame.Content = button;
            stackLayout.Children.Add(frame);

            return stackLayout;
        }
        private void YourButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            StackLayout stack = button.Parent.Parent as StackLayout;
            int ButtonIndex = AllExercisesStackLayout.Children.IndexOf(stack);
            Exercises.CurrentExercises = ExercisesList[ButtonIndex];
            Navigation.PushAsync(new CurrentExercise());
        }
    }
}