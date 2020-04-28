using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Divis.AsyncObservableCollection
{
    public class AsyncObservableCollection<T> : ObservableCollection<T>, IAsyncObservableCollection
    {
        private Action<Action> _dispatcher;

        public void Init(Action<Action> dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public new void Add(T item)
        {
            if (_dispatcher == null)
            {
                throw new Exception($"Dispatcher is null. Call {nameof(Init)} before using this");
            }

            _dispatcher?.Invoke(() => base.Add(item));
        }

        public new void Remove(T item)
        {
            if (_dispatcher == null)
            {
                throw new Exception($"Dispatcher is null. Call {nameof(Init)} before using this");
            }

            _dispatcher?.Invoke(() => base.Remove(item));
        }

        public new void Clear()
        {
            if (_dispatcher == null)
            {
                throw new Exception($"Dispatcher is null. Call {nameof(Init)} before using this");
            }

            _dispatcher?.Invoke(() => base.Clear());
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (_dispatcher == null)
            {
                throw new Exception($"Dispatcher is null. Call {nameof(Init)} before using this");
            }

            _dispatcher?.Invoke(() =>
            {
                foreach (var item in items)
                {
                    base.Add(item);
                }
            });
        }
    }
}
