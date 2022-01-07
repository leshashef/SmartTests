using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models.ModelFastDevFroKyrsach
{
    public class Question
    {
        public int Id { get; set; }

        public string NameQuestion { get; set; }

        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answers> Answers { get; set; }
        public virtual List<TrueAnswers> TrueAnswers { get; set; }
        public Question()
        {
            Answers = new List<Answers>();
            TrueAnswers = new List<TrueAnswers>();
        }
    }
}
