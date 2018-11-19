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
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class EmployeeHour
    {
        [Key]
        [Display(Name = "Time Sheet ID")]
        public int TimeSheetId { get; set; }

        [Display(Name = "Contractor ID")]
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        [Display(Name = "Current Month")]
        public int CurrentMonth { get; set; }

        [Display(Name = "Previous Month")]
        public int PreviousMonth { get; set; }
        
    }

    public class Admin
    {
        [Key]
        [Display(Name = "Administrator ID")]
        public int AdminId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    public class Company
    {
        [Key]
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public ICollection<Contractor> Contractors { set; get; }
        public ICollection<Contract> Contracts { set; get; }
    }

    public class Contractor
    {
        [Key]
        [Display(Name = "Contractor ID")]
        public int ContractorId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company ID ID")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Contract> Contracts { get; set; }
    }

    public class Contract
    {
        [Key]
        [Display(Name = "Contract ID")]
        public int ContractId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Period One Charge Rate")]
        public int P1CharRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Peroid One Pay Rate")]
        public int P1PayRate { get; set; }

        [Display(Name = "Period One Start Date")]
        public DateTime P1StartDate { get; set; }

        [Display(Name = "Perioid One End Date")]
        public DateTime P1EndtDate { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Period Two Charge Rate")]
        public int P2CharRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Peroid Two Pay Rate")]
        public int P2PayRate { get; set; }

        [Display(Name = "Period Two Start Date")]
        public DateTime P2StartDate { get; set; }

        [Display(Name = "Perioid Two End Date")]
        public DateTime P2EndtDate { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Period Three Charge Rate")]
        public int P3CharRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Peroid Three Pay Rate")]
        public int P3PayRate { get; set; }

        [Display(Name = "Period Three Start Date")]
        public DateTime P3StartDate { get; set; }

        [Display(Name = "Perioid Three End Date")]
        public DateTime P3EndtDate { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Period Four Charge Rate")]
        public int P4CharRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Peroid Four Pay Rate")]
        public int P4PayRate { get; set; }

        [Display(Name = "Period Four Start Date")]
        public DateTime P4StartDate { get; set; }

        [Display(Name = "Perioid Four End Date")]
        public DateTime P4EndtDate { get; set; }

        public String Renewal { get; set; }

        [Display(Name = "Active Contract")]
        public Char ActiveContract { get; set; }

        public ICollection<EmployeeHour> EmployeeHours { get; set; }


        [ForeignKey("ContractorId")]
        [Display(Name = "Contractor ID")]
        public int? ContractorId { get; set; }
        public Contractor Contractor { set; get; }


        [ForeignKey("CompanyId")]
        [Display(Name = "Company ID")]
        public int? CompanyId { get; set; }
        public Company Company { set; get; }
    }
}