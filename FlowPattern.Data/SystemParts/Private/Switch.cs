using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Private
{
    class Switch : ASystemPart
    {
        public override AFlow Flow
        {
            get
            {
                if (IsActivated)
                {
                    var partWithFlow = Input.FirstOrDefault(x => x.Flow != null);
                    if (partWithFlow != null)
                    {
                        return partWithFlow.Flow;
                    }
                }

                return null;
            }
        }

        public override bool IsActive
        {
            get { return IsActivated && Flow != null; }
        }
    }
}
