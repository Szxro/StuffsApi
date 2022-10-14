using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AutoInclude
            modelBuilder.Entity<Comic>().Navigation(x => x.Teams).AutoInclude();
            modelBuilder.Entity<Team>().Navigation(x => x.SuperHeroes).AutoInclude();
            //Inserting Data
            modelBuilder.Entity<Comic>().HasData(
               new Comic { Id = 1, Name = "Marvel" },
               new Comic { Id = 2, Name = "DC" });

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Avengers", ComicId = 1 },
                new Team { Id = 2, Name = "Justice League", ComicId = 2 });

            modelBuilder.Entity<SuperHeroe>().HasData(
                new SuperHeroe { Id = 1, Name = "Spiderman", TeamId = 1 },
                new SuperHeroe { Id = 2, Name = "Iron Man", TeamId = 1 },
                new SuperHeroe { Id = 3, Name = "Batman", TeamId = 2 },
                new SuperHeroe { Id = 4, Name = "Wonder Woman", TeamId = 2 });

            //Relations
            modelBuilder.Entity<Team>().HasOne(x => x.Comic).WithMany(x => x.Teams).HasForeignKey(x => x.ComicId);
            modelBuilder.Entity<SuperHeroe>().HasOne(x => x.Teams).WithMany(x => x.SuperHeroes).HasForeignKey(x => x.TeamId);
        }

        public DbSet<Comic>? Comic { get; set; }

        public DbSet<SuperHeroe>? SuperHeroes { get; set; }

        public DbSet<Team>? Teams { get; set; }
    }
}