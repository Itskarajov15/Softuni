using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Implementations
{
    public class AddCollection : IAddableCollection, IListCollection<string>
    {
        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; set; }

        public virtual int Add(string element)
        {
            var index = this.Collection.Count;

            this.Collection.Add(element);

            return index;
        }
    }
}
