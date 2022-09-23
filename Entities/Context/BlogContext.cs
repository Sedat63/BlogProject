using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BlogContext:DbContext
    {
        //add-migration: .Net tarafında tablo değişikliklerini kaydeder. Ama Db'ye yansıtmaz
        //update-database: add-migration ile kaydedilen değişiklikleri Db'ye aktarır.
        //remove-migration: add-migration kaydını siler.
        // remove-migration -force: hem veritabanındaki hemde .Netteki değişiklikleri siler. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=Blog; Trusted_Connection=true");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<ArticleTag> ArticleTickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }

    }
}
