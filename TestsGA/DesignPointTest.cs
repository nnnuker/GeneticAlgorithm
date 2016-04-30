using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.FuncCalculator;

namespace TestsGA
{
    [TestClass]
    public class DesignPointTest
    {
        [TestMethod]
        public void FunctionValueTest()
        {
            IFuncCalculator funcCalulator = new FuncCalculatorBasic("x+y+z");
            IDesignPoint DP = new DesignPoint(1, 0, funcCalulator, new Chromosome(1, 1, 2, 1, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 3, "z"));
            Assert.AreEqual(DP.FunctionValue, 6);
        }

        [TestMethod]
        public void FunctionValue_SpecificFunc()
        {
            IFuncCalculator funcCalulator = new FuncCalculatorBasic("x^2+y+z");
            DesignPoint DP = new DesignPoint(1, 0, funcCalulator, new Chromosome(1, -3, 2, -2, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 3, "z"));
            Assert.AreEqual(DP.FunctionValue, 9);
        }
    }
}
