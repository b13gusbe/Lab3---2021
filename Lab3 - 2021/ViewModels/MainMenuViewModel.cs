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
using System.Windows.Controls;

namespace Lab3___2021.ViewModels
{
    class MainMenuViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataModel _dataModel;

        public IRelayCommand NavigatePlayCommand { get; }
        public IRelayCommand NavigateManageCommand { get; }
        public IRelayCommand ExitGameCommand { get; }
        

        public MainMenuViewModel( NavigationManager navigationManager, DataModel dataModel)
        {
            _navigationManager = navigationManager;
            _dataModel = dataModel;
            NavigatePlayCommand = new RelayCommand<object>((a) => _navigationManager.SelectedViewModel = new PlayQuizViewModel(_navigationManager, _dataModel, _selectedQuiz, a));
            NavigateManageCommand = new RelayCommand(() => _navigationManager.SelectedViewModel = new QuizManagerViewModel(_navigationManager, _dataModel));
            ExitGameCommand = new RelayCommand(() => Environment.Exit(0));
        }


        public ObservableCollection<Quiz> Quizes => _dataModel._quizzes;

        public ObservableCollection<Question> Questions
        {
            get
            {
                if (SelectedQuiz != null)
                {
                    return SelectedQuiz.Questions as ObservableCollection<Question>;
                }
                return null;
            }
        }

        public ObservableCollection<string> Subjects
        {
            get
            {
                ObservableCollection<string> subjects = new();

                if (SelectedQuiz != null)
                {
                    List<Question> allQuestions = SelectedQuiz.Questions.OrderBy(question => question.Subject).ToList();

                    while (allQuestions.Count != 0)
                    {
                        var temp = allQuestions.FindAll(questions => questions.Subject == allQuestions[0].Subject);
                        subjects.Add(temp[0].Subject);
                        allQuestions.RemoveRange(0, temp.Count);
                    }
                }

                return subjects;
            }
        }


        private Quiz _selectedQuiz;
        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                SetProperty(ref _selectedQuiz, value);
                OnPropertyChanged(nameof(Questions));
                OnPropertyChanged(nameof(Subjects));
            }
        }


    }
}
