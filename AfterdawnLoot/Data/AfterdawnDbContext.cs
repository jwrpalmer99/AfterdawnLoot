using Microsoft.EntityFrameworkCore;
using AfterdawnLoot;

namespace AfterdawnLoot.Data
{
    public class AfterdawnDbContext : DbContext
    {
        public DbContextOptions<AfterdawnDbContext> myoptions;

        public AfterdawnDbContext(DbContextOptions<AfterdawnDbContext> options) : base(options)
        {
            myoptions = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./database/afterdawn.db3", opts => opts.CommandTimeout(5));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerCharacters>()
                .HasKey(c => new { c.UserID, c.Name });

            modelBuilder.Entity<Characters>()
                .HasKey(c => new { c.Name});

            modelBuilder.Entity<Raids>()
                .Property(e => e.ID)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<CharacterLoot>()
            //    .HasKey(c => new { c.Character, c.RaidID, c.Item });

            modelBuilder.Entity<CharacterLoot>()
                .Property(e => e.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PointsAdjustment>()
                .HasKey(c => new { c.CharacterName, c.TimeStamp });
        }

        public DbSet<Players> Players { get; set; }
        public DbSet<Characters> Characters { get; set; }
        public DbSet<PlayerCharacters> PlayerCharacters { get; set; }

        public DbSet<Attendance> Attendance { get; set; }

        public DbSet<Raids> Raids { get; set; }

        public DbSet<LootResults> LootResults { get; set; }
        public DbSet<CharacterLoot> CharacterLoot { get; set; }

        public DbSet<PointsAdjustment> PointsAdjustment { get; set; }

    }
}