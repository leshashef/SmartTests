using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models.ModelFastDevFroKyrsach
{
    public class Quiz
    {

        public Quiz()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }

        public string NameQuiz { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
