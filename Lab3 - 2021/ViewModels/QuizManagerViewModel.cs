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

namespace Lab3___2021.ViewModels
{
    public class QuizManagerViewModel : ObservableObject
    {
        private readonly QuizManagerModel _model;

        public ObservableCollection<Quiz> Quizes => _model._quizes;
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


        //public string Title
        //{
        //    //get { return _selectedQuiz.Title; }
        //    get
        //    {
        //        if(_selectedQuiz == null)
        //        {
        //            return null;
        //        }
        //        return _selectedQuiz.Title;
        //    }
        //    set 
        //    {
        //        SetProperty(_selectedQuiz.Title, value, _selectedQuiz, (quiz, value) => quiz.Title = value);
        //    }
        //}



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
        // Om jag vill förändra ett värde så vill jag anropa SetProperty
        // Om något påverkar en annan property så måste man använda OnPropertyChanged för att uppdatera

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

        private readonly string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "hejsevejs\\Test.txt");


        public QuizManagerViewModel(QuizManagerModel model)
        {
            _model = model;
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                _model._quizes = JsonSerializer.Deserialize<ObservableCollection<Quiz>>(jsonString);

            }
           
            //SelectedQuiz = Quizes[0];
        }

        public ICommand AddQuizCommand => new RelayCommand(() => _model.AddQuiz(new Quiz("New Quiz")));

        public ICommand RemoveQuizCommand => new RelayCommand(() => _model.RemoveQuiz(SelectedQuiz));

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

        public void ChoosePicture()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
        }

        public ICommand SaveQuizesCommand => new RelayCommand(() => _model.SaveQuizes());


    }
}
