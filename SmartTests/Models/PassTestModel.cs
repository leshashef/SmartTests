using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class PassTestModel
    {
        public int Id { get; set; }

        public UserModel User { get; set; }
        public int UserModelId { get; set; }

        public TestQuizModel TestQuiz { get; set; }
        public int TestQuizModelId { get; set; }

        /// <summary>
        /// Json формат
        /// </summary>
        public string QuestionAnswer { get; set; }

        public int CountCorrectAnswer { get; set; }

        public int CountQuestions { get; set; }
    }
}
