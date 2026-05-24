using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.ViewModels
{
    public class ToDoListViewModel
    {
        public ToDoSubmitViewModel ToDoSubmitViewModel { get; set; }

        public ToDoListViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            ToDoSubmitViewModel = new ToDoSubmitViewModel();
        }
    }
}
