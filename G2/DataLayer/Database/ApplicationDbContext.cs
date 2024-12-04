using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Award> awards {  get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<CompanySize> companySizes { get; set; }
        public DbSet<Continent> continent { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<Favorite> favorite { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<Industry> industry { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductAward> productAwards { get; set; }
        public DbSet<ProductFeature> featuresFeature { get; set; }
        public DbSet<Rating> rating { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<ReviewDetail> reviewsDetail { get; set; }
        public DbSet<ReviewFeature> reviewsFeature { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship between Continent and Country
            modelBuilder.Entity<Country>()
                .HasOne<Continent>()
                .WithMany()
                .HasForeignKey(c => c.ContinentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Company Size with Company
            modelBuilder.Entity<Company>()
                .HasOne<CompanySize>()
                .WithMany()
                .HasForeignKey(c => c.CompanySizeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship between Company and Industry
            modelBuilder.Entity<Company>()
                .HasOne<Industry>()
                .WithMany()
                .HasForeignKey(c => c.IndustryId);

            // Relationship between Company and Country
            modelBuilder.Entity<Company>()
                .HasOne<Country>()
                .WithMany()
                .HasForeignKey(c => c.CountryId);

            // Relationship between product and company
            modelBuilder.Entity<Product>()
                .HasOne<Company>()
                .WithMany()
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship between User and company
            modelBuilder.Entity<User>()
                .HasOne<Company>()
                .WithMany()
                .HasForeignKey(u => u.CompanyId);

            // Relationship between Product and ProductFeatures
            modelBuilder.Entity<ProductFeature>()
                .HasKey(pf => new { pf.ProductId, pf.FeatureId });

            modelBuilder.Entity<ProductFeature>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(pf => pf.ProductId);

            modelBuilder.Entity<ProductFeature>()
                .HasOne<Feature>()
                .WithMany()
                .HasForeignKey(pf => pf.FeatureId);

            // Relationship between Product and Favorite
            modelBuilder.Entity<Favorite>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(f => f.ProductId);

            // Relationship between User and Favorite
            modelBuilder.Entity<Favorite>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(f => f.UserId);

            // Relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            // Relationship between product and review
            modelBuilder.Entity<Review>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(r => r.ProductId);

            // Relationship between user and review
            modelBuilder.Entity<Review>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserId);

            // Relationship between review features and review
            modelBuilder.Entity<ReviewFeature>()
                .HasOne<Review>()
                .WithMany()
                .HasForeignKey(rf => rf.ReviewId);

            // Relationship between review fetures and feature
            modelBuilder.Entity<ReviewFeature>()
                .HasOne<Feature>()
                .WithMany()
                .HasForeignKey(rf => rf.FeatureId);

            // Relationship between Rating và Review Detail
            modelBuilder.Entity <ReviewDetail>()
                .HasOne<Rating>()
                .WithMany()
                .HasForeignKey(rd => rd.RatingId);

            // Relationship between review and review detail
            modelBuilder.Entity<ReviewDetail>()
                .HasOne<Review>()
                .WithMany()
                .HasForeignKey(rd => rd.ReviewId);

            // Relationship between award and product award
            modelBuilder.Entity<ProductAward>()
                .HasOne<Award>()
                .WithMany()
                .HasForeignKey(pa => pa.AwardId);

            // Relationship between product and productaward
            modelBuilder.Entity<ProductAward>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(pa => pa.ProductId);

        }
    }
}
