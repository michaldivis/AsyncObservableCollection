using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Divis.AsyncObservableCollection;
using Logic.Models;
using Logic.Mvvm;

namespace Logic
{
    public class MainViewModel : BindableObject
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public AsyncObservableCollection<Minion> Minions { get; set; } = new AsyncObservableCollection<Minion>();

        public async Task LoadMinionsOneByOneAsync()
        {
            var task = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                foreach (var minion in Constants.Minions)
                {
                    Minions.Add(minion);
                    Task.Delay(300).Wait();
                }

            });

            await RunWhenNotBusy(task);
        }

        public async Task LoadMinionsAtOnceAsync()
        {
            var task = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                Minions.AddRange(Constants.Minions);
            });

            await RunWhenNotBusy(task);
        }

        private void RunWhenNotBusy(Action stuff)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            stuff?.Invoke();

            IsBusy = false;
        }

        private async Task RunWhenNotBusy(Task stuff)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            await stuff;

            IsBusy = false;
        }
    }
}
