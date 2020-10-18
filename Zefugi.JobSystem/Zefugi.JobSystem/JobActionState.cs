using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public enum JobActionState
    {
        Unassigned,
        Assigned,
        Active,
        Paused,
        Completed,
    }
}
