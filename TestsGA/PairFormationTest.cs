using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Chromosome;
using System.Collections.Generic;
using System.Linq;

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

            listDesignPoint.Add(new DesignPoint(1, 0, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 1, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 2, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 3, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 4, new Chromosome(1, 1, 1, "s")));

            IEnumerable<IPair> listResult = randomPF.FormatPairs(listDesignPoint);
            Assert.AreEqual(listResult.Count(), 3, "Count pairs not equal");
        }

        [TestMethod]
        public void RandomPairFormationConsistDesignPoints()
        {
            var randomPF = new RandomPairFormation();

            List<DesignPoint> listDesignPoint = new List<DesignPoint>();

            listDesignPoint.Add(new DesignPoint(1, 0, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 1, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 2, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 3, new Chromosome(1, 1, 1, "s")));
            listDesignPoint.Add(new DesignPoint(1, 4, new Chromosome(1, 1, 1, "s")));

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
