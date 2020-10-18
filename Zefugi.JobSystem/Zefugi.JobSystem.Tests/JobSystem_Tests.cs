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
        private JobSystem _jobs;
        private JobActionBase _action;
        private JobActionBase _secondAction;

        [SetUp]
        public void SetUp()
        {
            _jobs = new JobSystem();
            _action = Substitute.For<JobActionBase>();
            _secondAction = Substitute.For<JobActionBase>();
        }

        [Test]
        public void Assign_MakesTheSpecifiedJobActionAvailableInJobs()
        {
            _jobs.Assign(_action);

            Assert.IsTrue(_jobs.Jobs.Contains(_action));
        }
        
        [Test]
        public void Assign_TriggersAssigned()
        {
            _jobs.Assign(_action);

            _action.Received().Assign(_jobs);
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
        public void Cancel_TriggersCancel()
        {
            _jobs.Assign(_action);
            _jobs.Cancel(_action);

            _action.Received().Cancel();
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

        [Test]
        public void Start_TriggersStart()
        {
            _jobs.Assign(_action);
            _jobs.Start(_action);

            _action.Received().Start();
            Assert.AreEqual(_action, _jobs.CurrentJob);
        }

        [Test]
        public void Start_PausesTheCurrentTask()
        {
            _jobs.Assign(_action);
            _jobs.Start(_action);
            _jobs.Start(_secondAction);

            _action.Received().Pause();
        }

        [Test]
        public void Start_AddsTheNewActionAndTriggersAssign_IfNotAlreadyAdded()
        {
            _jobs.Start(_action);

            Assert.IsTrue(_jobs.Jobs.Contains(_action));
            _action.Received().Assign(_jobs);
        }

        [Test]
        public void Pause_ClearTheCurrentAction()
        {
            _jobs.Start(_action);
            _jobs.Pause();

            Assert.IsNull(_jobs.CurrentJob);
        }

        [Test]
        public void Pause_CallsPause()
        {
            _jobs.Start(_action);
            _jobs.Pause();

            _action.Received().Pause();
        }

        [Test]
        public void Pause_ThrowsJobSystemException_IfNoJobIsActive()
        {
            Assert.Throws<JobSystemException>(() => { _jobs.Pause(); });
        }

        [Test]
        public void Panic_ClearsTheCurrentAction()
        {
            _jobs.Start(_action);
            _jobs.Panic();

            Assert.IsNull(_jobs.CurrentJob);
        }

        [Test]
        public void Panic_TriggersPanic()
        {
            _jobs.Start(_action);
            _jobs.Panic();

            _action.Received().Panic();
        }

        [Test]
        public void Panic_ThrowsJobSystemException_IfNoJobIsActive()
        {
            Assert.Throws<JobSystemException>(_jobs.Panic);
        }

        [Test]
        public void Resume_PausesTheCurrentActionAndSetsTheNewCurrent()
        {
            _jobs.Start(_action);
            _jobs.Pause();
            _jobs.Start(_secondAction);
            _jobs.Resume(_action);

            _secondAction.Received().Pause();
            _action.Received().Resume();
            Assert.AreEqual(_action, _jobs.CurrentJob);
        }
        // TODO Resume also triggers Resume.
        // TODO Throws a JobSystemException if action is not paused.

        // TODO Update triggers Update.
    }
}
