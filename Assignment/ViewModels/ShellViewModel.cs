using Assignment.Commands;
using Caliburn.Micro;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ICommand LoadersCommand { get; set; }
        public ICommand ToDoListCommand { get; set; }
        public ShellViewModel() 
        {
            Initialize();
        }

        private void Initialize()
        {
            LoadersCommand = new RelayCommand(ActivateLoadersView);
            ToDoListCommand = new RelayCommand(ActivateToDoList);
        }

        public void ActivateLoadersView(object obj)
        {
            ActiveItem = new LoadersViewModel();
        }

        public void ActivateToDoList(object obj)
        {
            ActiveItem = new ToDoListViewModel();
        }
    }
}
