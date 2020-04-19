using System;
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

        private void CreateApproachButton_Clicked(object sender, EventArgs e)
        {
            if (NameEntry != null && PurposeEntry != null && TypePicker.SelectedIndex != -1)
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
                }
            }
            Navigation.PushAsync(new ProfilePage());
        }
    }
}