using System;   
using Xamarin.Forms;

namespace ArmorUp
{
    
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new Item1())
            {
                BarBackgroundColor = Color.FromHex("#546bf0")
            };
            IsPresented = false;
        }

        private void Item1_clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Item1())
            {
                BarBackgroundColor = Color.FromHex("#546bf0")
            };
            IsPresented = false;
        }
        private void Item2_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Item2())
            {
                BarBackgroundColor = Color.FromHex("#546bf0")
            };
            IsPresented = false;
        }
    }
}
