using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class UserTestQuizModel
    {
        public UserTestQuizModel()
        {
            UserQuiz = new List<TestQuizModel>();
            UserQuizFavorit = new List<TestQuizModel>();
        }
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual UserModel UserModel { get; set; }

        public virtual List<TestQuizModel> UserQuiz { get; set; }

        public virtual List<TestQuizModel> UserQuizFavorit { get; set; }
    }
}
