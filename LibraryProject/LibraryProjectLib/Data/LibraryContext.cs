using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryProjectLib.Data.Models.LibraryModels;

namespace LibraryProjectLib.Data
{
    internal class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LibraryContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=
                (localdb)\MSSQLLocalDB;Integrated Security=True;
                Database = LibraryDatabase;");
            }
        }

    }
}
