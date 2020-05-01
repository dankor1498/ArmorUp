using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class UserSettings : ContentPage
    {
        public UserSettings()
        {
            InitializeComponent();
            UserName.Text = MainPage.User;
            UserImage.Source = ImageSource.FromFile(App.UserImagePath);
        }

        private void Change_UserName_Clicked(object sender, EventArgs e)
        {
            if (Change_UserName.Text == "Change username")
            {
                Change_UserName.Text = "Save";
                UserName.IsReadOnly = false;
                UserNameFrame.BorderColor = Color.FromHex("#205be6");
            }
            else
            {
                Change_UserName.Text = "Change username";
                UserName.IsReadOnly = true;
                UserNameFrame.BorderColor = Color.Black;

                if (UserName.Text == null || UserName.Text == null || UserName.Text.Trim() == "" || UserName.Text.Trim() == "")
                {
                    DisplayAlert("Помилка", "Ви не не ввели ім'я або прізвище!", "Добре");
                }
                else
                {
                    CrossSettings.Current.AddOrUpdateValue("User", $"{UserName.Text}");
                    MainPage.User = $"{UserName.Text}";
                }
            }
        }

        private async void ChangeUserPhoto_Clicked(object sender, EventArgs e)
        {
            Image img = new Image();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions() { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 600 });
                img.Source = ImageSource.FromFile(photo.Path);
                UserImage.Source = img.Source;
                App.UserImagePath = Path.Combine(DBSaverLoader.documentsPath, "photo" + Path.GetExtension(photo.Path));
                CrossSettings.Current.AddOrUpdateValue("UserImagePath", App.UserImagePath);
                File.Copy(photo.Path, App.UserImagePath, true);
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
    }
}