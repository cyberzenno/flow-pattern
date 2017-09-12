using FlowPattern.Data.SystemParts;
using FlowPattern.Data.SystemParts.Factories;
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
            var system = CreateSystem().Select(x => x.ToItemViewModel()).ToArray();

            for (int i = 0; i < system.Count(); i++)
            {
                system[i].XY(i*2, 5);                
            }

            return View(system);
        }

        private IList<ASystemPart> CreateSystem()
        {
            var factory = new SystemPartFactory();

            var generator = factory.Create("generator_0_activated");
            var switchA = factory.Create("switch_0_activated");
            var bulb = factory.Create("bulb_0_activated");

            return new List<ASystemPart> { generator, switchA, bulb };
        }
    }
}