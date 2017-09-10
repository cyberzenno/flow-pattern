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
                AFlow flow = new NullFlow();

                if (IsActivated) flow = new Flow();

                return flow;
            }
        }
    }
}
