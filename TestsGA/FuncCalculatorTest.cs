using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.FuncCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestsGA
{
    [TestClass]
    public class FuncCalculatorTest
    {
        [TestMethod]
        public void FuncCalculatorTruncationTest()
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
            Assert.IsTrue(result>0);
        }
    }
}
