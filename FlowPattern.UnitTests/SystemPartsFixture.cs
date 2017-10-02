﻿using FlowPattern.Data.SystemParts;
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
    class SystemPartsFixture
    {
        private ISystemPartFactory systemPartFactory;

        [SetUp]
        public void Setup()
        {
            systemPartFactory = new SystemPartFactory();
        }

        [Test]
        [TestCase("0000", "0000")]
        [TestCase("1111", "1111")]
        [TestCase("1011", "1000")]
        [TestCase("1101", "1100")]
        [TestCase("1110", "1110")]
        public void SimpleSystem(string pseudoScenario, string expectedPseudoScenario)
        {
            //ARRANGE
            var generator = systemPartFactory.Create("generator_0");
            var switch0 = systemPartFactory.Create("switch_0");
            var switch1 = systemPartFactory.Create("switch_1");
            var bulb = systemPartFactory.Create("bulb_0");

            switch0.Input.Add(generator);
            switch1.Input.Add(switch0);
            bulb.Input.Add(switch1);

            //ACT
            if (pseudoScenario[0] == '1') generator.Activate();
            if (pseudoScenario[1] == '1') switch0.Activate();
            if (pseudoScenario[2] == '1') switch1.Activate();
            if (pseudoScenario[3] == '1') bulb.Activate();

            //ASSERT
            AssertIsActive(expectedPseudoScenario[0], generator);
            AssertIsActive(expectedPseudoScenario[1], switch0);
            AssertIsActive(expectedPseudoScenario[2], switch1);
            AssertIsActive(expectedPseudoScenario[3], bulb);
        }

        private void AssertIsActive(char c, ASystemPart part)
        {
            if (c == '1')
            {
                Assert.IsTrue(part.IsActive);
            }
            else
            {
                Assert.IsFalse(part.IsActive);
            }
        }
    }
}