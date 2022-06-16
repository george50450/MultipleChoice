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
    public partial class ResultPage : ContentPage
    {
        public ResultPage(int correctAnswers, int questionsCounter, double result)
        {
            InitializeComponent();
            Title = "Αποτελέσματα Αυτοαξιολόγησης";
            //TextResult.Text = "Τελικό αποτέλεσμα";
            TextResult.TextColor = Color.Black;

            Result.Text = "Score: " + correctAnswers.ToString() + "/"  + questionsCounter.ToString();

            Percentage.Text = "Ποσοστό Επιτυχίας: " +  (result * 100).ToString() + " %";
        }

        private void Menu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private void Answers_Clicked(object sender, EventArgs e)
        {
            NavigationPage correctAnswersPage = new NavigationPage(new CorrectAnswers())
            {

                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };
            Navigation.PushModalAsync(correctAnswersPage);
        }
    }
}