using System;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGA
{
    [TestClass]
    public class FuncCalculatorTest
    {
        [TestMethod]
        public void CalculateFunc_BasicFunc()
        {
            IFuncCalculator funcCalulator = new FuncCalculatorBasic("x+y+z");
            var result = funcCalulator.CalculateFunc(new Chromosome(1, 1, 2, 1, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 3, "z"));
           
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void CalculateFunc_SpecificFunc()
        {
            IFuncCalculator funcCalulator = new FuncCalculatorBasic("x^2+y+z");

            var result = funcCalulator.CalculateFunc(
                new Chromosome(1, -3, 2, -2, "x"), 
                new Chromosome(1, 1, 2, 2, "y"), 
                new Chromosome(1, 1, 2, 3, "z"));

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Equals_Success()
        {
            IFuncCalculator funcCalulator = new FuncCalculatorBasic("x^2+y+z");
            IFuncCalculator funcCalulator1 = new FuncCalculatorBasic("x^2+y+z");

            Assert.AreEqual(true, funcCalulator.Equals(funcCalulator1));
        }

        [TestMethod]
        public void FuncCalculatorTruncationTestSearchAllPoints()
        {
            var calculator = new FuncCalculatorTruncation("2*(Y-X^2)^2+100*(1-X)^2", 0, 50, -50, 50, 1, 2, 0.0001, 0.00000001);
            var result = calculator.CalculateFunc(
                new ChromosomeNumeric(9, 20, 14, "N"),
                new ChromosomeNumeric(5, 15, 7, "n"),
                new ChromosomeNumeric(1, 2, 1, "population"),
                new ChromosomeNumeric(1, 4, 2, "selectStartPoints"),
                new ChromosomeNumeric(1, 2, 1, "searchMethod"),
                new ChromosomeNumeric(1, 2, 1, "search"),
                new ChromosomeNumeric(1, 4, 2, "selectOtherPoints")
                );
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void FuncCalculatorTruncationTestSearchOnePoint()
        {
            var calculator = new FuncCalculatorTruncation("2*(Y-X^2)^2+100*(1-X)^2", 0, 50, -50, 50, 1, 2, 0.0001, 0.00000001);
            var result = calculator.CalculateFunc(
                new ChromosomeNumeric(9, 20, 14, "N"),
                new ChromosomeNumeric(5, 15, 7, "n"),
                new ChromosomeNumeric(1, 2, 1, "population"),
                new ChromosomeNumeric(1, 4, 2, "selectStartPoints"),
                new ChromosomeNumeric(1, 2, 1, "searchMethod"),
                new ChromosomeNumeric(1, 2, 1, "search"),
                new ChromosomeNumeric(1, 4, 2, "selectOtherPoints")
                );
            Assert.IsTrue(result > 0);
        }
    }
}
