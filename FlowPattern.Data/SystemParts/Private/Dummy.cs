using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Private
{
    class Dummy : ASystemPart
    {
        public override AFlow Flow
        {
            get
            {
                var partWithFlow = Input.FirstOrDefault(x => x.Flow != null);
                if (partWithFlow != null)
                {
                    return partWithFlow.Flow;
                }
                return null;
            }
        }

        public override bool IsActive
        {
            get { return Flow != null; }
        }

        public override void Activate()
        {
           //do nothing
        }

        public override void Deactivate()
        {
            //do nothing
        }
    }
}
