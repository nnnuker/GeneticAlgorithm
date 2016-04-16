using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Mutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGA
{
    [TestClass]
    public class MutationTest
    {
        [TestMethod]
        public void MutationCount()
        {
            var listDP = new List<IDesignPoint>();
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 20, "X"), new Chromosome(0, 5, 20, 20, "Y")));
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 15, "X"), new Chromosome(0, 5, 20, 15, "Y")));
            var mutation = new MutationBinary(50);

            Assert.AreEqual(mutation.Mutate(listDP).Count(), 3);

        }
    }
}
