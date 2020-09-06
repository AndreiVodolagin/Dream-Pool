using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DreamsPool.Models;
using DreamsPool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace DreamsPool.Controllers
{

    public class HomeController : Controller
    {
        IProductRepository repoProduct;
        ICustomerRepository repoCustomer;
        IAdminRepository repoAdmin;

        public HomeController(IProductRepository rep1, ICustomerRepository rep2,
            IAdminRepository rep3)
        {
            repoProduct = rep1;
            repoCustomer = rep2;
            repoAdmin = rep3;
        }

        public IActionResult Index()
        {
            return View(repoProduct.Pools);
        }

        [HttpGet]
        public IActionResult Order()
        {
            string cult = CultureInfo.CurrentCulture.ToString();
            if(cult.Contains("es"))
            {
                ViewBag.Lan = Language.Es;
            }
            else
            {
                ViewBag.Lan = Language.En;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Order(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repoCustomer.Add(customer);
                TempData["message"] = $"Thank you! We'll call you back within an hour!";
                var sendMessage = new MailAlert(repoAdmin);
                sendMessage.SendMessage(customer);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = $"There's been some mistake! Give us a call!";
                string cult = CultureInfo.CurrentCulture.ToString();
                if (cult.Contains("es"))
                {
                    ViewBag.Lan = Language.Es;
                }
                else
                {
                    ViewBag.Lan = Language.En;
                }
                return View();
            }
        }

        public IActionResult Contact(int? id = null)
        {
            if (id != null)
            {
                Customer customer = repoCustomer.Customers.Where(c => c.Id == id) as Customer;
                ViewBag.CustomerName = customer.Name;
            }

            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}