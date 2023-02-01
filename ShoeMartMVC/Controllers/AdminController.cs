using Microsoft.AspNetCore.Mvc;
using ShoeMartMVC.Models;
using ShoeMartMVC.ViewModel;

namespace ShoeMartMVC.Controllers
{
    public class AdminController : Controller
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response;
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult AdminCustomersView()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            AdminBusinessLayer adminBusiness = new AdminBusinessLayer();
            adminViewModel.adminvm = adminBusiness.ReturnAdmin();
            return View(adminViewModel);
        }
        public IActionResult AdminReviewsView()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            AdminBusinessLayer adminBusiness = new AdminBusinessLayer();
            adminViewModel.adminvm = adminBusiness.ReturnAdmin();
            return View(adminViewModel);
        }
        public IActionResult AdminShoesView()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            AdminBusinessLayer adminBusiness = new AdminBusinessLayer();
            adminViewModel.adminvm = adminBusiness.ReturnAdmin();
            return View(adminViewModel);
        }
        public IActionResult AdminGetAllCustomers()
        {
           
            client.BaseAddress = new Uri("http://localhost:5120/");
            List<Customer> customers = new List<Customer>();
            response = client.GetAsync("api/Customer/GetAllCustomers/").Result;

            var customerList = response.Content.ReadFromJsonAsync<IEnumerable<Customer>>().Result;

            foreach (var customer in customerList)
            {
                customers.Add(customer);
            }

            CustomerRecords customerrecords = new CustomerRecords();
            customerrecords.customersCR = customers;
            return View(customerrecords);
        }
        public IActionResult AdminUpdateCustomers()
        {
            return View();
        }
        public IActionResult UpdateCustomer(Customer customer)
        {
            
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.PutAsJsonAsync("api/Customer/Update/",customer).Result;
            return RedirectToAction("AdminCustomersView", "Admin");
        }
        public IActionResult AdminDeleteCustomer()
        {
            return View();
        }
        public IActionResult DeleteCustomer(int CustomerId)
        {
           
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.DeleteAsync("api/Customer/Delete/"+ CustomerId).Result;
            return RedirectToAction("AdminCustomersView", "Admin");
        }
        public IActionResult AdminGetAllReviews()
        {
            
            client.BaseAddress = new Uri("http://localhost:5120/");
            List<Review> reviews = new List<Review>();
            response = client.GetAsync("api/Review/GetAllReviews/").Result;

            var reviewList = response.Content.ReadFromJsonAsync<IEnumerable<Review>>().Result;

            foreach (var review in reviewList)
            {
                reviews.Add(review);
            }

            ReviewRecords reviewrecords = new ReviewRecords();
            reviewrecords.Reviews = reviews;
            return View(reviewrecords);
        }
        public IActionResult AdminUpdateReviews()
        {
            return View();
        }
        public IActionResult UpdateReview(Review review)
        {
           
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.PutAsJsonAsync("api/Review/Update/", review).Result;
            return RedirectToAction("AdminReviewsView", "Admin");
        }
        public IActionResult AdminDeleteReview()
        {
            return View();
        }
        public IActionResult DeleteReview(int ReviewId)
        {
           
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.DeleteAsync("api/Review/Delete/" + ReviewId).Result;
            return RedirectToAction("AdminReviewsView", "Admin");
        }
        public IActionResult AdminGetAllShoes()
        {
            
            client.BaseAddress = new Uri("http://localhost:5120/");
            List<Shoe> shoes = new List<Shoe>();
            response = client.GetAsync("api/Shoe/GetAllShoes/").Result;

            var shoeList = response.Content.ReadFromJsonAsync<IEnumerable<Shoe>>().Result;

            foreach (var shoe in shoeList)
            {
                shoes.Add(shoe);
            }

            ShoeRecords shoerecords = new ShoeRecords();
            shoerecords.shoes = shoes;
            return View(shoerecords);
        }
        public IActionResult AdminUpdateShoes()
        {
            return View();
        }
        public IActionResult UpdateShoe(Shoe shoe)
        {
            
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.PutAsJsonAsync("api/Shoe/Update/", shoe).Result;
            return RedirectToAction("AdminShoesView", "Admin");
        }
        public IActionResult AdminDeleteShoe()
        {
            return View();
        }
        public IActionResult DeleteShoe(int ShoeId)
        {
            
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.DeleteAsync("api/Shoe/Delete/" + ShoeId).Result;
            return RedirectToAction("AdminShoesView", "Admin");
        }
    }
}
