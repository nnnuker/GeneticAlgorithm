using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Chromosome;

namespace TestsGA
{
    [TestClass]
    public class DesignPointTest
    {
        [TestMethod]
        public void FunctionValueTest()
        {
            DesignPoint DP = new DesignPoint(1, "x+y+z", new Chromosome(1, 1, 2, 1, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 3, "z"));
            Assert.AreEqual(DP.FunctionValue, 6);
        }

        [TestMethod]
        public void FunctionValue_SpecificFunc()
        {
            DesignPoint DP = new DesignPoint(1, "x^2+y+z", new Chromosome(1, -3, 2, -2, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 3, "z"));
            Assert.AreEqual(DP.FunctionValue, 9);
        }
    }
}
