using Assignment.Models;
using System.Collections.ObjectModel;

namespace Assignment.ViewModels
{
    public class ToDoListViewModel
    {
        public ObservableCollection<ToDoItem> Items { get; private set; }
        public ToDoSubmitViewModel ToDoSubmitViewModel { get; set; }

        public ToDoListViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            Items = new ObservableCollection<ToDoItem>();
            ToDoSubmitViewModel = new ToDoSubmitViewModel(this);
        }
        public void AddItem(ToDoItem item)
        {
            int insertIndex = Items.Count;

            if (item.Priority == 1)
            {
                insertIndex = 0;
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Priority == 1)
                        insertIndex = i + 1;
                }
            }
            else if (item.Priority == 2)
            {
                insertIndex = 0;
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Priority == 1 || Items[i].Priority == 2)
                        insertIndex = i + 1;
                }
            }

            Items.Insert(insertIndex, item);
        }
    }
}
