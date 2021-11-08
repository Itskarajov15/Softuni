using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Implementations
{
    public class MyList : AddRemoveCollection, ICountableCollection
    {
        public int Count => this.Collection.Count;

        public override string Remove()
        {
            var elementToRemove = this.Collection[0];

            this.Collection.RemoveAt(0);

            return elementToRemove;
        }
    }
}
