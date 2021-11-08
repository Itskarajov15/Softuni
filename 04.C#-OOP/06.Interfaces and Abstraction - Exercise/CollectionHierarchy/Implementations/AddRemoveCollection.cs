using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Implementations
{
    public class AddRemoveCollection : AddCollection, IRemovableCollection
    {
        public override int Add(string element)
        {
            this.Collection.Insert(0, element);

            return 0;
        }

        public virtual string Remove()
        {
            var elementToRemove = this.Collection[this.Collection.Count - 1];

            this.Collection.RemoveAt(this.Collection.Count - 1);

            return elementToRemove;
        }
    }
}
