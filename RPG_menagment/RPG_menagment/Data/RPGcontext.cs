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

        public DbSet<FightingCharacter> FightingCharacters { get; set; }
        public DbSet<LandscapeElement> LandscapeElements { get; set; }

        public DbSet<Dragon> Dragons { get; set; }
        public DbSet<Magician> Magicians { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Orc> Orcs { get; set; }

        public DbSet<Cave> Caves { get; set; }
        public DbSet<Tower> Towers { get; set; }
        public DbSet<River> Rivers { get; set; }
        public DbSet<Forest> Forests { get; set; }



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

