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
            var d1 = "dummy_1";
            var d2 = "dummy_2";
            var b = "bulb_0";

            builder.AddPart(g, "0_0");
            builder.AddPart(s, "2_2");
            builder.AddPart(d1, "4_1");
            builder.AddPart(d2, "4_3");
            builder.AddPart(b, "6_2");

            builder.ConnectParts(g + ">" + s);
            builder.ConnectParts(s + ">" + d1);
            builder.ConnectParts(s + ">" + d2);
            builder.ConnectParts(d1 + ">" + b);
            builder.ConnectParts(d2 + ">" + b);

            var s1 = "switch_1";
            var s2 = "switch_2";
            var s3 = "switch_3";
            var m = "music_0";

            builder.AddPart(s1, "2_6");
            builder.AddPart(s2, "4_5");
            builder.AddPart(s3, "4_7");
            builder.AddPart(m, "6_6");

            builder.ConnectParts(g + ">" + s1);
            builder.ConnectParts(s1 + ">" + s2);
            builder.ConnectParts(s1 + ">" + s3);
            builder.ConnectParts(s2 + ">" + m);
            builder.ConnectParts(s3 + ">" + m);


            return builder.SystemParts;
        }
    }
}