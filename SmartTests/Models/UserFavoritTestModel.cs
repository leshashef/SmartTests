using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class UserFavoritTestModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual UserModel UserModel { get; set; }

        public int TestId { get; set; }
        public virtual TestQuizModel FavoritTest { get; set; }
    }
}
