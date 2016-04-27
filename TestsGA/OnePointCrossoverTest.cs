﻿using System.Linq;
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

            DesignPoint DP1 = new DesignPoint(1, funcCalulator, new Chromosome(1, -3, 2, -2, "x"), 
                new Chromosome(1, 1, 2, 2, "y"), new Chromosome(1, 1, 2, 0, "z"));

            DesignPoint DP2 = new DesignPoint(1, funcCalulator, new Chromosome(1, -3, 2, 0, "x"), 
                new Chromosome(1, 1, 2, 1.5, "y"), new Chromosome(1, 1, 2, 0, "z"));

            IPair pair = new Pair
            {
                First = DP1,
                Second = DP2
            };

            int index = 4;

            ICrossover crossover = new OnePointCrossover(index);

            var result = crossover.Crossover(pair);

            var list = result.ToList();

            CollectionAssert.AreEqual(DP1.X1X2.ToList().GetRange(0, index), list[0].X1X2.ToList().GetRange(0, index));
            CollectionAssert.AreEqual(DP2.X1X2.ToList().GetRange(index, DP2.X1X2.Count() - index), 
                list[0].X1X2.ToList().GetRange(index, DP2.X1X2.Count() - index));

            CollectionAssert.AreEqual(DP2.X1X2.ToList().GetRange(0, index), list[1].X1X2.ToList().GetRange(0, index));
            CollectionAssert.AreEqual(DP1.X1X2.ToList().GetRange(index, DP1.X1X2.Count() - index),
                list[1].X1X2.ToList().GetRange(index, DP1.X1X2.Count() - index));
        }
    }
}
