using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab3___2021.Models
{
    public class DataModel
    {
        public ObservableCollection<Quiz> _quizes { get; set; }

        private readonly string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "hejsevejs\\Test.txt");

        public DataModel()
        {
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                _quizes = JsonSerializer.Deserialize<ObservableCollection<Quiz>>(jsonString);
                Console.WriteLine();
            }
            else
            {
                _quizes = new ObservableCollection<Quiz>();

                Quiz testQuiz = new Quiz("Test Quiz", null);
                testQuiz.AddQuestion("Test Statement", 2, "Test Subject", new string[] { "Answer 1", "Answer 2", "Answer 3" });
                _quizes.Add(testQuiz);
            }
        }


        public void AddQuiz(Quiz quiz)
        {
            _quizes.Add(quiz);
        }

        public void RemoveQuiz(Quiz quiz)
        {
            _quizes.Remove(quiz);
        }

        public void SaveQuizes()
        {
            string jsonString = JsonSerializer.Serialize(_quizes);
            File.WriteAllText(fileName, jsonString);
        }

    }
}
