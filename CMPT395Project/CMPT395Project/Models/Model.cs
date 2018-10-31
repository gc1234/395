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
                .HasConstraintName("ForeignKey_EmployeeHours_Contractor");

            modelBuilder.Entity<Contractor>()
                .HasOne(cnt => cnt.Company)
                .WithMany(cmp => cmp.Contractors)
                .HasForeignKey(cnt => cnt.CompanyId)
                .HasConstraintName("ForeignKey_Contractor_Company");

            modelBuilder.Entity<Contract>()
                .HasOne(cnt => cnt.Company)
                .WithMany(cmp => cmp.Contracts)
                .HasForeignKey(cnt => cnt.CompanyId)
                .HasConstraintName("ForeignKey_Contract_Company");

            modelBuilder.Entity<Contract>()
                .HasOne(cnt => cnt.Contractor)
                .WithMany(cmp => cmp.Contracts)
                .HasForeignKey(cnt => cnt.ContractorId)
                .HasConstraintName("ForeignKey_Contract_Contractor");

            /*modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasDefaultValue(null);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .HasDefaultValue(null);*/
        }
    }

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [DefaultValue(null)]
        public string FirstName { get; set; }
        [DefaultValue(null)]
        public string LastName { get; set; }
        [DefaultValue(null)]
        public string Email { get; set; }

        //public ICollection<Post> Posts { get; set; }
    }

    public class EmployeeHour
    {
        [Key]
        public int TimeSheetId { get; set; }
        public int ContractId { get; set; }
        [DefaultValue(null)]
        public int Year { get; set; }
        [DefaultValue(null)]
        public int Month { get; set; }
        [DefaultValue(null)]
        public int CurrentMonth { get; set; }
        [DefaultValue(null)]
        public int PreviousMonth { get; set; }
        public Contract Contract { get; set; }

    }

    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [DefaultValue(null)]
        public string FirstName { get; set; }
        [DefaultValue(null)]
        public string LastName { get; set; }
        [DefaultValue(null)]
        public string Password { get; set; }
    }

    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [DefaultValue(null)]
        public string CompanyName { get; set; }
        public List<Contractor> Contractors { set; get; }
        public List<Contract> Contracts { set; get; }
    }

    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
        [DefaultValue(null)]
        public string FirstName { get; set; }
        [DefaultValue(null)]
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        [DefaultValue(null)]
        public string Email { get; set; }
        [DefaultValue(null)]
        public string Password { get; set; }
        public Company Company { get; set; }
        public Contract Contracs { get; set; }
        public List<Contract> Contracts { get; set; }

    }

    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public int ContractorId { get; set; }
        public int CompanyId { get; set; }
        [DefaultValue(0)]
        public int P1CharRate { get; set; }
        [DefaultValue(0)]
        public int P1PayRate { get; set; }
        [DefaultValue(0)]
        public DateTime P1StartDate { get; set; }
        [DefaultValue(0)]
        public DateTime P1EndtDate { get; set; }

        [DefaultValue(0)]
        public int P2CharRate { get; set; }
        [DefaultValue(0)]
        public int P2PayRate { get; set; }
        [DefaultValue(0)]
        public DateTime P2StartDate { get; set; }
        [DefaultValue(0)]
        public DateTime P2EndtDate { get; set; }

        [DefaultValue(0)]
        public int P3CharRate { get; set; }
        [DefaultValue(0)]
        public int P3PayRate { get; set; }
        [DefaultValue(0)]
        public DateTime P3StartDate { get; set; }
        [DefaultValue(0)]
        public DateTime P3EndtDate { get; set; }

        [DefaultValue(0)]
        public int P4CharRate { get; set; }
        [DefaultValue(0)]
        public int P4PayRate { get; set; }
        [DefaultValue(0)]
        public DateTime P4StartDate { get; set; }
        [DefaultValue(0)]
        public DateTime P4EndtDate { get; set; }

        [DefaultValue(0)]
        public String Renewal { get; set; }
        [DefaultValue(null)]
        public Char ActiveContract { get; set; }

        public List<EmployeeHour> EmployeeHours { get; set; }

        public Contractor Contractor { set; get; }
        public Company Company { set; get; }
    }
}