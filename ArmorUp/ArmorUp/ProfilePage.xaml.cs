using Plugin.Settings;
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
            UserNameLabel.Text = MainPage.User;
            UserImage.Source = ImageSource.FromFile(App.UserImagePath);
            foreach (var item in App.MainTableArray)
            {
                AllExercisesStackLayout.Children.Add(AddExercisesToProfilePage(item));
            }
            PrintQuote();
        }

        public void PrintQuote()
        {
            if (App.iteratorQuote > Motivation.Quotes.Length - 1)
            {
                App.iteratorQuote = 0;
            }
            App.CurrentQuote = Motivation.Quotes[App.iteratorQuote];
            CrossSettings.Current.AddOrUpdateValue("IteratorQuote", App.iteratorQuote++);
            TextLabel.Text = App.CurrentQuote.Words;
            AuthorLabel.Text = App.CurrentQuote.Author;
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
        private StackLayout AddExercisesToProfilePage(MainTable mainTable)
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
                ClassId = mainTable.ID.ToString(),
                Text = mainTable.Name,
                WidthRequest = 90,
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
                ClassId = mainTable.ID.ToString(),
                Text = "Del",
                WidthRequest = 5,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White
            };
            button1.Clicked += DeleteExerciseButton_Click;

            Frame frame2 = new Frame()
            {
                CornerRadius = 10,
                Padding = new Thickness(0),
                Margin = new Thickness(0, 5, 0, 5),
                IsClippedToBounds = true,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Button button2 = new Button()
            {
                ClassId = mainTable.ID.ToString(),
                Text = "Upd",
                WidthRequest = 5,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("#262626"),
                TextColor = Color.White
            };
            button2.Clicked += UpdateExerciseButton_Click;

            frame.Content = button;
            frame1.Content = button1;
            frame2.Content = button2;
            stackLayout.Children.Add(frame);
            stackLayout.Children.Add(frame1);
            stackLayout.Children.Add(frame2);

            return stackLayout;
        }

        private void UpdateExerciseButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Exercises.CurrentExercisesId = int.Parse(button.ClassId);
            Navigation.PushAsync(new UpdateExercisePage());
        }

        private void YourButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;            
            Exercises.CurrentExercisesId = int.Parse(button.ClassId);
            Navigation.PushAsync(new CurrentExercise());
        }
        private void DeleteExerciseButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;            
            App.Database.DeleteItem(int.Parse(button.ClassId));
            App.UpdateMainTableList();
            Navigation.PushAsync(new ProfilePage());
        }
    }
}