using FlowPattern.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowPattern.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var generator = new ItemViewModel
            {
                Id = "generator0",
                MainCssClass = "generator",
                ActivatedCssClass = "activated",
                ActiveCssClass = "active",
                X = 3,
                Y = 3,
            };

            var switchA = new ItemViewModel
            {
                Id = "switchA",
                MainCssClass = "switch",
                ActivatedCssClass = "activated",
                ActiveCssClass = "active",
                X = 5,
                Y = 5,
            };

            var bulb = new ItemViewModel
            {
                Id = "bulbA",
                MainCssClass = "bulb",
                ActivatedCssClass = "activated",
                ActiveCssClass = "active",
                X = 7,
                Y = 7,
            };


            return View(new[] { generator, switchA, bulb });
        }
    }
}