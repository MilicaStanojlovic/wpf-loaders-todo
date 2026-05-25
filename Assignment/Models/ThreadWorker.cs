using System.ComponentModel;

namespace Assignment.Models
{
    public class ThreadWorker : INotifyPropertyChanged
    {
        private int _elapsed;

        public int Duration { get; set; }

        public int Elapsed
        {
            get => _elapsed;
            set
            {
                _elapsed = value;
                OnPropertyChanged(nameof(Elapsed));
                OnPropertyChanged(nameof(Progress));
            }
        }
        public double Progress
        {
            get => Duration > 0 ? (double)Elapsed / Duration * 100.0 : 0;
            private set { }
        }

       
        public bool IsActive { get; private set; } = true;

        public void Cancel()
        {
            IsActive = false;
            OnPropertyChanged(nameof(IsActive));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
