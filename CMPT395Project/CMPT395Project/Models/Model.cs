using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

// ttps://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
namespace CMPT395Project.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<Contracts> Contract { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Employee_Hours> EmployeeHour { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public ICollection<Post> Posts { get; set; }
    }

    public class Employee_Hours
    {
        public int TimeSheetId { get; set; }
        public int ContractId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int CurrentMonth { get; set; }
        public int PreviousMonth { get; set; }

    }

    public class Admin
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }
    }

    public class Company
    {
        public int companyIds { get; set; }
        public string companyName { get; set; }
    }

    public class Contractor
    {
        public int contractorId { get; set; }
        public string contractorFirstName { get; set; }
        public string contractorLastName { get; set; }
        public int companyId { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }

    public class Contracts
    {
        public int contractId { get; set; }
        public int companyId { get; set; }
        public int contractorId { get; set; }

        public int p1CharRate { get; set; }
        public int p1PayRate { get; set; }
        public DateTime p1StartDate { get; set; }
        public DateTime p1EndtDate { get; set; }

        public int p2CharRate { get; set; }
        public int p2PayRate { get; set; }
        public DateTime p2StartDate { get; set; }
        public DateTime p2EndtDate { get; set; }

        public int p3CharRate { get; set; }
        public int p3PayRate { get; set; }
        public DateTime p3StartDate { get; set; }
        public DateTime p3EndtDate { get; set; }

        public int p4CharRate { get; set; }
        public int p4PayRate { get; set; }
        public DateTime p4StartDate { get; set; }
        public DateTime p4EndtDate { get; set; }

        public String renewal { get; set; }
        public Char activeContract { get; set; }
    }
}