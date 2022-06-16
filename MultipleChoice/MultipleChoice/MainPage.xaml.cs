using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultipleChoice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            xmlreader();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void beginTestButtn_Clicked(object sender, EventArgs e)
        {

            NavigationPage testpage = new NavigationPage(new TestPage(questionsAnswers))
            {
     
                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };

            Navigation.PushModalAsync(testpage);
        }


        public List<string> questionsAnswers = new List<string>();

        public void xmlreader()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string name = "MultipleChoice.testQuestions.txt";
            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(name))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string text = reader.ReadToEnd();
                        string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        //words.Text = lines[4];
                        for (int i = 0; i < lines.Length; i++)
                        {
                            questionsAnswers.Add(lines[i]);
                        }


                    }
                }
            }
            catch (InvalidCastException e)
            {
            }
        }

        private void aimsButtn_Clicked(object sender, EventArgs e)
        {
            
            NavigationPage aimPage = new NavigationPage(new AimPage())
            {

                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };

             Navigation.PushModalAsync(aimPage);
          
        }
    }
}
