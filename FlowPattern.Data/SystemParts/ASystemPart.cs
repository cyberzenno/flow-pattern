using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts
{
    public enum PartType
    {
        Generator,

        Unknown = 0
    }

    public enum PartState
    {
        NotActive,
        Active,

        Unknown = 0
    }

    public abstract class ASystemPart
    {
        //Properties
        public string Id { get; set; }
        public PartType SystemPartType { get; set; }
        public PartState SystemPartState { get; set; }

        public ASystemPart[] Input { get; set; }
        public ASystemPart[] Output { get; set; }

        //Abstract Properties
        public abstract AFlow Flow { get; }

        //Queries
        public bool IsActivated
        {
            get
            {
                return SystemPartState == PartState.Active;
            }
        }
        public bool Is(PartType type)
        {
            return SystemPartType == type;
        }
        public bool Is(PartState state)
        {
            return SystemPartState == state;
        }
    }

}
