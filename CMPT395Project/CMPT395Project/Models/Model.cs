using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public ICollection<Post> Posts { get; set; }
    }

    public class Employee_Hours
    {
        [Key]
        public int TimeSheetId { get; set; }
        [ForeignKey("Contracts")]
        public int ContractId { get; set; }
        public virtual Contracts Contracts { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int CurrentMonth { get; set; }
        public int PreviousMonth { get; set; }

    }

    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { set; get; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class Contracts
    {
        [Key]
        public int ContractId { get; set; }
        [ForeignKey("Contractor")]
        public int ContractorId { get; set; }
        public virtual Contractor Contractor { set; get; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int P1CharRate { get; set; }
        public int P1PayRate { get; set; }
        public DateTime P1StartDate { get; set; }
        public DateTime P1EndtDate { get; set; }

        public int P2CharRate { get; set; }
        public int P2PayRate { get; set; }
        public DateTime P2StartDate { get; set; }
        public DateTime P2EndtDate { get; set; }

        public int P3CharRate { get; set; }
        public int P3PayRate { get; set; }
        public DateTime P3StartDate { get; set; }
        public DateTime P3EndtDate { get; set; }

        public int P4CharRate { get; set; }
        public int P4PayRate { get; set; }
        public DateTime P4StartDate { get; set; }
        public DateTime P4EndtDate { get; set; }

        public String Renewal { get; set; }
        public Char ActiveContract { get; set; }
    }
}