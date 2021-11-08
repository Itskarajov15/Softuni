using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    public interface IListCollection<T>
    {
        public List<T> Collection { get; set; }
    }
}
