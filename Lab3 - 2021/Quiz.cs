using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___2021
{
    class Quiz
    {
        public List<Question> Questions;
        public string Title;

        private static readonly Random random = new();

        public Quiz(string title)
        {
            Title = title;
            Questions = new List<Question>();
        }


        public Question GetRandomQuestion()
        {
            int index = random.Next(0, Questions.Count);
            return Questions[index];
        }

        public void AddQuestion(string statement, int correctAnswer, string subject, params string[] answers)
        {
            Questions.Add(new Question(statement, correctAnswer, subject, answers);
        }

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public void RemoveQuestion(int index)
        {
            Questions.RemoveAt(index);
        }




    }
}
