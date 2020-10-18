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
        // TODO Assign also triggers OnAssigned

        // TODO Cancel removes the action from Jobs and CurrentJob
        // TODO Cancel also triggers OnCancel

        // TODO Start pauses the current action and makes the new action current.
        // TODO Start also triggers OnStart

        // TODO Pause clears the current action.
        // TODO Pause also triggers OnPause

        // TODO Panic clears the current action.
        // TODO Panic also triggers OnPanic.

        // TODO Resume pauses the current action and sets a new current.
        // TODO Resume also triggers OnResume.

        // TODO Update triggers OnUpdate.
    }
}
