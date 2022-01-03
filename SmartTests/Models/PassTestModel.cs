using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class PassTestModel
    {
        public int Id { get; set; }

        [ForeignKey("UserModelId")]
        public virtual UserModel User { get; set; }
        public  int UserModelId { get; set; }

        [ForeignKey("TestQuizModelId")]
        public virtual TestQuizModel TestQuiz { get; set; }
        public int TestQuizModelId { get; set; }

        /// <summary>
        /// Json формат
        /// </summary>
        public string QuestionAnswer { get; set; }

        public int CountCorrectAnswer { get; set; }

        public int CountQuestions { get; set; }
    }
}
