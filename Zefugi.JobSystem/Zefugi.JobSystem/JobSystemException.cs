using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem
{
    public class JobSystemException : Exception
    {
        public JobSystemException(string message) : base(message) { }
    }
}
