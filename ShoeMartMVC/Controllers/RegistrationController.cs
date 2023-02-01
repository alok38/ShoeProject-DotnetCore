using Microsoft.AspNetCore.Mvc;
using ShoeMartMVC.Models;

namespace ShoeMartMVC.Controllers
{
    public class RegistrationController : Controller
    {
        HttpClient client;
        HttpResponseMessage response;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(Customer customer)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.PostAsJsonAsync("api/Customer/Create/",customer).Result;
            return RedirectToAction("Login", "Authentication");
        }
        public IActionResult RegistrationPage()
        {
            return View();
        }
    }
}
