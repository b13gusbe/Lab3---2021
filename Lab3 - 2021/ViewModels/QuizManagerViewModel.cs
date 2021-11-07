using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3___2021.Models;
using Lab3___2021.Views;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using Lab3___2021.Managers;

namespace Lab3___2021.ViewModels
{
    public class QuizManagerViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataModel _dataModel;

        public ObservableCollection<Quiz> Quizes => _dataModel._quizzes;
        public ObservableCollection<Question> Questions
        {
            get
            {
                if(SelectedQuiz != null)
                {
                    return SelectedQuiz.Questions as ObservableCollection<Question>;
                }
                return null;
            }
        }

        private bool answer0Check;
        public bool Answer0Check
        {
            get 
            {
                if(_selectedQuestion != null)
                {
                    return _selectedQuestion.CorrectAnswer == 0;
                }
                return false;
            }
            set
            {
                if (value == true && SelectedQuestion != null)
                {
                    _selectedQuestion.SetCorrectAnswer(0);
                }
                SetProperty(ref answer0Check, value);
                OnPropertyChanged(nameof(Answer1Check));
                OnPropertyChanged(nameof(Answer2Check));
            }
        }
        private bool answer1Check;
        public bool Answer1Check
        {
            get
            {
                if (_selectedQuestion != null)
                {
                    return _selectedQuestion.CorrectAnswer == 1;
                }
                return false;
            }
            set
            {
                if (value == true && SelectedQuestion != null)
                {
                    _selectedQuestion.SetCorrectAnswer(1);
                }
                SetProperty(ref answer1Check, value);
                OnPropertyChanged(nameof(Answer0Check));
                OnPropertyChanged(nameof(Answer2Check));
            }
        }
        private bool answer2Check;
        public bool Answer2Check
        {
            get
            {
                if (_selectedQuestion != null)
                {
                    return _selectedQuestion.CorrectAnswer == 2;
                }
                return false;
            }
            set
            {
                if(value == true && SelectedQuestion != null) 
                {
                   _selectedQuestion.SetCorrectAnswer(2);
                }
                
                SetProperty(ref answer2Check, value);

                OnPropertyChanged(nameof(Answer1Check));
                OnPropertyChanged(nameof(Answer0Check));
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
            }
        }
        

        private Question _selectedQuestion;
        public Question SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                SetProperty(ref _selectedQuestion, value);
                OnPropertyChanged(nameof(Answer0Check));
                OnPropertyChanged(nameof(Answer1Check));
                OnPropertyChanged(nameof(Answer2Check));
            }
        }

        public QuizManagerViewModel(NavigationManager navigationManager, DataModel dataModel)
        {
            _navigationManager = navigationManager;
            _dataModel = dataModel;
        }

        public ICommand AddQuizCommand => new RelayCommand(() => _dataModel.AddQuiz(new Quiz("New Quiz", null)));

        public ICommand RemoveQuizCommand => new RelayCommand(() => _dataModel.RemoveQuiz(SelectedQuiz));

        public ICommand AddQuestionCommand => new RelayCommand(() =>
        {
            if (SelectedQuiz != null) 
            {
                SelectedQuiz.AddQuestion(new Question("New Question", 1, "No Subject", new string[] { "Answer 1", "Answer 2", "Answer 3" }));
            }
        });
        public ICommand RemoveQuestionCommand => new RelayCommand(() =>
        {
            if(SelectedQuiz != null)
            {
                SelectedQuiz.RemoveQuestion(SelectedQuestion);
            }            
        });
        
        public ICommand ChoosePictureCommand => new RelayCommand(ChoosePicture);

        private readonly string imageFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuizImages\\");

        public void ChoosePicture()
        {
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image File (*.jpg)|*.jpg|All files (*.*)|*.*";
            if(fileDialog.ShowDialog() == true)
            {
                string imageDestination = imageFolder + "\\" + fileDialog.SafeFileName;
                if (!File.Exists(imageDestination))
                {
                    File.Copy(fileDialog.FileName, imageDestination);
                }
                _selectedQuestion.ImageUri = new Uri(imageDestination);
                OnPropertyChanged(nameof(SelectedQuestion));
            }
        }
        
        public ICommand MainMenuCommand => new RelayCommand(SaveAndMainMenu);
        public void SaveAndMainMenu()
        {
            _ = _dataModel.SaveQuizes();
            _navigationManager.SelectedViewModel = new MainMenuViewModel(_navigationManager, _dataModel);
        }
    }
}
