using Lab3___2021.Managers;
using Lab3___2021.Models;
using Lab3___2021.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3___2021
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly NavigationManager _navigationManager;
        private readonly DataManager _dataManager;

        public App()
        {
            _navigationManager = new NavigationManager();
            _dataManager = new DataManager();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            //var quizes = new ObservableCollection<Quiz>();
            //Quiz testQuiz = new Quiz("Test Quiz");
            //testQuiz.AddQuestion("Test Statement", 2, "Test Subject", new string[] { "Answer 1", "Answer 2", "Answer 3" });

            //quizes.Add(testQuiz);

            //var model = new QuizManagerModel(quizes);
            //var quizesPresenter = new QuizManagerViewModel(model);
            //var quizManagerWindow = new MainWindow { DataContext = quizesPresenter };


            //quizManagerWindow.Show();

            //base.OnStartup(e);

            _navigationManager.SelectedViewModel = new MainMenuViewModel(_navigationManager, _dataManager.DataModel);
            var mainWindow = new MainWindow { DataContext = new RootViewModel(_navigationManager, _dataManager)};
            mainWindow.Show();
            base.OnStartup(e);

        }
    }
}
