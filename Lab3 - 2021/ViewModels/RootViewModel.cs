using Lab3___2021.Managers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___2021.ViewModels
{
    class RootViewModel : ObservableObject
    {

        private readonly NavigationManager _navigationManager;
        private readonly DataManager _dataManager;

        public ObservableObject SelectedViewModel => _navigationManager.SelectedViewModel;

        public RootViewModel(NavigationManager navigationManager, DataManager dataManager)
        {
            _navigationManager = navigationManager;
            _dataManager = dataManager;

            _navigationManager.SelectedViewModelChanged += SelectedViewModelChanged;

        }

        private void SelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
        

    }
}
