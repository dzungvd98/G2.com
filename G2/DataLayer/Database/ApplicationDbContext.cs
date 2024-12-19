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
        public DbSet<Award> Awards {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }
        public DbSet<Continent> Continent { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Pricing> Pricings  { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAward> ProductAwards { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
        public DbSet<ProsCons> ProsCons { get; set; }
        public DbSet<ReplyDiscussion> ReplyDiscussions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewDetail> ReviewsDetail { get; set; }
        public DbSet<ReviewFeature> ReviewsFeature { get; set; }
        public DbSet<ReviewProsCons> ReviewProsCons { get; set; }
        public DbSet<ScreenShots> ScreenShots { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<VideoReview> VideoReviews  { get; set; }

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
