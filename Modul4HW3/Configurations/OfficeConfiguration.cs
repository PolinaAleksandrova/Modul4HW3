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
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.OfficeId);
            builder.Property(o => o.Title).HasMaxLength(100).IsRequired();
            builder.Property(o => o.Location).HasMaxLength(100).IsRequired();
        }
    }
}
