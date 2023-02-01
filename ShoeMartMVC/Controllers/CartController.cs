using Microsoft.AspNetCore.Mvc;
using ShoeMartMVC.Models;
using ShoeMartMVC.ViewModel;
using System.Net.Http.Json;

namespace ShoeMartMVC.Controllers
{
    public class CartController : Controller
    {

        HttpClient client;
        HttpResponseMessage response;
        // GET: Product
        List<Shoe> shoesList = new List<Shoe>();
        public ActionResult AddToOrder(int ShoeID)
        {
            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer cl = new Customer();
            cl.CustomerId = bal.ReturnID();
            Order order = new Order();
            order.ShoeId = ShoeID;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.PostAsJsonAsync("api/Order/Create",order).Result;
            var neworder = response.Content.ReadFromJsonAsync<Order>().Result;
            //response = client.GetAsync("api/Order/GetOrder/" + neworder.OrderId).Result;
            //Order order2 = response.Content.ReadFromJsonAsync<Order>().Result;
            Cart cart = new Cart();
            cart.CustomerId = cl.CustomerId;
            cart.OrderId = neworder.OrderId;
            response = client.PostAsJsonAsync("api/Cart/Create",cart).Result;
            var newcart = response.Content.ReadFromJsonAsync<Cart>().Result;
            return RedirectToAction("GetAll", "HomePage");
        }
        public IActionResult ViewCart()
        {
            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer cl = new Customer();
            cl.CustomerId = bal.ReturnID();
            List<Order> orders = new List<Order>();
            List<Shoe> shoes = new List<Shoe>();
            int id = cl.CustomerId;

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            //HttpResponseMessage response1 = client.GetAsync("api/Cart/GetAllCartsByCustomerId"+cl.CustomerId).Result;
            // List<Cart>CartList = response1.Content.ReadFromJsonAsync<List<Cart>>().Result;
            response = client.GetAsync("api/Cart/GetAllCartsByCustomerId/"+id).Result;

            var CartList = response.Content.ReadFromJsonAsync<IEnumerable<Cart>>().Result;

            foreach (var cart in CartList)
            {
                response = client.GetAsync("api/Order/GetOrder/" + cart.OrderId).Result;
                Order neworder = response.Content.ReadFromJsonAsync<Order>().Result;
                orders.Add(neworder);
            }
            foreach(var order in orders)
            {
                response = client.GetAsync("api/Order/GetAllShoesByOrderId/" + order.OrderId).Result;
                Shoe newshoe = response.Content.ReadFromJsonAsync<Shoe>().Result;
                shoes.Add(newshoe);
            }
            int Total = 0;
            foreach (var shoe in shoes)
            {
                Total += shoe.Price;
            }

            ShoeRecords shoerecords = new ShoeRecords();
            shoerecords.shoes = shoes;
            shoerecords.CustomerId = cl.CustomerId;
            shoerecords.Total = Total;
            return View(shoerecords);
        }
        public IActionResult BuyNow()
        {

            CustomerBusinessLayer bal = new CustomerBusinessLayer();
            Customer cl = new Customer();
            cl.CustomerId = bal.ReturnID();


            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5120/");
            response = client.GetAsync("api/Cart/GetAllCartsByCustomerId/" + cl.CustomerId).Result;
            List<Order> orders = new List<Order>();
            var CartList = response.Content.ReadFromJsonAsync<IEnumerable<Cart>>().Result;
            foreach (var cart in CartList)
            {
                response = client.GetAsync("api/Order/GetOrder/" + cart.OrderId).Result;
                Order neworder = response.Content.ReadFromJsonAsync<Order>().Result;
                orders.Add(neworder);
            }
            foreach (var order in orders)
            {
                response = client.DeleteAsync("api/Order/Delete/" + order.OrderId).Result;
                
            }
            //foreach(var cart in CartList)
            //{
            //    response = client.DeleteAsync("api/Cart/Delete/" + cart.CartId).Result;
            //}
            return View();
        }
    }
}
