using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Mutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestsGA
{
    [TestClass]
    public class MutationTest
    {
        [TestMethod]
        public void MutationCount()
        {
            var listDP = new List<IDesignPoint>();
            listDP.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDP.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 20, "X"), new Chromosome(0, 5, 20, 20, "Y")));
            listDP.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 15, "X"), new Chromosome(0, 5, 20, 15, "Y")));
            var mutation = new MutationBinary(80);

            mutation.Mutate(listDP);

            var expected = 3;
            Assert.AreEqual(mutation.AllDesignPoints.Count(), expected);
        }

        [TestMethod]
        public void MutationNumericCount()
        {
            var listDP = new List<IDesignPoint>();
            listDP.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("K+n"), new ChromosomeNumeric(15, 20, 18, "K"), new ChromosomeNumeric(5, 10, 9, "n")));
            listDP.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("k+s"), new ChromosomeNumeric(1, 5, 3, "k"), new ChromosomeNumeric(1, 2, 1, "s")));
            listDP.Add(new DesignPoint(1, 0, new FuncCalculatorBasic("k+Y"), new ChromosomeNumeric(1, 5, 4, "k"), new ChromosomeNumeric(1, 3, 2, "f")));
            var mutation = new MutationNumeric(80);

            mutation.Mutate(listDP);

            var expected = 3;
            Assert.AreEqual(mutation.AllDesignPoints.Count(), expected);
        }
    }
}
