﻿using NUnit.Framework;
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

        [Test] // TODO
        public void Assign_CallsOnAssigned() { }

        [Test] // TODO
        public void Assign_ThrowsIfAlreadyAssigned() { }

        [Test] // TODO
        public void Assign_SetsSystem() { }

        [Test] // TODO
        public void Cancel_SetsStateToCancelled() { }

        [Test] // TODO
        public void Cancel_ThrowsIfNotAssigned() { }

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
