namespace TestTask.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using TestTask.Domain.Entities;
    using TestTask.Repositories.Data;

    public class StoreEntities : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreEntities"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public StoreEntities(DbContextOptions<StoreEntities> options) : base(options)
        {
        }

        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<ProvinceEntity> Provinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountEntity>()
                .HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountEntity>()
                .HasOne(a => a.Province)
                .WithMany()
                .HasForeignKey(a => a.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CountryEntity>().HasData(CountryData.Value);
            modelBuilder.Entity<ProvinceEntity>().HasData(ProvinceData.Value);
        }
    }
}
