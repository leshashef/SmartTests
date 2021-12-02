using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class TestQuizModel
    {
        public TestQuizModel()
        {
            Questions = new List<QuestionModel>();
        }
        public int Id { get; set; }

        public string NameQuiz { get; set; }

        public int UserModelId { get; set; }
        public virtual UserModel UserModel { get; set; }

        public virtual List<QuestionModel> Questions { get; set; }

        public int LikeThisQuiz { get; set; }
        
    }
}
