using System;
using System.Collections.Generic;
using System.Text;

namespace Divis.AsyncObservableCollection
{
    public interface IAsyncObservableCollection
    {
        void Init(Action<Action> dispatcher);
    }
}
