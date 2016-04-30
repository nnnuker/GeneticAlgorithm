using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Chromosome;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.FuncCalculator;

namespace TestsGA
{
    [TestClass]
    public class PairFormationTest
    {
        [TestMethod]
        public void RandomPairFormationCountPairs()
        {
            var randomPF = new RandomPairFormation();

            List<DesignPoint> listDesignPoint = new List<DesignPoint>();

            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));


            IEnumerable<IPair> listResult = randomPF.FormatPairs(listDesignPoint);
            Assert.AreEqual(listResult.Count(), 3, "Count pairs not equal");
        }

        [TestMethod]
        public void RandomPairFormationConsistDesignPoints()
        {
            var randomPF = new RandomPairFormation();

            List<DesignPoint> listDesignPoint = new List<DesignPoint>();

            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDesignPoint.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));


            IEnumerable<IPair> listResult = randomPF.FormatPairs(listDesignPoint);

            int numberConsist = 0;

            foreach (var itemListResult in listResult)
            {
                foreach (var itemListDesignPoint in listDesignPoint)
                {
                    if (itemListResult.First == itemListDesignPoint || itemListResult.Second == itemListDesignPoint)
                    {
                        numberConsist++;
                    }
                }
            }

            Assert.AreEqual(numberConsist, listDesignPoint.Count, "Count numer consist not equal");
        }
    }
}
