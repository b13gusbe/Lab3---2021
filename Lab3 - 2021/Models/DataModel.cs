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
        public ObservableCollection<Quiz> _quizzes { get; set; }

        private readonly string _fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SavedQuizzes.txt");
        

        public DataModel()
        {
            if (File.Exists(_fileName))
            {
                _ = LoadQuizzes();
            }
            else
            {
                _quizzes = new ObservableCollection<Quiz>();
                Quiz testQuiz = new Quiz("Test Quiz", null);
                testQuiz.AddQuestion("Test Statement", 2, "Test Subject", new string[] { "Answer 1", "Answer 2", "Answer 3" });
                _quizzes.Add(testQuiz);
            }
        }
        
        public void AddQuiz(Quiz quiz)
        {
            _quizzes.Add(quiz);
        }

        public void RemoveQuiz(Quiz quiz)
        {
            _quizzes.Remove(quiz);
        }

        public async Task SaveQuizes()
        {
            await using FileStream createStream = File.Create(_fileName);
            await JsonSerializer.SerializeAsync(createStream, _quizzes);
            await createStream.DisposeAsync();
        }
        public async Task LoadQuizzes()
        {

            await using FileStream openStream = File.OpenRead(_fileName);
            _quizzes = await JsonSerializer.DeserializeAsync<ObservableCollection<Quiz>>(openStream);
        }
    }
}
