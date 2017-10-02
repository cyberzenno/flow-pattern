using FlowPattern.Data.System.Builders;
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
    class SystemBuilderFixture
    {
        private ISystemPartFactory systemPartFactory;
        private SystemBuilder systemBuilder;

        [SetUp]
        public void Setup()
        {
            systemPartFactory = new SystemPartFactory();
            systemBuilder = new SystemBuilder(systemPartFactory);
        }

        [Test]
        public void SingleConnections()
        {
            //ARRANGE
            var x = "generator_x";
            var y = "switch_y";
            var z = "bulb_z";

            systemBuilder.AddPart(x);
            systemBuilder.AddPart(y);
            systemBuilder.AddPart(z);

            //ACT
            systemBuilder.ConnectParts(x + " > " + y);
            systemBuilder.ConnectParts(y + " > " + z);

            var generator_x = systemBuilder.GetById(x);
            var switch_y = systemBuilder.GetById(y);
            var bulb_z = systemBuilder.GetById(z);

            //ASSERT

            //x input from none
            Assert.AreEqual(0, generator_x.Input.Count);

            //x output to y
            Assert.AreEqual(y, generator_x.Output[0].Id);

            //y input from x
            Assert.AreEqual(x, switch_y.Input[0].Id);
            
            //y output to z
            Assert.AreEqual(z, switch_y.Output[0].Id);

            //z input from y
            Assert.AreEqual(y, bulb_z.Input[0].Id);

            //z output to none
            Assert.AreEqual(0, bulb_z.Output.Count);

        }
    }
}
