using Assignment.Commands;
using System.Collections.Generic;
using Assignment.Models;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class ToDoSubmitViewModel : ViewModelBase
    {
        private string _itemName { get; set; }
        private int _selectedPriority { get; set; }
        public string ItemName
        {
            get => _itemName;
            set
            {
                _itemName = value;
                OnPropertyChanged("ItemName");
            }
        }
        public int SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged("SelectedPriority");
            }
        }

        public List<int> Priorities { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        private readonly ToDoListViewModel _toDoListViewModel;
        public ToDoSubmitViewModel(ToDoListViewModel toDoListViewModel) 
        {
            _toDoListViewModel = toDoListViewModel;
            Initialize();
        }

        private void Initialize()
        {
            SubmitCommand = new RelayCommand(SubmitItem);
            Priorities = new List<int> { 1, 2, 3};
        }

        private void SubmitItem(object obj)
        {
            if (string.IsNullOrWhiteSpace(ItemName)) return;

            var item = new ToDoItem
            {
                Name = ItemName,
                Priority = SelectedPriority
            };

            _toDoListViewModel.AddItem(item);
            ItemName = string.Empty;
            SelectedPriority = 0;
        }
    }
}
