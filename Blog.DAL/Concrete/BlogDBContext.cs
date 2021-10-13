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
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "Teknoloji" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, Name = "Sanat" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 3, Name = "Spor" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 4, Name = "Sağlık" });

            modelBuilder.Entity<User>().HasData(new User { UserID = 1, Name = "adminname1", Surname = "adminsurname1", Password = "a722c63db8ec8625af6cf71cb8c2d939", UserName = "admin", UserRole = 1 });
            modelBuilder.Entity<User>().HasData(new User { UserID = 2, Name = "name2", Surname = "surname2", Password = "a722c63db8ec8625af6cf71cb8c2d939", UserName = "username2", UserRole = 2 });
            modelBuilder.Entity<User>().HasData(new User { UserID = 3, Name = "name3", Surname = "surname3", Password = "a722c63db8ec8625af6cf71cb8c2d939", UserName = "username3", UserRole = 2 });
            modelBuilder.Entity<User>().HasData(new User { UserID = 4, Name = "name4", Surname = "surname4", Password = "a722c63db8ec8625af6cf71cb8c2d939", UserName = "username4", UserRole = 2 });


            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 1, Title = "Spor Makalesi", Description = "Basketbol Adına Herşey", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum",Date=DateTime.Now.AddDays(26), NumberOfClick = 342, CategoryID = 3, UserID = 1 , ImagePath=null});
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 2, Title = "Sanat Makalesi", Description = "Sanat Adına Herşey", Content = "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(6), NumberOfClick = 122, CategoryID = 2, UserID = 1, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 3, Title = "Sanat Makalesi2", Description = "Sanat Adına Herşey 2", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(12), NumberOfClick = 0, CategoryID = 2, UserID = 1, ImagePath = null });



            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 4, Title = "Spor Makalesi", Description = "Basketbol Adına Herşey", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(2), NumberOfClick = 34, CategoryID = 3, UserID = 2, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 5, Title = "Sanat Makalesi", Description = "Sanat Adına Herşey", Content = "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(5), NumberOfClick = 125, CategoryID = 2, UserID = 2, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 6, Title = "Sanat Makalesi2", Description = "Sanat Adına Herşey 2", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(13), NumberOfClick = 11, CategoryID = 2, UserID = 2, ImagePath = null });



            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 7, Title = "Spor Makalesi", Description = "Basketbol Adına Herşey", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(17), NumberOfClick = 67, CategoryID = 3, UserID = 3, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 8, Title = "Sanat Makalesi", Description = "Sanat Adına Herşey", Content = "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(7), NumberOfClick = 98, CategoryID = 2, UserID = 3, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 9, Title = "Sanat Makalesi2", Description = "Sanat Adına Herşey 2", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(1), NumberOfClick = 34, CategoryID = 2, UserID = 3, ImagePath = null });


            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 10, Title = "Spor Makalesi", Description = "Basketbol Adına Herşey", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now, NumberOfClick =66, CategoryID = 3, UserID = 4, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 11, Title = "Sanat Makalesi", Description = "Sanat Adına Herşey", Content = "Lorem ipsum lorem lorem ipsumrem lorem ipsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(3), NumberOfClick = 21, CategoryID = 2, UserID = 4, ImagePath = null });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleID = 12, Title = "Sanat Makalesi2", Description = "Sanat Adına Herşey 2", Content = "Lorem ipsum lorem lorem ipsum Lorem ipsum loremsum Lorem ipsum lorem lorem ipsum Lorem ipsum lorem lorem ipsum", Date = DateTime.Now.AddDays(3), NumberOfClick = 76, CategoryID = 2, UserID = 4, ImagePath = null });
        }

    }
}
