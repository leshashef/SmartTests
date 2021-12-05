using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CorePush.Google;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SmartTests.Models;
using SmartTests.Models.Context;
using WebPush;

namespace SmartTests.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext dbContext;
        private readonly IConfiguration configuration;


        public HomeController(ILogger<HomeController> logger, AppDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            dbContext = context;
            this.configuration = configuration;

        }

        public IActionResult Index()
        {
         
            return View();
        }
        [HttpPost]
        public IActionResult Privacy(string client, string endpoint, string p256dh, string auth)
        {
            if (client == null)
            {
                return BadRequest("No Client Name parsed.");
            }
            if (dbContext.Users.FirstOrDefault(x=>x.Login == client) != null)
            {
                return BadRequest("Client Name already used.");
            }
            var subscription = new PushSubscription(endpoint, p256dh, auth);
            dbContext.Users.Add(new UserModel { Login = client, Name = subscription.P256DH, Phone = subscription.Auth, Password = subscription.Endpoint });
            dbContext.SaveChanges();
            return View("Notify", dbContext.Users.Select(x=>x.Login).ToList());
        }
        public IActionResult Privacy()
        {
            ViewBag.applicationServerKey = configuration["VAPID:publicKey"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Contact()
        {
       
            return View();
        }
        [Route("send")]
        [HttpPost]
        public async Task<IActionResult> ContactAsync(DateTime date)
        {
          
            return Ok();
        }
        public IActionResult Notify()
        {
            return View(dbContext.Users.ToList());
        }
        [HttpPost]
        public IActionResult Notify(string message, string client)
        {
            if (client == null)
            {
                return BadRequest("No Client Name parsed.");
            }
            UserModel user = dbContext.Users.FirstOrDefault(x => x.Login == client);
          //  PushSubscription subscription = PersistentStorage.GetSubscription(client);
            if (user == null)
            {
                return BadRequest("Client was not found");
            }

            var subject = configuration["VAPID:subject"];
            var publicKey = configuration["VAPID:publicKey"];
            var privateKey = configuration["VAPID:privateKey"];
            PushSubscription subscription = new PushSubscription { Auth = user.Phone, P256DH = user.Name, Endpoint = user.Password };
            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);

            var webPushClient = new WebPushClient();
            try
            {
                webPushClient.SendNotification(subscription, message, vapidDetails);
            }
            catch (Exception exception)
            {
                // Log error
            }

            return View(dbContext.Users.Select(x => x.Login).ToList());
        }
    }
}
