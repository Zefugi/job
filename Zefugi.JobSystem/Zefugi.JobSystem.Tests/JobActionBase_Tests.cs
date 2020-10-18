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
        [Test] // TODO
        public void Assign_SetsStateToAssigned() { }

        [Test] // TODO
        public void Assign_ThrowsIfAlreadyAssigned() { }

        [Test] // TODO
        public void Cancel_SetsStateToCancelled() { }

        [Test] // TODO
        public void Cancel_ThrowsIfNotAssigned() { }

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
