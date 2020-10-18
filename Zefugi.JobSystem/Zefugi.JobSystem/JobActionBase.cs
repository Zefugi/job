using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public class JobActionBase
    {
        protected virtual void OnAssigned() { }
        protected virtual void OnCancel() { }
        protected virtual void OnStart() { }
        protected virtual void OnPause() { }
        protected virtual void OnPanic() { }
        protected virtual void OnResume() { }
        protected virtual JobActionBase OnUpdate() { return null; }
    }
}
