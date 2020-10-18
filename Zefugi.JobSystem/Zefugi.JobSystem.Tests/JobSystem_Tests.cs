using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem.Tests
{
    [TestFixture]
    public class JobSystem_Tests
    {
        [Test]
        public void Assign_MakesTheSpecifiedJobActionAvailableInJobs()
        {
            var jobs = new JobSystem();
            var action = new JobActionBase();
            jobs.Assign(action);

            Assert.IsTrue(jobs.Jobs.Contains(action));
        }
    }
}
