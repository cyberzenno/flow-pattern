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
        [TestCase("0_generator_active", "0", PartType.Generator, PartState.Active)]
        public void Create(string input, string expId, PartType expType, PartState expState)
        {
            //ARRANGE

            //ACT
            var actual = systemPartFactory.Create("generator_0_active");

            //ASSERT
            Assert.AreEqual(expId, actual.Id);
            Assert.AreEqual(expType, actual.SystemPartType);
            Assert.AreEqual(expState, actual.SystemPartState);
        }
    }
}
