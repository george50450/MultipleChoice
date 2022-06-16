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
    public partial class CorrectAnswers : ContentPage
    {
        public CorrectAnswers()
        {
            InitializeComponent();
            Title = "Σωστές Απαντήσεις";
        }

        private void Menu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}