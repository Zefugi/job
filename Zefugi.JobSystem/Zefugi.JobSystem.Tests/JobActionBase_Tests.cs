using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zefugi.JobSystem.Tests
{
    [TestFixture]
    public class JobActionBase_Tests
    {
        private JobActionBase _action;
        private JobSystem _jobs;

        [SetUp]
        public void SetUp()
        {
            _action = new JobActionBase();
            _jobs = new JobSystem();
        }

        [Test]
        public void Assign_SetsStateToAssigned()
        {
            _action.Assign(_jobs);

            Assert.AreEqual(JobActionState.Assigned, _action.State);
        }

        [Test]
        public void Assign_ThrowsIfAlreadyAssigned()
        {
            _action.Assign(_jobs);

            Assert.Throws<JobSystemException>(() => { _action.Assign(_jobs); });
        }

        [Test]
        public void Assign_SetsSystem()
        {
            _action.Assign(_jobs);

            Assert.AreEqual(_jobs, _action.System);
        }

        [Test]
        public void Cancel_SetsStateToUnassigned()
        {
            _action.Assign(_jobs);
            _action.Cancel();

            Assert.AreEqual(JobActionState.Unassigned, _action.State);
        }

        [Test]
        public void Cancel_ThrowsIfNotAssigned()
        {
            Assert.Throws<JobSystemException>(() => { _action.Cancel(); });
        }

        [Test] // TODO
        public void Cancel_SetsSystemToNull() { }

        [Test] // TODO
        public void Start_SetsStateToActive() { }

        [Test] // TODO
        public void Pause_SetsStateToPaused() { }

        [Test] // TODO
        public void Panic_SetsStateToPaused() { }

        [Test] // TODO
        public void Resume_SetsStateToActive() { }
    }
}
