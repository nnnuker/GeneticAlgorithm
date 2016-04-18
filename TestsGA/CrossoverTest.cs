using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.Crossover;
using System.Collections.Generic;
using System.Linq;

namespace TestsGA
{
    [TestClass]
    public class CrossoverTest
    {
        [TestMethod]
        public void OnePointCrossoverOnePair()
        {
            var firstDesignPoint = new DesignPoint(1, "X1+X2", new Chromosome(0.1, 1, 2, "11111", "X1"), new Chromosome(0.1, -3, 10, "0111", "X2"));
            var secondDesignPoint = new DesignPoint(1, "X1+X2", new Chromosome(0.1, 1, 2, "00000", "X1"), new Chromosome(0.1, -3, 10, "1000", "X2"));
            var pair = new Pair { First = firstDesignPoint, Second = secondDesignPoint };

            var crossoverobj = new OnePointCrossover(3);
            var result = crossoverobj.Crossover(pair);
           
            Assert.AreEqual(result.ElementAt(0).X1X2, "111001000");
        }

        [TestMethod]
        public void OnePointCrossoverTwoPair()
        {
            var listPair = new List<IPair>();
            listPair.Add(
                new Pair
                {
                    First = new DesignPoint(1, "X1+X2", new Chromosome(0.1, 1, 2, "11111", "X1"), new Chromosome(0.1, -3, 10, "0111", "X2")),
                    //Second = new DesignPoint(1, new Chromosome(0.1, 1, 2, "00000", "X1"), new Chromosome(0.1, -3, 10, "1000", "X2"))
                    Second = null
                });

            listPair.Add(
                new Pair
                {
                    First = new DesignPoint(1, "X1+X2", new Chromosome(0.1, 1, 2, "11", "X1"), new Chromosome(0.1, -3, 10, "0111", "X2")),
                    Second = new DesignPoint(1, "X1+X2", new Chromosome(0.1, 1, 2, "00", "X1"), new Chromosome(0.1, -3, 10, "1000", "X2"))
                });

            
            var crossoverobj = new OnePointCrossover(3);
            var result = crossoverobj.Crossover(listPair);

            Assert.AreEqual(result.ElementAt(0).X1X2, "111001000");
            Assert.AreEqual(result.ElementAt(2).X1X2, "110000");
        }
    }
}
