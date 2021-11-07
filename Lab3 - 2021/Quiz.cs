using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___2021
{
    [Serializable]
    public class Quiz
    {
        public ICollection<Question> Questions { get; }
        public string Title { get; set; }

        private static readonly Random random = new();

        public Quiz(string title)
        {
            Title = title;
            Questions = new ObservableCollection<Question>();
        }

        public Quiz()
        {

        }


        public Question GetRandomQuestion()
        {
            int index = random.Next(0, Questions.Count);
            return Questions.ToList()[index];
        }

        public void AddQuestion(string statement, int correctAnswer, string subject, params string[] answers)
        {
            Questions.Add(new Question(statement, correctAnswer, subject, answers));
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            //Questions.ToList().RemoveAt(index);
            Questions.Remove(question);
        }


        public override string ToString()
        {
            return Title;
        }

    }
}
