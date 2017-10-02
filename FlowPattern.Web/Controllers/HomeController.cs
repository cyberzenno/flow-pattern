using FlowPattern.Data.SystemParts;
using FlowPattern.Data.SystemParts.Factories;
using FlowPattern.Web.Models.ViewModels;
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
                system[i].XY(i * 2, 5);
            }

            return View(system);
        }

        private IList<ASystemPart> CreateSystem()
        {
            //let's think a bit

            //create
            //generator_0
            //switch_0
            //switch_1
            //bulb_0

            //connect
            //generator_0 > switch_0
            //switch_0 > switch_1
            //switch_1 > bulb_0
    
            //set state
            //generator_0 activated
            //switch_0 activated
            //switch_1 activated
            //bulb_0 activated



            var factory = new SystemPartFactory();

            var generator = factory.Create("generator_0_activated");
            var switchA = factory.Create("switch_0_activated");
            var bulb = factory.Create("bulb_0_activated");

            return new List<ASystemPart> { generator, switchA, bulb };
        }
    }
}