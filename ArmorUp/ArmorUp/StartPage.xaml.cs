using Plugin.Settings;
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
    }
}