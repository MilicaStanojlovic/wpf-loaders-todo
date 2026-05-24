using Assignment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

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

        public ToDoSubmitViewModel() 
        {
            Initialize();
        }

        private void Initialize()
        {
            SubmitCommand = new RelayCommand(SubmitItem);
            Priorities = new List<int> { 1, 2, 3};
        }

        private void SubmitItem(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
