using DrunkenWizard_API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrunkenWizard_API.Repos
{
    public class Repository : DbContext
    {

        public Repository()
        {



        }

        public Repository(DbContextOptions<Repository> options) : base(options)
        {

        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameClass> GameClass { get; set; }
        public virtual DbSet<Spell> Spell { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
             optionsBuilder.UseSqlServer(@"Server=tcp:lbalp.database.windows.net,1433;Initial Catalog=drunkenwizard;Persist Security Info=False;User ID=af;Password=Theninja112;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            if (optionsBuilder.IsConfigured == false)
            {
              }
           
          }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         //   modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");



        }

    }
}
