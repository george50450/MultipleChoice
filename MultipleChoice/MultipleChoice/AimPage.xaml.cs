using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AimPage : ContentPage
    {
        public AimPage()
        {
            Title = "Στόχοι Ενότητας";
            InitializeComponent();
        }

        private void Menu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}