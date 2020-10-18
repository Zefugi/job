using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public class JobSystem
    {
        private List<JobActionBase> _jobs = new List<JobActionBase>();
        private JobActionBase _currentJob;

        public IReadOnlyList<JobActionBase> Jobs => _jobs.AsReadOnly();
        public JobActionBase CurrentJob => _currentJob;

        public void Assign(JobActionBase action)
        {
            action.System = this;
            _jobs.Add(action);
            action.OnAssigned();
        }

        public void Cancel(JobActionBase action)
        {
            if (!_jobs.Contains(action))
                return;

            action.OnCancel();
            action.System = null;
            _jobs.Remove(action);

            if(_currentJob == action)
                _currentJob = null;
        }
    }
}
