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
            var s0 = "switch_0";
            var s1 = "switch_1";
            var s2 = "switch_2";
            var s3 = "switch_3";

            var l1 = "light_1";
            var l2 = "light_2";

            var s4 = "switch_4";
            var s5 = "switch_5";
            var s6 = "switch_6";

            var l3 = "light_3";
            var l4 = "light_4";


            builder.AddPart(g, "0_4");
            builder.AddPart(s0, "2_4");
            builder.AddPart(s1, "4_2");
            builder.AddPart(s2, "6_1");
            builder.AddPart(s3, "6_3");

            builder.AddPart(s4, "4_7");
            builder.AddPart(s5, "6_6");
            builder.AddPart(s6, "6_8");

            builder.AddPart(l1, "9_1");
            builder.AddPart(l2, "9_3");
            builder.AddPart(l3, "9_6");
            builder.AddPart(l4, "9_8");


            builder.ConnectParts(g + ">" + s0);
            builder.ConnectParts(s0 + ">" + s1);
            builder.ConnectParts(s1+ ">" + s2);
            builder.ConnectParts(s1 + ">" + s3);

            builder.ConnectParts(s2 + ">" + l1);
            builder.ConnectParts(s3 + ">" + l2);


            builder.ConnectParts(s0 + ">" + s4);
            builder.ConnectParts(s4 + ">" + s5);
            builder.ConnectParts(s4 + ">" + s6);

            builder.ConnectParts(s5 + ">" + l3);
            builder.ConnectParts(s6 + ">" + l4);


            return builder.SystemParts;
        }
    }
}