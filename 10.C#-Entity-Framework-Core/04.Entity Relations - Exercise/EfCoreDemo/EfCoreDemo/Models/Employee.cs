using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public DateTime? StartWorkDate { get; set; }

        public decimal Salary { get; set; }
    }
}
