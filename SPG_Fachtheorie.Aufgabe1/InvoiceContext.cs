using Microsoft.EntityFrameworkCore;
using SPG_Fachtheorie.Aufgabe1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG_Fachtheorie.Aufgabe1
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions opt) : base(opt) { }
        // TOTO: Füge die DbSet<T> Collections hinzu.
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Article>? Articles { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<InvoiceItem>? InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Füge - wenn notwendig - noch Konfigurationen hinzu.
           
             modelBuilder.Entity<Company>().HasKey(c => c.Guidkey);
            modelBuilder.Entity<Article>().HasKey(a => a.Artikelnummerkey);
            modelBuilder.Entity<Customer>().HasKey(c => c.Kundennummerkey);
            modelBuilder.Entity<Employee>().HasKey(e => e.Guidkey);
            modelBuilder.Entity<Invoice>().HasKey(i => i.Rechnungsnummerkey);
            modelBuilder.Entity<InvoiceItem>().HasKey(ii => ii.Invoicenumberkey);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Customer)
                .WithOne()
                .HasForeignKey(c => c.Kundennummerkey);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.Employee)
                .WithOne()
                .HasForeignKey(e => e.Guidkey);

            modelBuilder.Entity<InvoiceItem>()
                .HasMany(ii => ii.Articles)
                .WithOne()
                .HasForeignKey(a => a.Artikelnummerkey);

            modelBuilder.Entity<InvoiceItem>()
                .HasMany(ii => ii.Invoices)
                .WithOne()
                .HasForeignKey(i => i.Rechnungsnummerkey);

            base.OnModelCreating(modelBuilder);
        }

    }
}
