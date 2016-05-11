using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.PairFormation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGA.PairFormation.Tests
{
    [TestClass]
    public class BestWorsePairFormationTest
    {
        [TestMethod]
        public void FormatPairs_Count()
        {
            var randomPF = new BestWorsePairFormation();

            List<DesignPoint> listDesignPoint = new List<DesignPoint>
            {
                new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"),
                    new Chromosome(0, 5, 20, 10, "Y")),
                new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"),
                    new Chromosome(0, 5, 20, 10, "Y")),
                new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"),
                    new Chromosome(0, 5, 20, 10, "Y")),
                new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"),
                    new Chromosome(0, 5, 20, 10, "Y")),
                new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"),
                    new Chromosome(0, 5, 20, 10, "Y"))
            };

            IEnumerable<IPair> listResult = randomPF.FormatPairs(listDesignPoint);
            Assert.AreEqual(listResult.Count(), 3, "Count pairs not equal");
        }

        [TestMethod]
        public void FormatPairs_Contains()
        {
            var randomPF = new BestWorsePairFormation();

            IFuncCalculator funcCalculator = new FuncCalculatorBasic("x+y");

            IChromosome chromo = new Chromosome(0, -5, 5, 2, "x");
            IChromosome chromo1 = new Chromosome(0, -5, 5, 4, "y");
            IChromosome chromo2 = new Chromosome(0, -5, 5, 3, "x");
            IChromosome chromo3 = new Chromosome(0, -5, 5, 6, "y");

            IDesignPoint designPoint = new DesignPoint(1, 1, funcCalculator, chromo, chromo1);//6
            IDesignPoint designPoint1 = new DesignPoint(1, 2, funcCalculator, chromo2, chromo1);//7
            IDesignPoint designPoint2 = new DesignPoint(1, 2, funcCalculator, chromo, chromo3);//8
            IDesignPoint designPoint3 = new DesignPoint(1, 2, funcCalculator, chromo2, chromo3);//9

            IEnumerable<IDesignPoint> designPoints = new List<IDesignPoint>
            {
                designPoint1, designPoint, designPoint3, designPoint2
            };

            IPair pair = new Pair
            {
                First = designPoint,
                Second = designPoint3
            };

            IPair pair1 = new Pair
            {
                First = designPoint1,
                Second = designPoint2
            };

            IEnumerable<IPair> listResult = randomPF.FormatPairs(designPoints);
            Assert.AreEqual(true, pair.Equals(listResult.ElementAt(0)));
            Assert.AreEqual(true, pair1.Equals(listResult.ElementAt(1)));
        }

        [TestMethod]
        public void FormatPairs3_Contains()
        {
            var randomPF = new BestWorsePairFormation();

            IFuncCalculator funcCalculator = new FuncCalculatorBasic("x+y");

            IChromosome chromo = new Chromosome(0, -5, 5, 2, "x");
            IChromosome chromo1 = new Chromosome(0, -5, 5, 4, "y");
            IChromosome chromo2 = new Chromosome(0, -5, 5, 3, "x");
            IChromosome chromo3 = new Chromosome(0, -5, 5, 6, "y");

            IDesignPoint designPoint = new DesignPoint(1, 1, funcCalculator, chromo, chromo1);//6
            IDesignPoint designPoint1 = new DesignPoint(1, 2, funcCalculator, chromo2, chromo1);//7
            IDesignPoint designPoint3 = new DesignPoint(1, 2, funcCalculator, chromo2, chromo3);//9

            IEnumerable<IDesignPoint> designPoints = new List<IDesignPoint>
            {
                designPoint1, designPoint, designPoint3
            };

            IPair pair = new Pair
            {
                First = designPoint,
                Second = designPoint3
            };

            IPair pair1 = new Pair
            {
                First = designPoint1,
                Second = null
            };

            IEnumerable<IPair> listResult = randomPF.FormatPairs(designPoints);
            Assert.AreEqual(true, pair.Equals(listResult.ElementAt(0)));
            Assert.AreEqual(true, pair1.Equals(listResult.ElementAt(1)));
        }
    }
}
