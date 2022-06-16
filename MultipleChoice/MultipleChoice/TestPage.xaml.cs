using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultipleChoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        List<string> questions = new List<string>();
        List<string> answers = new List<string>();
        IDictionary<int, string> userAnswers = new Dictionary<int, string>();
        IDictionary<int, string> truthAnswers = new Dictionary<int, string>();
        int questionCounter = 0;
        public TestPage(List<string> questionsAnswers)
        {
            InitializeComponent();
            Title = "Τεστ Αυτοαξιολόγησης";
            Console.WriteLine("Count" + questionsAnswers.Count);
            generateQuestionaire(questionsAnswers);
            InitQuestionAnswers();
            answersReader();
        }

        public void generateQuestionaire(List<string> questionsAnswers)
        {
            for (int i = 0; i < questionsAnswers.Count; i++)
            {
                // Get element at this index.
                string value = questionsAnswers[i];

                //Split to * to get qustions and answers
                string[] subs = value.Split('*');
                if (subs.Length > 0)
                {
                    questions.Add(subs[0]);
                }


                string answer = "";

                int cnt = 0;
                foreach (string ans in subs)
                {
                    if (cnt > 0)
                    {
                        answer += ans;
                        answer += "*";
                    }

                    cnt++;
                }
                answers.Add(answer);


            }
        }

        public void InitQuestionAnswers()
        {
            Question.Text = questions[questionCounter];
            String[] ans = answers[questionCounter].Split('*');
            Answer1.Text = ans[0];
            Answer2.Text = ans[1];
            if(ans.Length > 3)
            {
                Answer3.Text = ans[2];
                Answer4.Text = ans[3];

                //Answer3.IsVisible = true;
                //Answer4.IsVisible = true;
                Answer3.HeightRequest = -1;
                Answer4.HeightRequest = -1;
            }
            else
            {
                //Answer3.IsVisible = false;
                //Answer4.IsVisible = false;
                Answer3.HeightRequest = 0;
                Answer4.HeightRequest = 0;
            }
           
        }

        private async void Answer1_Clicked(object sender, EventArgs e)
        {

            //Clear answers colors
            clearAnswers();

            Answer1.BackgroundColor = Color.Red;
            await Task.Delay(200);  //wait 200ms to clear the background color of previous' question selected answer

            //Clear answers colors
            clearAnswers();
        

            //Store user answer
            //userAnswers.Add(questionCounter, "a");
            userAnswers[questionCounter] = "a";

            if (questionCounter < questions.Count - 1)
            {
                questionCounter++;


                String value;
                bool hasValue = userAnswers.TryGetValue(questionCounter, out value);

                if (hasValue)
                {
                    //Color selected answer (if exists)
                    colorSelectedAnswer();

                    if (questionCounter == questions.Count - 1)
                    {
                        Submit.IsVisible = true;
                    }
                }


                //Update backButton text
                updateBackButtonText();
                updateUI();



            }
            else
            {
                //calcResults
                //calcResults();
                clearAnswers();
                Answer1.BackgroundColor = Color.Red;
                Submit.IsVisible = true;
            }
        }

        private async void Answer2_Clicked(object sender, EventArgs e)
        {
            //Clear answers colors
            clearAnswers();

            Answer2.BackgroundColor = Color.Red;
            await Task.Delay(200);  //wait 200ms to clear the background color of previous' question selected answer

            //Clear answers colors
            clearAnswers();
      

            //Store user answer
            //userAnswers.Add(questionCounter, "b");
            userAnswers[questionCounter] = "b";

            if (questionCounter < questions.Count - 1)
            {

                questionCounter++;


                String value;
                bool hasValue = userAnswers.TryGetValue(questionCounter, out value);

                if (hasValue)
                {
                    //Color selected answer (if exists)
                    colorSelectedAnswer();

                    if (questionCounter == questions.Count - 1)
                    {
                        Submit.IsVisible = true;
                    }
                }


                //Update backButton text
                updateBackButtonText();
                updateUI();
            }
            else
            {
                //calcResults
                //calcResults();
                clearAnswers();
                Answer2.BackgroundColor = Color.Red;
                Submit.IsVisible = true;
            }
        }

        private async void Answer3_Clicked(object sender, EventArgs e)
        {
            //Clear answers colors
            clearAnswers();

            Answer3.BackgroundColor = Color.Red;
            await Task.Delay(200);  //wait 200ms to clear the background color of previous' question selected answer

            //Clear answers colors
            clearAnswers();
          

            //Store user answer
            //userAnswers.Add(questionCounter, "c");
            userAnswers[questionCounter] = "c";

            if (questionCounter < questions.Count - 1)
            {
                questionCounter++;


                String value;
                bool hasValue = userAnswers.TryGetValue(questionCounter, out value);

                if (hasValue)
                {
                    //Color selected answer (if exists)
                    colorSelectedAnswer();

                    if (questionCounter == questions.Count - 1)
                    {
                        Submit.IsVisible = true;
                    }
                }


                //Update backButton text
                updateBackButtonText();
                updateUI();
            }
            else
            {
                //calcResults
                //calcResults();
                clearAnswers();
                Answer3.BackgroundColor = Color.Red;
                Submit.IsVisible = true;
            }
        }

        private async void Answer4_Clicked(object sender, EventArgs e)
        {
            //Clear answers colors
            clearAnswers();

            Answer4.BackgroundColor = Color.Red;
            await Task.Delay(200);  //wait 200ms to clear the background color of previous' question selected answer

            //Clear answers colors
            clearAnswers();
          

            //Store user answer
            //userAnswers.Add(questionCounter, "d");
            userAnswers[questionCounter] = "d";

            if (questionCounter < questions.Count - 1)
            {
                questionCounter++;

                
                String value;
                bool hasValue = userAnswers.TryGetValue(questionCounter, out value);

                if (hasValue)
                {
                    //Color selected answer (if exists)
                    colorSelectedAnswer();

                    if(questionCounter == questions.Count - 1)
                    {
                        Submit.IsVisible = true;
                    }
                }


                //Update backButton text
                updateBackButtonText();
                updateUI();
            }

            else
            {
                //calcResults
                //calcResults();
                clearAnswers();
                Answer4.BackgroundColor = Color.Red;
                Submit.IsVisible = true;
            }
        }


        public void updateUI()
        {
            Question.Text = questions[questionCounter];
            String[] ans = answers[questionCounter].Split('*');
            Answer1.Text = ans[0];
            Answer2.Text = ans[1];
            if (ans.Length > 3)
            {
                Answer3.Text = ans[2];
                Answer4.Text = ans[3];

                Answer3.HeightRequest = -1;
                Answer4.HeightRequest = -1;

            }
            else
            {
                Answer3.HeightRequest = 0;
                Answer4.HeightRequest = 0;
            }
        }



        public void answersReader()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string name = "MultipleChoice.truthAnswers.txt";
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
                            string[] ans = lines[i].Split(',');
                            truthAnswers.Add(int.Parse(ans[0]), ans[1].Replace("\n", "").Replace("\r", ""));
                        }


                    }
                }
            }
            catch (InvalidCastException e)
            {
            }

            foreach (KeyValuePair<int, string> t in truthAnswers)
            {
                Console.WriteLine("truth key value : " + t.Key + ", " + t.Value);
            }
        }

        public void calcResults()
        {
            int cnt = 0;
            int correctAnswers = 0;
            foreach (KeyValuePair<int, string> entry in userAnswers)
            {
                // do something with entry.Value or entry.Key
                //if(entry.Value.Equals(truthAnswers.get))

                String value;
                bool hasValue = truthAnswers.TryGetValue(entry.Key, out value);

                if (hasValue)
                {
                    //Console.WriteLine("value, truth : " + value+","+ entry.Value);
                    if (string.Equals(entry.Value, value))
                    {
                        correctAnswers++;
                    }
                }
                cnt++;
            }

            double correctAnswersRatio = (double)correctAnswers / cnt;
            //Console.WriteLine("Results : " + correctAnswersRatio);
            //Question.Text = "";
            //Answer1.Text = correctAnswersRatio.ToString("0.0");
            //Answer2.Text = "";
            //Answer3.Text = "";
            //Answer4.Text = "";

            NavigationPage resultpage = new NavigationPage(new ResultPage(correctAnswers, cnt, correctAnswersRatio))
            {
                BarBackgroundColor = Color.FromHex("#00b6a8"),
                BarTextColor = Color.FromHex("#ffffff")
            };

            Navigation.PushModalAsync(resultpage);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Submit.IsVisible = false;
            clearAnswers();
            if (questionCounter > 0)
            {
                questionCounter--;
                colorSelectedAnswer();
                updateUI();
                if(questionCounter == 0)
                {
                    Back.Text = "Επιστροφή στο αρχικό μενού";
                }
            }
            else if (questionCounter == 0)
            {
                
                Navigation.PushModalAsync(new MainPage());
            }

        }

        public void updateBackButtonText()
        {
            if (questionCounter > 0)
            {
                Back.Text = "Προηγούμενη ερώτηση";
            }
            else if (questionCounter == 0)
            {
                Back.Text = "Aρχικό μενού";
            }
        }

        public void colorSelectedAnswer()
        {
            if(userAnswers[questionCounter].Equals("a"))
            {
                clearAnswers();
                Answer1.BackgroundColor = Color.Red;
                //Answer2.BackgroundColor = Color.FromHex("#535151");
                //Answer3.BackgroundColor = Color.FromHex("#535151");
                //Answer4.BackgroundColor = Color.FromHex("#535151");
            }
            else if (userAnswers[questionCounter].Equals("b"))
            {
                clearAnswers();
               // Answer1.BackgroundColor = Color.FromHex("#535151");
                Answer2.BackgroundColor = Color.Red;
               // Answer3.BackgroundColor = Color.FromHex("#535151");
               // Answer4.BackgroundColor = Color.FromHex("#535151");
            }
            else if (userAnswers[questionCounter].Equals("c"))
            {
                clearAnswers();
               // Answer1.BackgroundColor = Color.FromHex("#535151");
              //  Answer2.BackgroundColor = Color.FromHex("#535151");
                Answer3.BackgroundColor = Color.Red;
              //  Answer4.BackgroundColor = Color.FromHex("#535151");
            }
            else if (userAnswers[questionCounter].Equals("d"))
            {
                clearAnswers();
               // Answer1.BackgroundColor = Color.FromHex("#535151");
              //  Answer2.BackgroundColor = Color.FromHex("#535151");
              //  Answer3.BackgroundColor = Color.FromHex("#535151");
                Answer4.BackgroundColor = Color.Red;
            }
        }

        public void clearAnswers()
        {
            Answer1.BackgroundColor = Color.FromHex("#535151");
            Answer2.BackgroundColor = Color.FromHex("#535151");
            Answer3.BackgroundColor = Color.FromHex("#535151");
            Answer4.BackgroundColor = Color.FromHex("#535151");
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Υποβολή", "Είσαι σίγουρος πως θες να υποβάλεις τις απαντήσεις σου;", "Ναι", "Όχι");
            if(answer)
            {
                calcResults();
            }
        }


    }
}