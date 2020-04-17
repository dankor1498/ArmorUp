using System;   
using Xamarin.Forms;

namespace ArmorUp
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new ProfilePage());
            IsPresented = false;
        }
    }
}
