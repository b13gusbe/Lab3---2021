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
using System.Windows.Input;

namespace Lab3___2021.ViewModels
{
    class PlayQuizViewModel : ObservableObject
    {
        private NavigationManager _navigationManager;
        private DataModel _dataModel;
        private Quiz _quiz;
        private ObservableCollection<string> _subjects;

        private int _score;
        private Question _currentQuestion;
        

        public PlayQuizViewModel(NavigationManager navigationManager, DataModel datamodel, Quiz quiz, ObservableCollection<string> subjects)
        {
            _navigationManager = navigationManager;
            _dataModel = datamodel;
            _quiz = quiz;
            _subjects = subjects;
            //_currentQuestion = _quiz.Questions[0];
        }


        public ICommand MainMenuCommand => new RelayCommand(() => _navigationManager.SelectedViewModel = new MainMenuViewModel(_navigationManager, _dataModel));

        public ICommand Answer1Command => new RelayCommand(Answer1Selected);
        public ICommand Answer2Command => new RelayCommand(Answer2Selected);
        public ICommand Answer3Command => new RelayCommand(Answer3Selected);


        private void Answer1Selected()
        {
            if(_currentQuestion.CorrectAnswer == 0)
            {
                _score++;
            }
        }        
        

        private void Answer2Selected()
        {
            if (_currentQuestion.CorrectAnswer == 0)
            {
                _score++;
            }
        }        
        

        private void Answer3Selected()
        {
            if (_currentQuestion.CorrectAnswer == 0)
            {
                _score++;
            }
        }

        private void NextQuestion()
        {

        }

    }
}
