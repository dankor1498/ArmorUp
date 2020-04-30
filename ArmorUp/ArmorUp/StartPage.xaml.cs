using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Settings;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArmorUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (NameEntry.Text == null || SurnameEntry.Text == null || NameEntry.Text.Trim() == "" || SurnameEntry.Text.Trim() == "")
            {
                DisplayAlert("Помилка", "Ви не не ввели ім'я або прізвище!", "Добре");
            }
            else
            {
                CrossSettings.Current.AddOrUpdateValue("User", $"{NameEntry.Text} {SurnameEntry.Text}");
                MainPage.User = $"{NameEntry.Text} {SurnameEntry.Text}";
                Navigation.PushAsync(new ProfilePage());
            }
        }

        private async void TakePictureButton_Clicked(object sender, EventArgs e)
        {
            Image img = new Image();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                img.Source = ImageSource.FromFile(photo.Path);
                UserImage.Source = img.Source;                
                App.UserImagePath = Path.Combine(DBSaverLoader.documentsPath, "photo" + Path.GetExtension(photo.Path));
                CrossSettings.Current.AddOrUpdateValue("UserImagePath", App.UserImagePath);
                File.Copy(photo.Path, App.UserImagePath, true);
            }
        }
    }
}