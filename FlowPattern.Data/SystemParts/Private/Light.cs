using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Private
{
    /// <summary>
    /// The Light State is always Activated. The interactioncan be done only via Switch
    /// </summary>
    class Light : ASystemPart
    {
        public Light()
        {
            SystemPartState = PartState.Activated;
        }

        public override AFlow Flow
        {
            get
            {
                //note: for the moment we assume that the light has no state and therefore is always activated
                if (true)//if (IsActivated)
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

        public override void Activate()
        {
            //do nothing
        }

        public override void Deactivate()
        {
            //do nothing
        }

        public override bool IsActive
        {
            //get { return IsActivated && Flow != null; }
            get { return Flow != null; }
        }
    }
}
