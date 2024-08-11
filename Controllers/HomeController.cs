using LoginaLogout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace LoginaLogout.Controllers
{
    public class HomeController : Controller
    {
        private readonly CodeFirstDemoContext context;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(CodeFirstDemoContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("Key") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User users)
        {
            var myData = context.Users.Where(x => x.Email == users.Email && x.Password == users.Password).FirstOrDefault();

            if (myData != null) 
            {
                HttpContext.Session.SetString(
                    "Key",
                    myData.Email);
                return RedirectToAction("Dashboard");
                
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("Key") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("Key").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("Key") != null)
            {
                HttpContext.Session.Remove("Key");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
