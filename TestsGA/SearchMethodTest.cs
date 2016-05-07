using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.FuncCalculator.SearchMethods;

namespace TestsGA
{
    [TestClass]
    public class SearchMethodTest
    {
        [TestMethod]
        public void BestProbeMethodAll()
        {
            var startPoint = new Point(1, 0, new FuncCalculatorBasic("2*(Y-X^2)^2+100*(1-X)^2"), new Axis(0, 10, 20, 10, "X"),
                new Axis(0, 5, 20, 10, "Y"));

            var bp = new BestProbe(1, 2, 0.0001);
            IDesignPoint end;

            bp.CalculateMethodAll(startPoint, out end);

            var expected = end.PopulationNumber;
            Assert.AreEqual(startPoint.PopulationNumber, expected);
        }

        [TestMethod]
        public void BestProbeMethodOne()
        {
            var startPoint = new Point(1, 0, new FuncCalculatorBasic("2*(Y-X^2)^2+100*(1-X)^2"), new Axis(0, 10, 20, 10, "X"),
                new Axis(0, 5, 20, 10, "Y"));

            var bp = new BestProbe(1, 2, 0.0001);
            IDesignPoint end;

            bp.CalculateMethodOne(startPoint, out end);

            var expected = end.PopulationNumber;
            Assert.AreEqual(startPoint.PopulationNumber, expected);
        }

    }
}