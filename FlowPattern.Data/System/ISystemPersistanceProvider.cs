using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.System
{
    public interface ISystemPersitanceProvider
    {
        void Save(List<ASystemPart> system, string name);

        List<ASystemPart> Load(string name);
    }
}
