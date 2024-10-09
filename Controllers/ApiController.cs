using DummyJson.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace DummyJson.Controllers
{
    public class ApiController : Controller
    {
        [Route("api")]
        public IActionResult Index()
        {
            var client = new RestClient("https://dummyjson.com/");
            var request = new RestRequest("users", Method.Get);

            var response = client.Get<UserResponse>(request);
            if (response != null && response.Users != null)
            {
                return View(response.Users);
            }
            return View(new List<User>());
        }

        [Route("api/Products")]
        public IActionResult GetProduct()
        {
            var client = new RestClient("https://dummyjson.com/");
            var request = new RestRequest("products", Method.Get);

            var response = client.Get<ProductResponse>(request);

            if (response != null && response.Products != null)
            {
                return View("Product", response.Products);
            }
            return View("Product", new List<Product>());
        }

        [Route("api/Detail/{id}")]
        public IActionResult GetDetail(int id)
        {
            var client = new RestClient("https://dummyjson.com/");
            var request = new RestRequest($"users/{id}", Method.Get);

            var response = client.Get<User>(request);

            if (response != null)
            {
                return View("GetDetail", response);
            }
            return View("Error");
        }

        [Route("api/ProductDetail/{id}")]
        public IActionResult GetProductDetail(int id)
        {
            var client = new RestClient("https://dummyjson.com/");
            var request = new RestRequest($"products/{id}", Method.Get);

            var response = client.Get<Product>(request);

            if (response != null)
            {
                return View("GetProductDetail", response);
            }
            return View("Error");
        }



    }
}
