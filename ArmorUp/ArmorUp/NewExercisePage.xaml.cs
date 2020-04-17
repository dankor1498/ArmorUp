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
    public partial class NewExercisePage : ContentPage
    {
        static int CountClick = 1;
        public NewExercisePage()
        {
            InitializeComponent();
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
    }
}