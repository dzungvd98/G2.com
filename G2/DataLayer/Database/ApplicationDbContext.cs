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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Award> Awards { get; set; }
        public DbSet<Category> Category { get; set; }
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
        public DbSet<Pricing> Pricings { get; set; }
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
        public DbSet<VideoReview> VideoReviews { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
