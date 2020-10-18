using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public class JobSystem
    {
        private List<JobActionBase> _jobs = new List<JobActionBase>();
        private JobActionBase _activeJob;

        public IReadOnlyList<JobActionBase> Jobs => _jobs.AsReadOnly();
        public JobActionBase ActiveJob => _activeJob;

        public void Assign(JobActionBase action)
        {
            _jobs.Add(action);
            action.Assign(this);
        }

        public void Cancel(JobActionBase action)
        {
            if (!_jobs.Contains(action))
                return;

            action.Cancel();
            _jobs.Remove(action);

            if(_activeJob == action)
                _activeJob = null;
        }

        public void Start(JobActionBase action)
        {
            if (_activeJob != null)
                Pause();

            if (!_jobs.Contains(action))
                Assign(action);

            _activeJob = action;
            action.Start();
        }

        public void Pause()
        {
            if (_activeJob == null)
                throw new JobSystemException("Can not pause while no job is active.");

            _activeJob.Pause();
            _activeJob = null;
        }

        public void Panic()
        {
            if (_activeJob == null)
                throw new JobSystemException("Can not panic while no job is active.");

            _activeJob.Panic();
            _activeJob = null;
        }

        public void Resume(JobActionBase action)
        {
            if (action.State != JobActionState.Paused)
                throw new JobSystemException("Can not resume a job action that is not paused.");

            if (!_jobs.Contains(action))
                Assign(action);

            if (_activeJob != null)
                _activeJob.Pause();

            _activeJob = action;
            action.Resume();
        }
    }
}
