using EfCoreDemo.Models;
using System;

namespace EfCoreDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            for (int i = 0; i < 10; i++)
            {
                db.Employees.Add(new Employee
                {
                    FirstName = "Asen_" + i,
                    LastName = "Karadzhov_" + i,
                    StartWorkDate = new DateTime(2010 + i, 1, 1),
                    Salary = 100 + i
                });
            }

            db.SaveChanges();
        }
    }
}
