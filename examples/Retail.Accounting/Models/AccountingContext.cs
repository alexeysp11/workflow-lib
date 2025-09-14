using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VelocipedeUtils.Examples.Retail.Accounting.Models
{
    public class AccountingContext : DbContext
    {
        public DbSet<ExportDoc> ExportDocs { get; set; }
        public DbSet<ExportItem> ExportItems { get; set; }

        public DbSet<ImportDoc> ImportDocs { get; set; }
        public DbSet<ImportItem> ImportItems { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Partner> Partner { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Department> Department { get; set; }

        public string DbPath { get; private set; }

        public AccountingContext()
        {
            DbPath = "C:\\Users\\User\\Desktop\\projects\\Retail-Accounting-WebApp\\DB\\accounting.db";
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportDoc>()
                .HasOne(id => id.Employee)
                .WithMany(e => e.ImportDocs)
                .HasForeignKey(id => id.EmployeeId);

            modelBuilder.Entity<ImportDoc>()
                .HasOne(id => id.Supplier)
                .WithMany(s => s.ImportDocs)
                .HasForeignKey(id => id.SupplierId);

            modelBuilder.Entity<ImportItem>()
                .HasOne(ii => ii.Product)
                .WithMany(p => p.ImportItems)
                .HasForeignKey(ii => ii.ProductId);

            modelBuilder.Entity<ImportItem>()
                .HasOne(ii => ii.ImportDoc)
                .WithMany(id => id.ImportItems)
                .HasForeignKey(id => id.ImportDocId);

            modelBuilder.Entity<ExportDoc>()
                .HasOne(ed => ed.Employee)
                .WithMany(e => e.ExportDocs)
                .HasForeignKey(ed => ed.EmployeeId);

            modelBuilder.Entity<ExportDoc>()
                .HasOne(ed => ed.Purchaser)
                .WithMany(p => p.ExportDocs)
                .HasForeignKey(ed => ed.PurchaserId);

            modelBuilder.Entity<ExportItem>()
                .HasOne(ei => ei.Product)
                .WithMany(p => p.ExportItems)
                .HasForeignKey(ei => ei.ProductId);

            modelBuilder.Entity<ExportItem>()
                .HasOne(ei => ei.ExportDoc)
                .WithMany(ed => ed.ExportItems)
                .HasForeignKey(ed => ed.ExportDocId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)
                .WithMany(m => m.Employees)
                .HasForeignKey(e => e.ManagerId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.Contracts)
                .HasForeignKey(c => c.EmployeeId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}