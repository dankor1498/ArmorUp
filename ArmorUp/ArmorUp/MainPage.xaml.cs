using System;   
using Xamarin.Forms;

namespace ArmorUp
{
    
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Detail = new NavigationPage(new Item3())
            //{
            //    BarBackgroundColor = Color.FromHex("#65186e")
            //};
            Detail = new Item3();
            IsPresented = true;
        }

        private void Item1_clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new Item1())
            //{
            //    BarBackgroundColor = Color.FromHex("#65186e")
            //};
            Detail = new Item1();
            IsPresented = false;
        }
        private void Item2_Clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new Item2())
            //{
            //    BarBackgroundColor = Color.FromHex("#65186e")
            //};
            Detail = new Item2();
            IsPresented = false;
        }

        private void Item3_Clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new Item3())
            //{
            //    BarBackgroundColor = Color.FromHex("#65186e")
            //};
            Detail = new Item3();
            IsPresented = false;
        }
    }
}
