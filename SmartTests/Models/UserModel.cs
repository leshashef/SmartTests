using SmartTests.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class UserModel
    {
        public UserModel()
        {
            NotificationDatas = new List<NotificationDataModel>();
            UserPassTest = new List<PassTestModel>();
            UserTests = new List<TestQuizModel>();
            FavoritTest = new List<UserFavoritTestModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


        public string ProfilePhoto { get; set; }

        public int RoleModelId { get; set; }
        public virtual RoleModel Role { get; set; }

        public virtual List<TestQuizModel> UserTests { get; set; }
        public virtual List<NotificationDataModel> NotificationDatas { get; set; } 
        public virtual List<PassTestModel> UserPassTest { get; set; }
        public virtual List<UserFavoritTestModel> FavoritTest { get; set; }
    }
}
