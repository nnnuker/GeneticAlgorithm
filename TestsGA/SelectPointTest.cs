using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.SelectPoints;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Chromosome;

namespace TestsGA
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SelectPointTest
    {
        [TestMethod]
        public void ClassicRouletteSelectPointsCountN()
        {
            var listDP = new List<IDesignPoint>();
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 20, "X"), new Chromosome(0, 5, 20, 20, "Y")));
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 15, "X"), new Chromosome(0, 5, 20, 15, "Y")));
            var classicRoulette = new ClassicRouletteSelectPoints();

            var expected = 2;

            Assert.AreEqual(expected, classicRoulette.SelectPoints(2, listDP).Count());
        }

        [TestMethod]
        public void RouletteSelectPointsCountN()
        {
            var listDP = new List<IDesignPoint>();
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 20, 15, "X"), new Chromosome(0, 5, 20, 10, "Y")));
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 20, "X"), new Chromosome(0, 5, 20, 20, "Y")));
            listDP.Add(new DesignPoint(1, new FuncCalculatorBasic("X+Y"), new Chromosome(0, 10, 30, 15, "X"), new Chromosome(0, 5, 20, 15, "Y")));
            var roulette = new RouletteSelectPoints();

            var expected = 3;

            Assert.AreEqual(expected, roulette.SelectPoints(3, listDP).Count());
        }
    }


}
