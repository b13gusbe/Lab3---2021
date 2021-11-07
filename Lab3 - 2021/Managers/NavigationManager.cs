using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3___2021.Managers
{
    class NavigationManager
    {
        private ObservableObject _selectedViewModel;

        public ObservableObject SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnSelectedViewModelChanged();
            }
        }

        public event Action SelectedViewModelChanged;

        private void OnSelectedViewModelChanged()
        {
            SelectedViewModelChanged?.Invoke();
        }


    }
}
