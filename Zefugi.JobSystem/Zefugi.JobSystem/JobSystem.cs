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
            _jobs.Add(action);
        }
    }
}
