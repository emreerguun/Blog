using Blog.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Concrete
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserID = 1, Name = "user1", Surname = "user1", Password = "pass1", UserName = "user", UserRole = 1 });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "category1" });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 1, Title = "Title1", Description = "description1", Content = "content1", NumberOfClick = 0, CategoryID = 1, UserID = 1 });

        }

    }
}
