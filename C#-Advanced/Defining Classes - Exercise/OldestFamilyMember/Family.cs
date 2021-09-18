using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.Members = new List<Person>();
        }

        public Person Person { get; set; }  

        public List<Person> Members { get; set; }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person ReturnTheOldestMember()
        {
            var oldestMember = new Person();

            Members = Members.OrderByDescending(x => x.Age).ToList();

            return oldestMember = Members.FirstOrDefault();
        }
    }
}
