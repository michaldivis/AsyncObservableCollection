using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncObservableCollectionTest.Lib
{
    public interface IAsyncObservableCollection
    {
        void Init(Action<Action> dispatcher);
    }
}
