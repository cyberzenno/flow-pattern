using FlowPattern.Data.SystemParts;
using FlowPattern.Data.SystemParts.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.System.Builders
{
    public class SystemBuilder
    {
        public List<ASystemPart> SystemParts { get; set; }

        private ISystemPartFactory SystemPartFactory { get; set; }

        public SystemBuilder(ISystemPartFactory systemPartFactory)
        {
            SystemPartFactory = systemPartFactory;
            SystemParts = new List<ASystemPart>();
        }

        public void AddPart(string type_id)
        {
            var part = SystemPartFactory.Create(type_id);
            SystemParts.Add(part);
        }

        public void AddPart(string type_id, string x_y)
        {
            var part = SystemPartFactory.Create(type_id);

            var args = x_y.Split('_');

            part.X = int.Parse(args[0]);
            part.Y = int.Parse(args[1]);

            SystemParts.Add(part);
        }

        public void ConnectParts(string sourceIdGtTargetId)
        {
            var split = sourceIdGtTargetId.Split('>');
            var sourceId = split[0].Trim();
            var targetId = split[1].Trim();

            var sourceElement = GetById(sourceId);
            var targetElement = GetById(targetId);

            sourceElement.Output.Add(targetElement);
            targetElement.Input.Add(sourceElement);
        }

        public ASystemPart GetById(string id)
        {
            var part = SystemParts.FirstOrDefault(x => x.Id == id);

            if (part == null) throw new Exception("The System Part " + id + " doesn't exist in the current system");

            return part;
        }



    }
}
