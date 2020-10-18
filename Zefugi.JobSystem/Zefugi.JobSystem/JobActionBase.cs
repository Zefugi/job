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
                throw new JobSystemException("Can not re-assign a job while it is assigned to a job system.");

            System = system;
            State = JobActionState.Assigned;
            OnAssigned();
        }

        public void Cancel()
        {
            if (State == JobActionState.Unassigned)
                throw new JobSystemException("Can not cancel an action that is not assigned.");

            System = null;
            State = JobActionState.Unassigned;
            OnCancel();
        }

        public void Start()
        {
            if (State == JobActionState.Unassigned)
                throw new JobSystemException("Can not start an action that has not been assigned to a job system.");
            if (State != JobActionState.Assigned)
                throw new JobSystemException("Can not start an action that is already active or paused.");

            State = JobActionState.Active;
            OnStart();
        }

        public void Pause()
        {
            if (State != JobActionState.Active)
                throw new JobSystemException("Can not pause an actions that is not active.");

            State = JobActionState.Paused;
            OnPause();
        }

        public void Panic()
        {
            if (State != JobActionState.Active)
                throw new JobSystemException("Can not panic an action that is not active.");

            State = JobActionState.Paused;
            OnPanic();
        }

        public void Resume()
        {
            if (State != JobActionState.Paused)
                throw new JobSystemException("Can not resume an action that is not paused.");

            State = JobActionState.Active;
            OnResume();
        }

        public void Update()
        {
            OnUpdate();
        }
    }
}
