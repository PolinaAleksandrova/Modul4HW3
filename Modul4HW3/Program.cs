﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankSolution.DataAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appContextFactory = new AppContextFactory();

            using (var appContext = appContextFactory.CreateDbContext(args))
            {
                var leftJoin = (from o in appContext.Offices
                                join e in appContext.Employees on o.Id equals e.OfficeId into officesEmployes
                                from oe in officesEmployes.DefaultIfEmpty()
                                select new { Id = o.Id, OfficeLocation = o.Location, EmployeeName = oe.FirstName, TitleId = oe.TitleId })
                                .Join(
                    bankContext.Titles,
                    oe => oe.TitleId,
                    t => t.Id,
                    (oe, t) => new { Id = oe.Id, OfficeLocation = oe.OfficeLocation, EmployeeName = oe.EmployeeName, TitleName = t.Name })
                                .ToList();

                var dateDifference = appContext.Employees.Select(e => DateTime.UtcNow - e.HiredDate);

                var employees = appContext.Employees.ToList();
                employees[0].FirstName = "FirstName1";
                employees[1].LastName = "LastName1";
                bankContext.Employees.Update(employees[0]);
                bankContext.Employees.Update(employees[1]);
                var newEmployee = new Employee() { FirstName = "FirstName2", LastName = "LastName2", HiredDate = new DateTime(2019, 7, 5), OfficeId = 1, TitleId = 3 };
                var newProject = new Project() { Name = "Name1", Budget = 6000000, StartedDate = DateTime.UtcNow, ClientId = 1 };
                appContext.Employees.Add(newEmployee);
                appContext.Projects.Add(newProject);
                appContext.Employees.Remove(employees[1]);
                var title = appContext.Employees.ToList().GroupBy(e => e.Title.Name).Select(x => x.Key).FirstOrDefault(y => !y.Contains('a'));
                bankContext.SaveChanges();
            }
    }
}
