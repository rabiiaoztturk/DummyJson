using DummyJson.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;

namespace DummyJson.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new FormModel());
        }

        [HttpPost]
        public IActionResult Index(FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var captchaToken = Request.Form["g-recaptcha-response"];

            if (!VerifyCaptcha(captchaToken))
            {
                ViewBag.CaptchaError = true;
                return View(model);
            }

            return View("Sonuc");
        }

        public bool VerifyCaptcha(string captchaToken)
        {
            var client = new RestClient("https://www.google.com/recaptcha");
            var request = new RestRequest("", Method.Post);
            request.AddParameter("secret", "");
            request.AddParameter("response", captchaToken);

            var response = client.Execute<CaptchaResponse>(request);

            if (response.Data.Success && response.Data.Score > 0.6)
            {
                return true;
            }
            return false;
        }
    }
}
