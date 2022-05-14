using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPG_menagment.Data.Model.RPGmodel;

namespace RPG_menagment.Data
{
    internal class RPGcontext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public RPGcontext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=
                (localdb)\MSSQLLocalDB;Integrated Security=True;
                Database = RPGdatabase;");
            }
        }
    }
}

