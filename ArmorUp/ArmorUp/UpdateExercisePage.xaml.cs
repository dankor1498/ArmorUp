using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateExercisePage : ContentPage
    {
        private Exercises exercises = DBSaverLoader.LOAD_EXERCISE(Exercises.CurrentExercisesId, App.Database);

        public UpdateExercisePage()
        {
            InitializeComponent();
            NameEntry.Text = exercises.Name;
            InformationEditor.Text = exercises.Information;
            NameLinkEntry.Text = exercises.LinkName;
            UrlLinkEntry.Text = exercises.LinkURL;
            TypeLabel.Text += "Count";
            PurposeEntry.Text = (exercises as ExercisesCount).Purpose.ToString();
        }

        private void UpdateApproachButton_Clicked(object sender, EventArgs e)
        {
            if (NameEntry != null && PurposeEntry != null)
            {
                DBSaverLoader.UPDATE_EXERCISE(Exercises.CurrentExercisesId, new ExercisesCount()
                {
                    Name = NameEntry.Text,
                    Information = InformationEditor.Text,
                    LinkName = NameLinkEntry.Text,
                    LinkURL = UrlLinkEntry.Text,
                    Purpose = Int32.Parse(PurposeEntry.Text)
                }, App.Database);
                App.UpdateMainTableList();
            }
            Navigation.PushAsync(new ProfilePage());
        }
    }
}