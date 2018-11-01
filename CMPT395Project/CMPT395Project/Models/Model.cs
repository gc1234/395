using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<EmployeeHour> EmployeeHour { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeHour>()
                .HasOne(h => h.Contract)
                .WithMany(c => c.EmployeeHours)
                .HasForeignKey(h => h.ContractId)
                .HasConstraintName("ForeignKey_EmployeeHours_Contract");

            modelBuilder.Entity<Contractor>()
                .HasOne(cnt => cnt.Company)
                .WithMany(cmp => cmp.Contractors)
                .HasForeignKey(cnt => cnt.CompanyId)
                .HasConstraintName("ForeignKey_Contractor_Company");

            modelBuilder
                .Entity<Contract>()
                .HasOne(x => x.Company)
                .WithMany(y => y.Contracts);

            modelBuilder
                .Entity<Contract>()
                .HasOne(x => x.Contractor)
                .WithMany(y => y.Contracts);
        }
    }

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class EmployeeHour
    {
        [Key]
        public int TimeSheetId { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
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
        public ICollection<Contractor> Contractors { set; get; }
        public ICollection<Contract> Contracts { set; get; }
    }

    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }

    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
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

        public ICollection<EmployeeHour> EmployeeHours { get; set; }


        [ForeignKey("ContractorId")]
        public int? ContractorId { get; set; }
        public Contractor Contractor { set; get; }


        [ForeignKey("CompanyId")]
        public int? CompanyId { get; set; }
        public Company Company { set; get; }
    }
}