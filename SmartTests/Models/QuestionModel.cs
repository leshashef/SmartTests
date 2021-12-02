using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class QuestionModel
    {
        public long Id { get; set; }

        public string DescriptionQuestion { get; set; }

        public byte TypeQuestion { get; set; }

        /// <summary>
        /// Answer - json с вариантами ответов
        /// </summary>
        public string Answers { get; set; }

        public int TestQuizModelId { get; set; }
        public virtual TestQuizModel TestQuizModel { get; set; }
    }
}
