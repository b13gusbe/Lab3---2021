using Lab3___2021.Managers;
using Lab3___2021.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab3___2021.ViewModels
{
    class PlayQuizViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataModel _dataModel;
        
        private int _currentQuestionIndex;
        private ObservableCollection<Question> _playQuiz;


        public int Score { get; set; }
        public string ProgressLabel { get; set; }
        public Question CurrentQuestion { get; set; }


        public PlayQuizViewModel(NavigationManager navigationManager, DataModel datamodel, Quiz quiz, object subjects)
        {
            _navigationManager = navigationManager;
            _dataModel = datamodel;
            _currentQuestionIndex = 0;
            
            GenerateQuiz(quiz.Questions, subjects);
            CurrentQuestion = _playQuiz[0];
            ProgressLabel = $"{_currentQuestionIndex + 1} / {_playQuiz.Count}";
        }

        private void GenerateQuiz(ObservableCollection<Question> questions, object subjects)
        {

            System.Collections.IList items = (System.Collections.IList)subjects;
            var subjects2 = items.Cast<string>().ToList();
            

            if (subjects2.Count == 0)
            {
                _playQuiz = new ObservableCollection<Question>(questions);
            } else
            {
                _playQuiz = new ObservableCollection<Question>();
                
                foreach (string subject in subjects2)
                {
                    var temp = new List<Question>(questions);
                    temp = temp.FindAll(question => question.Subject == subject);
                    foreach(Question question in temp)
                    {
                        _playQuiz.Add(question);
                    }                    
                }
            }
        }

        public ICommand MainMenuCommand => new RelayCommand(() => _navigationManager.SelectedViewModel = new MainMenuViewModel(_navigationManager, _dataModel));

        public ICommand Answer1Command => new RelayCommand(Answer1Selected);
        public ICommand Answer2Command => new RelayCommand(Answer2Selected);
        public ICommand Answer3Command => new RelayCommand(Answer3Selected);


        private void Answer1Selected()
        {
            if(CurrentQuestion.CorrectAnswer == 0)
            {
                Score++;
            }
            NextQuestion();
        }        
        

        private void Answer2Selected()
        {
            if (CurrentQuestion.CorrectAnswer == 1)
            {
                Score++;
            }
            NextQuestion();
        }        
        

        private void Answer3Selected()
        {
            if (CurrentQuestion.CorrectAnswer == 2)
            {
                Score++;
            }
            NextQuestion();
        }

        private void NextQuestion()
        {
            if(_currentQuestionIndex == _playQuiz.Count - 1)
            {
                MessageBox.Show($"Du hade rätt på {Score} av {_playQuiz.Count} frågor.");
            }
            else
            {
                _currentQuestionIndex++;
                CurrentQuestion = _playQuiz[_currentQuestionIndex];
                ProgressLabel = $"{_currentQuestionIndex + 1} / {_playQuiz.Count}";
                OnPropertyChanged(nameof(CurrentQuestion));
                OnPropertyChanged(nameof(ProgressLabel));
                OnPropertyChanged(nameof(Score));
            }
        }

    }
}
