using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreDemo.ModelBuilding
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Ignore(x => x.FullName);

            builder
                .Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
