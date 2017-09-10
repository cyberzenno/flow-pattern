using FlowPattern.Data.SystemParts.Private;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Factories
{
    public interface ISystemPartFactory
    {
        ASystemPart Create(string type_id_state);
    }

    public class SystemPartFactory : ISystemPartFactory
    {
        public ASystemPart Create(string type_id_state)
        {
            //split
            var args = type_id_state.Split('_');
            var type = args[0];
            var id = args[1];
            var state = args[2];

            //parse
            PartType partType;
            PartState partState;
            Enum.TryParse<PartType>(type, true, out  partType);
            Enum.TryParse<PartState>(state, true, out  partState);

            //create
            ASystemPart result = Create(id, partType, partState);

            //return
            return result;
        }

        private ASystemPart Create(string id, PartType type, PartState state)
        {
            ASystemPart result = new UnknownPart();
            switch (type)
            {
                case PartType.Generator:

                    result = new Generator
                    {
                        Id = id,
                        SystemPartType = type,
                        SystemPartState = state
                    };

                    break;
            }

            return result;
        }
    }
}
