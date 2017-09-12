using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Private
{
    class Generator : ASystemPart
    {
        public override AFlow Flow
        {
            get
            {
                return IsActivated ? new Flow() : null;
            }
        }

        public override bool IsActive
        {
            get { return IsActivated; }
        }
    }
}
