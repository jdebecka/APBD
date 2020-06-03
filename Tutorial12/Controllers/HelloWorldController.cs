using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial12.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["numTimes"] = numTimes;
            return View();
        }
    }
}