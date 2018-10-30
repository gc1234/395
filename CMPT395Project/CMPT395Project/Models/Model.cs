using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// ttps://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio
namespace CMPT395Project.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employee { get; set; }
        //public DbSet<Company> Company { get; set; }
        //public DbSet<Contractor> Contractor { get; set; }
       //public DbSet<Contract> Contract { get; set; }
        //public DbSet<Admin> Admin { get; set; }
        //public DbSet<Employee_Hours> EmployeeHour { get; set; }
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
}