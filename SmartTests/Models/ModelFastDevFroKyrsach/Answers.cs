using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models.ModelFastDevFroKyrsach
{
    public class Answers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int LocalId { get; set; }
        public string Value { get; set; }
    }
}
