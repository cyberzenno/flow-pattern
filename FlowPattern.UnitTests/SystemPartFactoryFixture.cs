using FlowPattern.Data.SystemParts;
using FlowPattern.Data.SystemParts.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPattern.UnitTests
{
    [TestFixture]
    class SystemPartFactoryFixture
    {
        private ISystemPartFactory systemPartFactory;

        [SetUp]
        public void Setup()
        {
            systemPartFactory = new SystemPartFactory();
        }

        [Test]
        [TestCase("foo_0", "Unknown", PartType.Unknown, PartState.Unknown)]
        [TestCase("generator_0", "0", PartType.Generator, PartState.NotActivated)]
        [TestCase("SWITCH_0", "0", PartType.Switch, PartState.NotActivated)]
        [TestCase("bulb_0", "0", PartType.Bulb, PartState.NotActivated)]
        public void Create(string input, string expId, PartType expType, PartState expState)
        {
            //ARRANGE

            //ACT
            var actual = systemPartFactory.Create(input);

            //ASSERT
            Assert.AreEqual(expId, actual.Id);
            Assert.AreEqual(expType, actual.SystemPartType);
            Assert.AreEqual(expState, actual.SystemPartState);
        }
    }
}
