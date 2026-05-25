using Assignment.Commands;
using System.Windows.Input;
using System.Windows.Threading;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assignment.ViewModels
{
    public class LoadersViewModel : ViewModelBase
    {
        public ObservableCollection<ThreadWorker> Threads { get; set; }
        private DispatcherTimer _timer;
        public ICommand CancelCommand { get; set; }

        public double TotalProgress
        {
            get
            {
                var active = Threads.Where(t => t.IsActive).ToList();
                if (!active.Any()) return 0.0;
                return active.Average(t => t.Progress);
            }
        }

        public LoadersViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            CancelCommand = new RelayCommand(obj =>
            {
                int index = int.Parse(obj.ToString());
                Threads[index].Cancel();
            });

            var rng = new Random();
            Threads = new ObservableCollection<ThreadWorker>
            {
                new ThreadWorker { Duration = rng.Next(10, 51) },
                new ThreadWorker { Duration = rng.Next(10, 51) },
                new ThreadWorker { Duration = rng.Next(10, 51) }
            };

            foreach (var thread in Threads)
            {
                thread.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(ThreadWorker.Progress) ||
                        e.PropertyName == nameof(ThreadWorker.IsActive))
                    {
                        OnPropertyChanged(nameof(TotalProgress));
                    }
                };
            }

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += OnTick;
            _timer.Start();

        }
        private void OnTick(object sender, EventArgs e)
        {
            bool anyActive = false;
            foreach (var thread in Threads)
            {
                if (!thread.IsActive) continue;
                anyActive = true;
                thread.Elapsed = Math.Min(thread.Elapsed + 1, thread.Duration);
                if (thread.Elapsed >= thread.Duration)
                    thread.Cancel();
            }
            if (!anyActive) _timer.Stop();
        }
    }
}
