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
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<TestQuizModel> TestQuizs { get; set; }

        public DbSet<NotificationDataModel> NotificationData { get; set; }
        public DbSet<PassTestModel> PassTest { get; set; }
        public DbSet<UserFavoritTestModel> UserFavoritTest { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //        Database.EnsureDeleted();
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";
            string first_registrationRoleName = "first_registration";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";
            string adminName = "Алексей";
            string adminLogin = "leshashef";
            // добавляем роли
            RoleModel adminRole = new RoleModel { Id = 1, Name = adminRoleName };
            RoleModel userRole = new RoleModel { Id = 2, Name = userRoleName };
            RoleModel first_registrationRole = new RoleModel { Id = 3, Name = first_registrationRoleName };
            UserModel adminUser = new UserModel { Id = 1, Email = adminEmail, Password = adminPassword,
                                                  Name = adminName, Login = adminLogin,
                                                  RoleModelId = adminRole.Id };

            modelBuilder.Entity<RoleModel>().HasData(new RoleModel[] { adminRole, userRole, first_registrationRole });
            modelBuilder.Entity<UserModel>().HasData(new UserModel[] { adminUser });


            modelBuilder.Entity<PassTestModel>()
              .HasOne(e => e.TestQuiz)
              .WithMany(t=>t.UsersPassTest)
              .OnDelete(DeleteBehavior.NoAction); // <--
            modelBuilder.Entity<PassTestModel>()
              .HasOne(e => e.User)
              .WithMany(t=>t.UserPassTest)
              .OnDelete(DeleteBehavior.NoAction); // <--

            modelBuilder.Entity<UserFavoritTestModel>()
             .HasOne(e => e.FavoritTest)
            .WithMany(t => t.FavoritFromUser)
            .OnDelete(DeleteBehavior.NoAction); // <--
            modelBuilder.Entity<UserFavoritTestModel>()
              .HasOne(e => e.User)
              .WithMany(t => t.FavoritTest)
              .OnDelete(DeleteBehavior.NoAction); // <--

        }
    }
}
