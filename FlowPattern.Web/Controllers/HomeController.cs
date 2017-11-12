using FlowPattern.Data.System;
using FlowPattern.Data.System.Builders;
using FlowPattern.Data.SystemParts;
using FlowPattern.Data.SystemParts.Factories;
using FlowPattern.Web.Models.SystemModels;
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
            SystemContext systemContext = new SystemContext("HelloSystem", new SessionPersistenceProvider(Session));

            if (!systemContext.System.Any())
            {
                systemContext.System = CreateSystem();
                systemContext.Save();
            }

            var system = systemContext.System.Select(x => x.ToItemViewModel());



            return View(system);
        }

        public ActionResult Execute(string _id, string _action)
        {
            SystemContext system = new SystemContext("HelloSystem", new SessionPersistenceProvider(Session));

            system.ExecuteAction(_id, _action);

            var model = system.System.Select(e => e.ToItemViewModel());

            var json = Json(model, JsonRequestBehavior.AllowGet);

            return json;
        }

        private List<ASystemPart> CreateSystem()
        {
            var factory = new SystemPartFactory();
            var builder = new SystemBuilder(factory);

            var g = "generator_0";
            var s = "switch_0";
            var l = "light_0";

            builder.AddPart(g, "0_5");
            builder.AddPart(s, "3_5");
            builder.AddPart(l, "6_5");

            builder.ConnectParts(g + ">" + s);
            builder.ConnectParts(s + ">" + l);

            return builder.SystemParts;
        }
    }
}