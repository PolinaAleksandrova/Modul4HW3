using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modul4HW3.Models;

namespace Modul4HW3.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.OfficeId).IsRequired();
            builder.Property(e => e.TitleId).IsRequired();
            builder.Property(e => e.HiredDate).HasMaxLength(7).IsRequired();

            builder.HasOne(e => e.Title)
                .WithMany(t => t.Employees)
                .HasForeignKey(f => f.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
