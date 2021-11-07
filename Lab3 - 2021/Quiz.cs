using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___2021
{
    
    public class Quiz
    {
        //Om jag använder Questions som en ICollection här och sätter en set; då slutar listboxen att fungera, utan set fungerar det inte att spara.
        //Jag testade även att casta set med as ObservableCollection<Question> men det orskade en stackoverflow
        //public ICollection<Question> Questions { get; }
        public ObservableCollection<Question> Questions { get; set; }
        public string Title { get; set; }

        private static readonly Random random = new();

        public Quiz(string title, ObservableCollection<Question> questions)
        {
            Title = title;
            if(questions != null)
            {
                Questions = questions;
            } else
            {
                Questions = new ObservableCollection<Question>();
            }
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
