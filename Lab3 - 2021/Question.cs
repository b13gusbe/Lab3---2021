using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___2021
{
    class Question
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }

        public readonly int CorrectAnswer;
        public string Subject { get; set; }



        public Question (string statement, int correctAnswer, string subject, params string[] answers)
        {
            Statement = statement;
            Answers = answers;
            CorrectAnswer = correctAnswer;
            Subject = subject;
        }

    }
}
