using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Lab3___2021.Models
{
    public class QuizManagerModel
    {
        //private readonly ICollection<Quiz> _quizes;


        public ObservableCollection<Quiz> _quizes { get; set; }

        private readonly string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "hejsevejs\\Test.txt");


        //private readonly List<Quiz> _quizes;

        public QuizManagerModel(ObservableCollection<Quiz> quizes)
        {
            //if (File.Exists(fileName))
            //{
            //    //JsonSerializer jsonSerializer = new JsonSerializer();
            //    //StreamReader sr = new StreamReader(fileName);
            //    //JsonReader jsonReader = new JsonTextReader(sr);
            //    //JObject obj = jsonSerializer.Deserialize(jsonReader) as JObject;
            //    //_quizes = obj.ToObject();

            //    string jsonString = File.ReadAllText(fileName);
            //    _quizes = JsonSerializer.Deserialize<ObservableCollection<Quiz>>(jsonString);

            //}
            //else 
            //{
            //    _quizes = quizes;
            //}
            _quizes = quizes;
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

        public ObservableCollection<Quiz> LoadQuizes()
        {
            ObservableCollection<Quiz> quizzes = new ObservableCollection<Quiz>();
            return quizzes;
        }
        
        


    }
}
