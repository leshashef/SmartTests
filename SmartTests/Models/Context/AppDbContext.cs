using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartTests.Models.Notification;

namespace SmartTests.Models.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<TestQuizModel> TestQuizs { get; set; }

        public DbSet<NotificationDataModel> NotificationData { get; set; }
        public DbSet<PassTestModel> PassTest { get; set; }
        public DbSet<UserFavoritTestModel> UserFavoritTest { get; set; }
        public DbSet<UserTestModel> UserTest { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
