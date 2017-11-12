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
        Light
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

        public Dictionary<string, string> Attributes { get; set; }

        //Abstract Properties
        public abstract AFlow Flow { get; }

        //Constructor
        public ASystemPart()
        {
            Input = new List<ASystemPart>();
            Output = new List<ASystemPart>();
            Attributes = new Dictionary<string, string>();
        }

        //Actions
        public virtual void Activate()
        {
            SystemPartState = PartState.Activated;
        }

        public virtual void Deactivate()
        {
            SystemPartState = PartState.NotActivated;
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
