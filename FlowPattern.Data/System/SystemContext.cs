using FlowPattern.Data.System.Persistence;
using FlowPattern.Data.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.Data.System
{
    public class SystemContext
    {
        ISystemPersitanceProvider presistanceProvider;

        public string Name { get; set; }
        public List<ASystemPart> System { get; set; }

        public SystemContext(string systemName, ISystemPersitanceProvider persistanceProvider)
        {
            presistanceProvider = persistanceProvider;
            Name = systemName;
            System = persistanceProvider.Load(systemName);
        }

        public void Save()
        {
            presistanceProvider.Save(System, Name);
        }
        public void Save(string name)
        {
            Name = name;
            presistanceProvider.Save(System, name);
        }

        public void Load()
        {
            System = presistanceProvider.Load(Name);
        }
        public void Load(string name)
        {
            Name = name;
            System = presistanceProvider.Load(name);
        }

        public void ExecuteAction(string id, string action)
        {
            switch (action)
            {
                case "activate":
                    Activate(id);
                    break;

                case "deactivate":
                    Deactivate(id);
                    break;

                case "toggle":
                    Toggle(id);
                    break;

                default:
                    throw new Exception("action " + action + "doesn't exist");
            }
        }
        public void Activate(string id)
        {
            var element = System.FirstOrDefault(s => s.Id == id);

            if (element != null)
            {
                element.Activate();
                return;
            }

            throw new Exception("System Part " + id + " doesn't exist");
        }
        public void Deactivate(string id)
        {
            var element = System.FirstOrDefault(s => s.Id == id);

            if (element != null)
            {
                element.Deactivate();
                return;
            }

            throw new Exception("System Part " + id + " doesn't exist");
        }
        public void Toggle(string id)
        {
            var element = System.FirstOrDefault(s => s.Id == id);

            if (element != null)
            {
                if (element.IsActivated)
                {
                    element.Deactivate();
                }
                else
                {
                    element.Activate();
                }

                return;
            }

            throw new Exception("System Part " + id + " doesn't exist");
        }

        public bool IsActive(string id)
        {
            var element = System.FirstOrDefault(s => s.Id == id);
            if (element != null)
            {
                return element.IsActive;
            }

            throw new Exception("System Part " + id + " doesn't exist");
        }
        public void ActivateAll()
        {
            System.ForEach(x => x.Activate());
        }
        public void DeactivateAll()
        {
            System.ForEach(x => x.Deactivate());
        }
    }
}
