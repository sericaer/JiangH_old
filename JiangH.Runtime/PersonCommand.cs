using JiangH.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace JiangH.Runtime
{
    public class PersonCommand : IPersonCommand
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string key { get; set; }

        public Func<bool> isValid { get; set; }


        public readonly IPerson owner;

        public IEnumerable<ICommandTarget> targets 
        { 
            get
            {
                if (def.getTargets == null)
                {
                    return null;
                }

                return def.getTargets(owner);
            }
        }

        private IPersonCommandDef def;

        public PersonCommand(IPerson owner, IPersonCommandDef def)
        {
            this.owner = owner;
            this.key = def.key;
            this.def = def;

            this.isValid = ()=>def.isValid(owner);
        }

        public void Do(IEnumerable<ICommandTarget> targets)
        {
            def.Do(owner, targets);
        }
    }

    public interface IPersonCommandDef
    {
        string key { get; }

        Func<IPerson, bool> isValid { get; }

        Func<IPerson, IEnumerable<ICommandTarget>> getTargets { get; }

        Action<IPerson, IEnumerable<ICommandTarget>> Do { get; }
    }

    public class PersonCommandDef : IPersonCommandDef
    {
        public Func<IPerson, bool> isValid { get; set; }

        public string key { get; set; }

        public Func<IPerson, IEnumerable<ICommandTarget>> getTargets { get; set; }

        public Action<IPerson, IEnumerable<ICommandTarget>> Do { get; set; }
    }
}
