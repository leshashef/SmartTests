using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartTests.Models.Context;
using SmartTests.TestJsonModel;
using SmartTests.Models.ModelFastDevFroKyrsach;
using Microsoft.EntityFrameworkCore;
using SmartTests.Models;

namespace SmartTests.Controllers
{
    public class QuizController : Controller
    {

        private AppDbContext DBcontext;
        public QuizController(AppDbContext context)
        {
            DBcontext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateQuizJson requestData)
        {

            Quiz quiz = new Quiz() { NameQuiz = requestData.NameQuiz };
            DBcontext.Quizzes.Add(quiz);

            foreach (var quest in requestData.Question)
            {
                Models.ModelFastDevFroKyrsach.Question question = new Models.ModelFastDevFroKyrsach.Question()
                {
                    NameQuestion = quest.QuestionName,
                    Quiz = quiz
                };
                DBcontext.QuestionsK.Add(question);
                foreach (var answer in quest.Answer)
                {
                    Answers ans = new Answers()
                    {
                        LocalId = Convert.ToInt32(answer.id),
                        Question = question,
                        Value = answer.value
                    };
                    DBcontext.Answers.Add(ans);
                }
                foreach (var tr in quest.TrueAnswer)
                {
                    TrueAnswers trAns = new TrueAnswers()
                    {
                        LocalId = Convert.ToInt32(tr.id),
                        Question = question,
                        Value = Convert.ToBoolean(tr.value)
                    };
                    DBcontext.TrueAnswers.Add(trAns);
                }
            }
            DBcontext.SaveChanges();

            return Redirect("Home/Index");
        }

        //Для начало просто список на страницу 
        public IActionResult QuizList()
        {
            List<Quiz> quizzes = DBcontext.Quizzes.ToList();
            return View(quizzes);
        }

        [HttpGet]
        public IActionResult QuizPlay(int id)
        {
            Quiz quizzes = DBcontext.Quizzes.Include(x=>x.Questions).ThenInclude(x=>x.Answers)
                                            .Include(x=>x.Questions).ThenInclude(x=>x.TrueAnswers)
                                            .FirstOrDefault(x=>x.Id == id);
      
            return View(quizzes);
        }

        [HttpPost]
        public IActionResult QuizPlay([FromBody] CreateQuizJson requestData)
        {
            if (requestData != null)
            {
                Quiz quizzes = DBcontext.Quizzes.Include(x => x.Questions).ThenInclude(x => x.Answers)
                                      .Include(x => x.Questions).ThenInclude(x => x.TrueAnswers)
                                      .FirstOrDefault(x => x.Id == Convert.ToInt32(requestData.NameQuiz));
                if(quizzes != null)
                {
                    int countQuestion = quizzes.Questions.Count;
                    bool[] trueAnswer = new bool[quizzes.Questions.Count];
                    int count = 0;
                    ResultQuizJson resultQuizJson = new ResultQuizJson();
                    foreach (var quest in quizzes.Questions)
                    {
                        trueAnswer[count] = true;
                        resultQuizJson.Questions.Add(new QuestionResult() { QuestionName = quest.NameQuestion });
                        foreach (var questRequest in requestData.Question)
                        {
                            if(quest.Id == Convert.ToInt32(questRequest.QuestionName))
                            {
                                for(int x = 0; x< questRequest.TrueAnswer.Length; x++)
                                {
                                    for (int y = 0; y < quest.TrueAnswers.Count; y++)
                                    {
                                        if(Convert.ToInt32(questRequest.TrueAnswer[x].id) == quest.TrueAnswers[y].LocalId)
                                        {
                                            resultQuizJson.Questions[count].AnswerResult.Add(new AnswerResult()
                                            {
                                                NameAnswer = questRequest.Answer[x].value,
                                                SendAnswer = questRequest.TrueAnswer[x].value,
                                                TrueAnswer = quest.TrueAnswers[y].Value
                                            });
                                            if (questRequest.TrueAnswer[x].value != quest.TrueAnswers[y].Value)
                                            {
                                                trueAnswer[count] = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        count++;
                    }
                    int rightAnswer = 0;
                    foreach(var ans in trueAnswer)
                    {
                        if (ans)
                        {
                            rightAnswer++;
                        }
                    } 
        
                    Console.WriteLine($"Итог: {rightAnswer}/{countQuestion}");
                    //return View("QuizResult");
                    //  return RedirectToAction("QuizResult", "Quiz", new { right = rightAnswer, all = countQuestion });
                    resultQuizJson.Right = rightAnswer;
                    resultQuizJson.All = countQuestion;
                    PassQuiz passTestModel = new PassQuiz()
                    {
                        JsonQuiz = JsonSerializer.Serialize<ResultQuizJson>(resultQuizJson)
                    };
                    DBcontext.PassQuizzes.Add(passTestModel);
                    DBcontext.SaveChanges();
                    return Json(new {id = passTestModel.Id });
                }
            }
            return View();
        }
        public IActionResult QuizResult(int id)
        {
            PassQuiz passTest = DBcontext.PassQuizzes.FirstOrDefault(x => x.Id == id);
            ResultQuizJson resultQuiz = JsonSerializer.Deserialize<ResultQuizJson>(passTest.JsonQuiz);
            return View(resultQuiz);
        }

    }

}


