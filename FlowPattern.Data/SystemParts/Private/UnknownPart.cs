using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Private
{
    class UnknownPart : ASystemPart
    {
        public UnknownPart()
        {
            Id = "Unknown";
            SystemPartType = PartType.Unknown;
            SystemPartState = PartState.Unknown;   
        }

        public override AFlow Flow
        {
            get { return new NullFlow(); }
        }
    }
}
