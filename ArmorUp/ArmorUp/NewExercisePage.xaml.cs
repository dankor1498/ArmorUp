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
            Label label = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Approach " + CountClick++,
            };
            Entry entry = new Entry();
            MainStackLayout.Children.Add(label);
            MainStackLayout.Children.Add(entry);
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
            if (TypePicker.SelectedIndex == -1 || NameEntry == null || NameEntry.Text == "")
            {
                DisplayAlert("Помилка", "Ви не вибрали тип або не ввели ім'я!", "Добре");
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
                                DBSaverLoader.SAVE_EXERCISE(new ExercisesApproach()
                                {
                                    Name = NameEntry.Text,
                                    Information = InformationEditor.Text,
                                    LinkName = NameLinkEntry.Text,
                                    LinkURL = UrlLinkEntry.Text,
                                    ApproachList = new List<int>() { 30, 30, 30 }
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
                        DisplayAlert("Помилка. Формат цілі.", "Невірно введена ціль!", "Добре");
                }
            }
        }
    }
}