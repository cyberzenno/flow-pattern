using FlowPattern.Data.SystemParts.Private;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Factories
{
    public class SystemPartFactory : ISystemPartFactory
    {
        /// <summary>
        /// Example: generator 0
        /// </summary>
        public ASystemPart Create(string type_id)
        {
            //split
            var args = type_id.Split('_');
            var type = args[0];
            var id = type_id;

            //parse
            PartType partType;
            Enum.TryParse<PartType>(type, true, out  partType);

            //return
            return Create(id, partType, PartState.NotActivated);
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

                case PartType.Switch:

                    result = new Switch
                    {
                        Id = id,
                        SystemPartType = type,
                        SystemPartState = state
                    };

                    break;

                case PartType.Light:

                    result = new Light
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
