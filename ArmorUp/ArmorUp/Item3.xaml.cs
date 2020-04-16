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
    public partial class Item3 : ContentPage
    {
        public Item3()
        {
            InitializeComponent();
        }

        private void NewExercisePage_Clicked(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Detail = new NewExercisePage();
        }
    }
}