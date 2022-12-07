using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Application.Interfaces.Context;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Utilities;

namespace Toplearn_Blog.Persistence.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Media> Media { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            string hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = HashPassword.GetHash(sha256, "123456");
            }
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "حسین",
                LastName = "عظیمی",
                Email = "Hossein@gmail.com",
                Phone = "09100000000",
                Password = hash,
                IsActive = true
            });
        }
    }
}
