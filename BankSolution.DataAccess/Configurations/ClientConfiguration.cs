using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSolution.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSolution.DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Company).IsRequired();
            builder.Property(c => c.Location).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired();

            builder.HasData(new List<Client>()
            {
                new Client() {ClientId = 1, FirstName = "Phillip", LastName = "Freeman", Company = "Company1", Location = "8202 Silver Impasse, Singing Springs, Illinois, US" },
                new Client() { ClientId = 2, FirstName = "Jayson", LastName = "Henderson", Company = "Company2", Location = "8065 Jagged Beacon Gate, Corfu, Georgia, US" },
                new Client() { ClientId = 3, FirstName = "David", LastName = "Sanders", Company = "Company3", Location = "9706 Cozy Highlands, Friday Harbor, Tennessee, US" },
                new Client() { ClientId = 4, FirstName = "Piers", LastName = "Williams", Company = "Company4", Location = "2147 Broad Embers Inlet, Wild Horse, Tennessee, US" },
                new Client() { ClientId = 5, FirstName = "Steven", LastName = "Robertson", Company = "Company5", Location = "1229 Noble Parkway, Opposition, Louisiana, US" },
            });
        }
    }
}
