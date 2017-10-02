using FlowPattern.Data.System;
using FlowPattern.Data.System.Persistence;
using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FlowPattern.Web.Models.SystemModels
{
    public class SessionPersistenceProvider : ISystemPersitanceProvider
    {
        HttpSessionStateBase session;

        public SessionPersistenceProvider(HttpSessionStateBase _session)
        {
            session = _session;
        }

        public void Save(List<ASystemPart> system, string name)
        {
            session[name] = system;
        }

        public List<ASystemPart> Load(string name)
        {
            var system = session[name] as List<ASystemPart>;

            if (system == null)
            {
                system = new List<ASystemPart>();
            }

            return system;
        }
    }
}
