using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts
{
    public enum PartType
    {
        Generator
    }

    public enum PartState
    {
        Activated
    }

    public abstract class ASystemPart
    {
        //Properties
        public string Id { get; set; }
        public PartType Type { get; set; }
        public PartState State { get; set; }

        public ASystemPart[] Input { get; set; }
        public ASystemPart[] Output { get; set; }

        //Abstract Properties
        public abstract AFlow Flow { get; }

        //Queries
        public bool IsActivated
        {
            get
            {
                return State == PartState.Activated;
            }
        }
    }

}
