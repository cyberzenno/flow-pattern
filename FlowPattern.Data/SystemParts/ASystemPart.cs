using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts
{
    public enum PartType
    {
        Unknown = 0,

        Generator,
        Switch,
        Bulb
    }

    public enum PartState
    {
        Unknown = 0,

        NotActivated,
        Activated
    }

    public abstract class ASystemPart
    {
        //Properties
        public string Id { get; set; }
        public PartType SystemPartType { get; set; }
        public PartState SystemPartState { get; set; }

        public IList<ASystemPart> Input { get; set; }
        public IList<ASystemPart> Output { get; set; }

        //Abstract Properties
        public abstract AFlow Flow { get; }

        //Constructor
        public ASystemPart()
        {
            Input = new List<ASystemPart>();
            Output = new List<ASystemPart>();
        }

        //Actions
        public void Activate()
        {
            SystemPartState = PartState.Activated;
        }

        //Queries
        public bool IsActivated
        {
            get
            {
                return SystemPartState == PartState.Activated;
            }
        }

        //Abstracts
        public abstract bool IsActive { get; }
    }
}
