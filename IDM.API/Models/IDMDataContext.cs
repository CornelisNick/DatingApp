using System;
using System.Text;
using IDM.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IDM.API.Models
{
    public class IDMDataContext: DbContext
    {
        public IDMDataContext(DbContextOptions<IDMDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Username).IsUnique();

            modelBuilder.Entity<Provider>()
                .HasIndex(b => b.ProviderName).IsUnique();

            modelBuilder.Entity<Issuer>()
                .HasIndex(b => b.IssuerName).IsUnique();

            var providerId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Provider>().HasData(new Provider() { Id = providerId, ProviderName = "Platform", Params = "No parms" });

            var platformIssuerId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Issuer>().HasData(new Issuer() { Id = platformIssuerId, IssuerName = "Platform issuer", ProviderId = providerId, PrivateKey = "My private key" });

            var resellerIssuerId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Issuer>().HasData(new Issuer() { Id = resellerIssuerId, IssuerName = "Reseller issuer", ProviderId = providerId, PrivateKey = "My private key" });

            var userId = Guid.NewGuid().ToString();

            byte[] passwordHash, passwordSalt;

            Hashing.CreatePasswordHash("password",out passwordHash,out passwordSalt); 

            modelBuilder.Entity<User>().HasData(new User() { Id = userId, IssuerId = platformIssuerId, Username = "admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
            
            userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<User>().HasData(new User() { Id = userId, IssuerId = resellerIssuerId, Username = "reseller_admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
        
            userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<User>().HasData(new User() { Id = userId, IssuerId = platformIssuerId, Username = "user1", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
        
            userId = Guid.NewGuid().ToString();

            modelBuilder.Entity<User>().HasData(new User() { Id = userId, IssuerId = resellerIssuerId, Username = "reseller_user1", PasswordHash = passwordHash, PasswordSalt = passwordSalt });
    
        }

        public DbSet<Issuer> Issuers { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<User> Users { get; set; }
        
    }
}