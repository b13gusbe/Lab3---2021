using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab3___2021
{
    [Serializable]
    public class Question
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }

        private int correctAnswer;
        public int CorrectAnswer => correctAnswer;
        public string Subject { get; set; }
        public Uri ImageUri { get; set; }


        public Question (string statement, int correctAnswer, string subject, params string[] answers)
        {
            Statement = statement;
            Answers = answers;
            this.correctAnswer = correctAnswer;
            Subject = subject;
            Uri resourceUri = new Uri("/Images/Sunflower.jpg", UriKind.Relative);
            ImageUri = resourceUri;
        }

        public Question()
        {

        }

        public override string ToString()
        {
            return Statement;
        }

        public void SetCorrectAnswer(int i)
        {
            correctAnswer = i;
        }
    }
}
