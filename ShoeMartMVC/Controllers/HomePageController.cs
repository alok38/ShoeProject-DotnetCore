using Microsoft.AspNetCore.Mvc;
using ShoeMartMVC.Models;
using ShoeMartMVC.ViewModel;

namespace ShoeMartMVC.Controllers
{
    public class HomePageController : Controller
    {
        HttpClient client;
        HttpResponseMessage response;
        List<Shoe> shoesList = new List<Shoe>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer cl = new Customer();
            cl.CustomerId = bal.ReturnID();
            cl.CustomerName = bal.getname();
            if (cl.CustomerId == 0)
            {
                return RedirectToAction("Login", "Authentication");
            }
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.GetAsync("api/Shoe/GetAllShoes/").Result;
            List<Shoe> ShoeList = (List<Shoe>)response.Content.ReadFromJsonAsync<IEnumerable<Shoe>>().Result;
            ShoeRecords shoerecords = new ShoeRecords();
            shoerecords.shoes = ShoeList;
            shoerecords.CustomerId = cl.CustomerId;
            shoerecords.CustomerName = cl.CustomerName;
            return View(shoerecords);
        }
        public IActionResult AdminHome()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            AdminBusinessLayer adminBusiness = new AdminBusinessLayer();
            adminViewModel.adminvm = adminBusiness.ReturnAdmin();
            return View(adminViewModel);
        }
    }
}
