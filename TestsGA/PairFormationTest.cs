using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithm.PairFormation;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.Chromosome;
using System.Collections.Generic;

namespace TestsGA
{
    [TestClass]
    public class PairFormationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pp = new RandomPairFormation();

            List<DesignPoint> dd = new List<DesignPoint>();
            Chromosome hr = new Chromosome(1, 1, 1, "");
            DesignPoint dss = new DesignPoint(1, 1, hr);
            dd.Add(new DesignPoint(1, 1, new Chromosome(1, 1, 1, "s")));
            dd.Add(new DesignPoint(1, 2, new Chromosome(1, 1, 1, "s")));
            dd.Add(new DesignPoint(1, 3, new Chromosome(1, 1, 1, "s")));

            List<Pair> list = (List<Pair>)pp.FormatPairs(dd);
            Assert.AreEqual(list.Count, 2);
        }
    }
}
