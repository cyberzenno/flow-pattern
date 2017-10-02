using FlowPattern.Data.SystemParts.Private;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.SystemParts.Factories
{
    public interface ISystemPartFactory
    {
        ASystemPart Create(string type_id);
    }
}
