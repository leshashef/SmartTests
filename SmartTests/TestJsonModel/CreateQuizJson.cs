using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace SmartTests.TestJsonModel
{
    public class CreateQuizJson
    {
   
        public string NameQuiz { get; set; }
       // public string Lol { get; set; }
        public Question[] Question { get; set; }

    }
    public class Question
    {
        public string QuestionName { get; set; }

        public Answer[] Answer { get; set; }
        public TrueAnswer[] TrueAnswer { get; set; }
    }
    public class Answer
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class TrueAnswer
    {
        public string id { get; set; }
        public bool value { get; set; }
    }
}
