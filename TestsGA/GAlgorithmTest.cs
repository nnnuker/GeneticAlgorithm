using System;
using System.Linq;
using GeneticAlgorithm;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.Descendants;
using GeneticAlgorithm.FactoryPoint;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Mutation;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.Population;
using GeneticAlgorithm.SelectPoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGA
{
    [TestClass]
    public class GAlgorithmTest
    {
        [TestMethod]
        public void MoveNext()
        {
            //Assert.Inconclusive();

            IFuncCalculator funcCalculator = new FuncCalculatorBasic("x+y");

            IFactoryPoints factoryPoint = new CreateDesignPoint(funcCalculator);

            IChromosome chromoX = new Chromosome(1, -4, 4, 0, "x");
            IChromosome chromoY = new Chromosome(1, -10, 10, 0, "y");

            IPopulation population = new RandomPopulation(factoryPoint, 10, 1, chromoX, chromoY);

            ISelectPoints selectPoints = new ClassicRouletteSelectPoints();

            ICrossover crossover = new OnePointCrossover();
            IMutation mutation = new MutationBinary(10);
            IPairFormation pairFormation = new RandomPairFormation();

            IDescendants descendants = new CrossoverMutation(crossover, mutation, pairFormation,
                CrossoverMutation.ParentDescendants);

            GAlgorithm ga = new GAlgorithm(10, 50, population, selectPoints, descendants);

            ga.MoveNext();

            var result = ga.ListOfAllDesignPoints;

            Assert.AreEqual(20, result.Count());
        }

        [TestMethod]
        public void MoveToEnd()
        {
            //Assert.Inconclusive();

            IFuncCalculator funcCalculator = new FuncCalculatorBasic("x+y");

            IFactoryPoints factoryPoint = new CreateDesignPoint(funcCalculator);

            IChromosome chromoX = new Chromosome(1, -4, 4, 0, "x");
            IChromosome chromoY = new Chromosome(1, -10, 10, 0, "y");

            IPopulation population = new RandomPopulation(factoryPoint, 20, 1, chromoX, chromoY);

            ISelectPoints selectPoints = new ClassicRouletteSelectPoints();

            ICrossover crossover = new OnePointCrossover();
            IMutation mutation = new MutationBinary(10);
            IPairFormation pairFormation = new RandomPairFormation();

            IDescendants descendants = new CrossoverMutation(crossover, mutation, pairFormation,
                CrossoverMutation.ParentDescendants);

            GAlgorithm ga = new GAlgorithm(10, 80, population, selectPoints, descendants);

            ga.MoveToEnd();

            var result = ga.ListOfAllDesignPoints;

            //Assert.AreEqual(20, result.Count());
        }
    }
}
