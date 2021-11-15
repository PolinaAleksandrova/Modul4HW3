using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSolution.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Modul4HW3
{
    public class AppContextFactory : IDesignTimeDbContextFactory<BankSolution.DataAccess.AppContext>
    {
        public BankSolution.DataAccess.AppContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<BankSolution.DataAccess.AppContext>();
            var connectionString = configuration.GetConnectionString("DataModel");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(20));

            return new BankSolution.DataAccess.AppContext(dbOptionsBuilder.Options);
        }
    }
}
