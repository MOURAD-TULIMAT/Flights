using flights.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace flights.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string appSchema = "dbo";

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<AirlineCompany> AirlineCompanies { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ETicket> ETickets { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                                    .SelectMany(t => t.GetForeignKeys())
                                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);

            builder.HasDefaultSchema(appSchema);

            builder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");
            });

            builder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountTypes");
            });

            builder.Entity<AirlineCompany>(entity =>
            {
                entity.ToTable("AirlineCompanies");
            });

            builder.Entity<Airplane>(entity =>
            {
                entity.ToTable("Airplanes");
            });

            builder.Entity<Airport>(entity =>
            {
                entity.ToTable("Airports");
            });
            builder.Entity<Booking>(entity =>
            {
                entity.ToTable("Bookings");
            });
            builder.Entity<City>(entity =>
            {
                entity.ToTable("Cities");
            });
            builder.Entity<ETicket>(entity =>
            {
                entity.ToTable("ETickets");
            });
            builder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flights");
            });
            builder.Entity<Passenger>(entity =>
            {
                entity.ToTable("Passengers");
            });
            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });
        }
    }
}
