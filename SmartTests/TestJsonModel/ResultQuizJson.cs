using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.TestJsonModel
{
    public class ResultQuizJson
    {
        public List<QuestionResult> Questions { get; set; } = new List<QuestionResult>();


        public int Right { get; set; }
        public int All { get; set; }
    }
    public class QuestionResult
    {
        public string QuestionName { get; set; }

        public List<AnswerResult> AnswerResult { get; set; } = new List<AnswerResult>();
    }
    public class AnswerResult
    {
        public string NameAnswer { get; set; }

        public bool TrueAnswer { get; set; }

        public bool SendAnswer { get; set; }
    }
}
