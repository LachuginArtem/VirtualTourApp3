using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualTourApp2.Data.Models;

namespace VirtualTourApp2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public virtual DbSet<Guide> Guides { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Tour> Tours { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Tour>()
                    .HasOne(t => t.Guide)
                    .WithMany()
                    .HasForeignKey(t => t.GuideId);

            modelBuilder.Entity<Place>()  .HasOne(p => p.Tour)    
                  .WithMany(t => t.Places)
                  .HasForeignKey(p => p.TourId);

            modelBuilder.Entity<Review>()     
                    .HasOne(r => r.Tour)     
                    .WithMany(t => t.Reviews)
                    .HasForeignKey(r => r.TourId);

            base.OnModelCreating(modelBuilder);

            // Add initial data for Guides
            modelBuilder.Entity<Guide>().HasData(
                new Guide { GuideId = 1, Name = "Vladimir", ContactInfo = "vladimir@example.com" },
                new Guide { GuideId = 2, Name = "Elena", ContactInfo = "elena@example.com" }
            );

            //Add initial data for Place
            modelBuilder.Entity<Place>().HasData([
                    new() {Id = 1, Name = "Place A", Description = "Description A", Latitude = 55.7558, Longitude = 37.6173, TourId = 1 },
            new() {Id = 2, Name = "Place B", Description = "Description B", Latitude = 56.7558, Longitude = 38.6173, TourId = 1 }
            ]);

            //Add initial data for Review
            modelBuilder.Entity<Review>().HasData([
                    new() {Id = 1, UserName = "User A", Comment = "Comment A", Rating = 5, TourId = 1, DateCreated = DateTime.Now },
            new() {Id = 2, UserName = "User B", Comment = "Comment B", Rating = 4, TourId = 1, DateCreated = DateTime.Now.AddDays(-1) }
            ]);

            // Add initial data for Tours
            modelBuilder.Entity<Tour>().HasData([
               new Tour {Id = 1, Title = "Moscow City Tour", GuideId = 1, Description = "Explore historical Moscow", Price = 1500, Duration = new TimeSpan(3,0,0), ImageUrl = "/images/moscow.jpg" }
              ]);

        }
    }
}


