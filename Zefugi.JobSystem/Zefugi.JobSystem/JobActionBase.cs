using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public class JobActionBase
    {
        public JobActionState State { get; private set; } = JobActionState.Unassigned;
        public JobSystem System { get; private set; }

        protected virtual void OnAssigned() { }
        protected virtual void OnCancel() { }
        protected virtual void OnStart() { }
        protected virtual void OnPause() { }
        protected virtual void OnPanic() { }
        protected virtual void OnResume() { }
        protected virtual JobActionBase OnUpdate() { return null; }

        public void Assign(JobSystem system)
        {
            if (State != JobActionState.Unassigned)
                throw new JobSystemException("Can't re-assign a job while it is assigned to a job system.");

            System = system;
            State = JobActionState.Assigned;
        }

        public void Cancel() { }

        public void Start() { }

        public void Pause() { }

        public void Panic() { }

        public void Resume() { }

        public void Update() { }
    }
}
