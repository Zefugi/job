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

        [Test]
        public void Cancel_SetsSystemToNull()
        {
            _action.Assign(_jobs);
            _action.Cancel();

            Assert.IsNull(_action.System);
        }

        [Test]
        public void Start_SetsStateToActive()
        {
            _action.Assign(_jobs);
            _action.Start();

            Assert.AreEqual(JobActionState.Active, _action.State);
        }

        [Test]
        public void Start_ThrowsIfNotAssignedOrAlredyActive()
        {
            Assert.Throws<JobSystemException>(() => { _action.Start(); });
            _action.Assign(_jobs);
            _action.Start();
            Assert.Throws<JobSystemException>(() => { _action.Start(); });
        }

        [Test]
        public void Pause_SetsStateToPaused()
        {
            _action.Assign(_jobs);
            _action.Start();
            _action.Pause();

            Assert.AreEqual(JobActionState.Paused, _action.State);
        }

        [Test]
        public void Pause_ThrowsIfNotActive()
        {
            _action.Assign(_jobs);
            Assert.Throws<JobSystemException>(() => { _action.Pause(); });
        }

        [Test]
        public void Panic_SetsStateToPaused()
        {
            _action.Assign(_jobs);
            _action.Start();
            _action.Panic();

            Assert.AreEqual(JobActionState.Paused, _action.State);
        }

        [Test]
        public void Panic_ThrowsIfNotActive()
        {
            _action.Assign(_jobs);
            Assert.Throws<JobSystemException>(() => { _action.Panic(); });
        }

        [Test]
        public void Resume_SetsStateToActive()
        {
            _action.Assign(_jobs);
            _action.Start();
            _action.Pause();
            _action.Resume();

            Assert.AreEqual(JobActionState.Active, _action.State);
        }

        [Test]
        public void Resume_ThrowsIfNotPaused()
        {
            _action.Assign(_jobs);

            Assert.Throws<JobSystemException>(() => { _action.Resume(); });

            _action.Start();

            Assert.Throws<JobSystemException>(() => { _action.Resume(); });
        }
    }
}
