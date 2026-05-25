using Assignment.Commands;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.ViewModels
{
    public class LoadersViewModel : ViewModelBase
    {
        public IList<ThreadWorker> Threads { get; private set; }

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
            var rng = new Random();
            Threads = new List<ThreadWorker>
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
        }
    }
}
