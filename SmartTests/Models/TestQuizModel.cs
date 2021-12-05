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
        public virtual UserModel User { get; set; }

        public virtual List<QuestionModel> Questions { get; set; }

        public int LikeThisQuiz { get; set; }

        public bool IsPrivateTest { get; set; }
        public string InviteCode { get; set; }

        public int PassThisTest { get; set; }

        public string TextAfterPass { get; set; }

        public byte Difficulty { get; set; }

        public byte ThemeTest { get; set; }
    }
}
