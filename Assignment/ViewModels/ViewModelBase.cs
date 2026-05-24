using Caliburn.Micro;

namespace Assignment.ViewModels
{
    public class ViewModelBase : Screen
    {
        protected void OnPropertyChanged(string propertyName)
        {
            NotifyOfPropertyChange(propertyName);
        }
    }
}
