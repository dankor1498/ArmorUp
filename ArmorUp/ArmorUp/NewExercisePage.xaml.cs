using Syncfusion.XForms.Pickers;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePage : ContentPage
    {
        private static int CountClick = 1;

        public NewExercisePage()
        {
            InitializeComponent();
            CountClick = 1;
        }

        private void AddApproachButton__Clicked(object sender, EventArgs e)
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
                Placeholder = "Підхід " + CountClick++,
                PlaceholderColor = Color.LightGray
            };
            stackLayout.Children.Add(image);
            stackLayout.Children.Add(entry);
            frame.Content = stackLayout;

            ApproachStackLayout.Children.Add(frame);
        }
        private void TimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
        {
            var time = e.NewValue.ToString().Split(':');
            int hour = Int32.Parse(time[0]) * 3600;
            int minute = Int32.Parse(time[1]) * 60;
            int second = Int32.Parse(time[2]);
            PurposeEntry.Text = (hour + minute + second).ToString();
        }

        private void CreateApproachButton_Clicked(object sender, EventArgs e)
        {
            if (TypePicker.SelectedIndex == -1 || NameEntry == null || NameEntry.Text == "" || NameEntry.Text == null)
            {
                DisplayAlert("Помилка", "Ви не вибрали тип або не ввели ім'я!", "Добре");
                if (TypePicker.SelectedIndex == -1)
                {
                    PickerStackLayout.BorderColor = Color.Red;
                    PickerStackLayout.CornerRadius = 10;
                }
                else
                {
                    PickerStackLayout.BorderColor = Color.Black;
                    PickerStackLayout.CornerRadius = 10;
                }
                if (NameEntry == null || NameEntry.Text == "" || NameEntry.Text == null)
                {
                    NameStackLayout.BorderColor = Color.Red;
                    NameStackLayout.CornerRadius = 10;
                }
                else
                {
                    NameStackLayout.BorderColor = Color.Black;
                    NameStackLayout.CornerRadius = 10;
                }
            }
            else
            {
                try
                {
                    if (NameEntry != null && PurposeEntry != null && NameEntry.Text != "" && TypePicker.SelectedIndex != -1)
                    {
                        switch (TypePicker.SelectedIndex)
                        {
                            case 0:
                                DBSaverLoader.SAVE_EXERCISE(new ExercisesCount()
                                {
                                    Name = NameEntry.Text,
                                    Information = InformationEditor.Text,
                                    LinkName = NameLinkEntry.Text,
                                    LinkURL = UrlLinkEntry.Text,
                                    Purpose = Int32.Parse(PurposeEntry.Text)
                                }, App.Database);
                                App.UpdateMainTableList(); break;
                            case 1:
                                List<int> ApproachListInt = new List<int>();
                                for (int i = 0; i < ApproachStackLayout.Children.Count; ++i)
                                {
                                    Frame frame = ApproachStackLayout.Children[i] as Frame;
                                    StackLayout stackLayout = frame.Content as StackLayout;
                                    Entry entry = stackLayout.Children[1] as Entry;
                                    ApproachListInt.Add(Int32.Parse(entry.Text));
                                }
                                DBSaverLoader.SAVE_EXERCISE(new ExercisesApproach()
                                {
                                    Name = NameEntry.Text,
                                    Information = InformationEditor.Text,
                                    LinkName = NameLinkEntry.Text,
                                    LinkURL = UrlLinkEntry.Text,
                                    ApproachList = ApproachListInt
                                }, App.Database);
                                App.UpdateMainTableList(); break;
                            case 2:
                                DBSaverLoader.SAVE_EXERCISE(new ExercisesTime()
                                {
                                    Name = NameEntry.Text,
                                    Information = InformationEditor.Text,
                                    LinkName = NameLinkEntry.Text,
                                    LinkURL = UrlLinkEntry.Text,
                                    Time = new TimeSpan(0, 0, Int32.Parse(PurposeEntry.Text))
                                }, App.Database);
                                App.UpdateMainTableList(); break;
                        }
                    }
                    Navigation.PushAsync(new ProfilePage());
                }
                catch(Exception)
                {
                    bool tryParse = Int32.TryParse(PurposeEntry.Text, out int result);
                    if (tryParse == false)
                    {
                        DisplayAlert("Помилка. Формат цілі.", "Невірно введена кількість!", "Добре");
                        PickerStackLayout.BorderColor = Color.Black;
                        PickerStackLayout.CornerRadius = 10;
                        NameStackLayout.BorderColor = Color.Black;
                        NameStackLayout.CornerRadius = 10;
                        MissionStackLayout.BorderColor = Color.Red;
                        MissionStackLayout.CornerRadius = 10;
                    }
                }
            }
        }
    }
}