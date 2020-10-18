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
    public class JobSystem_Tests
    {
        private JobSystem _jobs = new JobSystem();
        private JobActionBase _action = new JobActionBase();

        [TearDown]
        public void TearDown()
        {
            _jobs = new JobSystem();
            _action = Substitute.For<JobActionBase>();
        }

        [Test]
        public void Assign_MakesTheSpecifiedJobActionAvailableInJobs()
        {
            _jobs.Assign(_action);

            Assert.IsTrue(_jobs.Jobs.Contains(_action));
        }
        
        [Test]
        public void Assign_TriggersOnAssigned()
        {
            _jobs.Assign(_action);

            _action.Received().OnAssigned();
        }

        [Test]
        public void Cancel_RemovesActionFromJobsAndCurrentJob()
        {
            _jobs.Assign(_action);
            _jobs.Cancel(_action);

            Assert.IsFalse(_jobs.Jobs.Contains(_action));
            Assert.IsNull(_jobs.CurrentJob);
        }

        [Test]
        public void Cancel_TriggersOnCancel()
        {
            _jobs.Assign(_action);
            _jobs.Cancel(_action);

            _action.Received().OnCancel();
        }

        [Test] // TODO
        public void Cancel_ClearsCurrentJob_OnlyIfCurrentIsThisAction()
        {
        }

        [Test]
        public void Start_MakesNewActionCurrent()
        {
            _jobs.Assign(_action);
            _jobs.Start(_action);

            Assert.AreEqual(_action, _jobs.CurrentJob);
        }
        // TODO Start also triggers OnStart
        // TODO Start pauses the current action.
        // TODO Start adds the new action if it is not already added.

        // TODO Pause clears the current action.
        // TODO Pause also triggers OnPause

        // TODO Panic clears the current action.
        // TODO Panic also triggers OnPanic.

        // TODO Resume pauses the current action and sets a new current.
        // TODO Resume also triggers OnResume.

        // TODO Update triggers OnUpdate.
    }
}
