using Microsoft.AspNetCore.Mvc;
using ShoeMartMVC.Models;
using ShoeMartMVC.ViewModel;
using System.Net.Http.Json;

namespace ShoeMartMVC.Controllers
{
    public class ReviewController : Controller
    {
        HttpClient client;
        HttpResponseMessage response;
        List<Shoe> shoesList = new List<Shoe>();
        static int Shoeid;
        public IActionResult GetAllReviewsOfShoe(int ShoeId)
        {
            Shoeid = ShoeId;
            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer cl = new Customer();
            cl.CustomerId = bal.ReturnID();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.GetAsync("api/Review/GetAllReviewsByShoeId/"+ShoeId).Result;

             var ReviewList = response.Content.ReadFromJsonAsync<IEnumerable<Review>>().Result;
            ReviewRecords reviewrecords = new ReviewRecords();
            reviewrecords.Reviews = (List<Review>)ReviewList;
            return View(reviewrecords);
        }
        public IActionResult AddReview(Review review)
        {
            
            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer cl = new Customer();
            cl.CustomerId = bal.ReturnID();
            cl.CustomerName = bal.getname();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            Review newReview = new Review();
            newReview = review;
            newReview.CustomerName = cl.CustomerName;
            newReview.ShoeId = Shoeid;
            newReview.ReviewTime = DateTime.Now;
            response = client.PostAsJsonAsync("api/Review/Create/" ,newReview).Result;
            return RedirectToAction("GetAll", "HomePage");
        }
    }
}

