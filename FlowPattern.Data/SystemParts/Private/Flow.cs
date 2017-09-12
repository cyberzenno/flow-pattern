using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Private
{
    class Flow : AFlow
    {
    }

    class NullFlow : AFlow
    {
        private NullFlow() { }
        private static NullFlow flow;

        public static NullFlow Get()
        {
            if (flow == null)
            {
                flow = new NullFlow();
            }

            return flow;
        }
    }
}
