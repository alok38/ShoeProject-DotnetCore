using Microsoft.AspNetCore.Mvc;
using ShoeMartMVC.Models;
using ShoeMartMVC.ViewModel;

namespace ShoeMartMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult DoLogin(Customer customer)
        {
            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer c1 = new Customer();
            bool IsValidUser(Customer customer)
            {
                HttpClient client;
                HttpResponseMessage response;
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5120/");
                response = client.GetAsync("api/Customer/GetAllCustomers/").Result;

                var customers = response.Content.ReadFromJsonAsync<IEnumerable<Customer>>().Result;

                foreach (Customer customerc in customers)
                {
                    if ((customerc.EmailId == customer.EmailId) && (customerc.Password == customer.Password))
                    {
                        customer.CustomerId = customerc.CustomerId;
                        
                        bal.user(customerc.CustomerId);
                        bal.setname(customerc.CustomerName);
                        return true;
                    }

                }
                return false;
            }
           
            if (IsValidUser(customer))
            {

                return RedirectToAction("GetAll", "HomePage");
            }
            else
            {

                return View("Login");
            }
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult AdminDoLogin(Admin admin)
        {
            AdminBusinessLayer adminbusinesslayer = new AdminBusinessLayer();
            bool IsValidAdmin(Admin adminValid)
            {
                HttpClient client;
                HttpResponseMessage response;
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5120/");
                response = client.GetAsync("api/Admin/GetAllAdmins/").Result;

                var admins = response.Content.ReadFromJsonAsync<IEnumerable<Admin>>().Result;

                foreach (Admin admincheck in admins)
                {
                    if ((admincheck.UserId == adminValid.UserId) && (admincheck.Password == adminValid.Password))
                    {
                        adminbusinesslayer.getAdmin(admincheck);
                        return true;
                    }

                }
                return false;
            }

            if (IsValidAdmin(admin))
            {
                return RedirectToAction("AdminHome", "HomePage");
            }
            else
            {
                return View("AdminLogin");
            }

        }
        public IActionResult Logout()
        {
            CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();
            customerBusiness.user(0);
            customerBusiness.setname(" ");
            return RedirectToAction("Login","Authentication");
        }
        public IActionResult AdminLogout()
        {
            AdminBusinessLayer adminBusiness = new AdminBusinessLayer();
            Admin admin = new Admin();
            adminBusiness.getAdmin(admin);
            return RedirectToAction("AdminLogin", "Authentication");
        }
    }
}
