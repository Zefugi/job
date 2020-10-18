using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public class JobActionBase
    {
        public JobSystem System { get; internal set; }

        public virtual void OnAssigned() { }
        public virtual void OnCancel() { }
        public virtual void OnStart() { }
        public virtual void OnPause() { }
        public virtual void OnPanic() { }
        public virtual void OnResume() { }
        public virtual JobActionBase OnUpdate() { return null; }
    }
}
