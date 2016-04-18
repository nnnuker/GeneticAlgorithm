using System;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.PairFormation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGA
{
    [TestClass]
    public class OnePointCrossoverTest
    {
        [TestMethod]
        public void Crossover_OnePair()
        {
            IFuncCalculator funcCalulator = new FuncCalculatorBasic("x^2+y+z");
            DesignPoint DP1 = new DesignPoint(1, funcCalulator, new Chromosome(1, -3, 2, -2, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 0, "z"));

            DesignPoint DP2 = new DesignPoint(1, funcCalulator, new Chromosome(1, -3, 2, -2, "x"), new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 0, "z"));

            IPair pair = new Pair();
            pair.First = DP1;
            pair.Second = DP2;

            ICrossover crossover = new OnePointCrossover();

            crossover.Crossover(pair);
        }
    }
}
