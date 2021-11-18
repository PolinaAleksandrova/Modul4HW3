using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankSolution.DataAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("DataModel");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(20));
            dbOptionsBuilder.LogTo(System.Console.Write);
            var appContext = new AppContext(dbOptionsBuilder.Options);
            appContext.Database.Migrate();
            appContext.SaveChanges();
        }
    }
}
