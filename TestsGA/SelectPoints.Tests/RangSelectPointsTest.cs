﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.SelectPoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsGA
{
    [TestClass]
    public class RangSelectPointsTest
    {
        [TestMethod]
        public void SelectPoints_WithoutCoeffs()
        {
            ISelectPoints selectPoints = new RangSelectPoints();

            IChromosome chromo = new Chromosome(0, -5, 5, 2, "x");
            IChromosome chromo1 = new Chromosome(0, -5, 5, 4, "y");
            IChromosome chromo2 = new Chromosome(0, -5, 5, 3, "x");
            IChromosome chromo3 = new Chromosome(0, -5, 5, 6, "y");

            IDesignPoint designPoint = new DesignPoint(1, 1, new FuncCalculatorBasic("x+y"), chromo, chromo1);//6
            IDesignPoint designPoint1 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo2, chromo1);//7
            IDesignPoint designPoint2 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo, chromo3);//8
            IDesignPoint designPoint3 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo2, chromo3);//9

            IEnumerable<IDesignPoint> designPoints = new List<IDesignPoint>
            {
                designPoint1, designPoint, designPoint3, designPoint2
            };

            var result = selectPoints.SelectPoints(2, designPoints).ToList();
            var expected = new List<IDesignPoint>
            {
                designPoint, designPoint1
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SelectPoints_WithCoeff_2()
        {
            ISelectPoints selectPoints = new RangSelectPoints(2);

            IChromosome chromo = new Chromosome(0, -5, 5, 2, "x");
            IChromosome chromo1 = new Chromosome(0, -5, 5, 4, "y");
            IChromosome chromo2 = new Chromosome(0, -5, 5, 3, "x");
            IChromosome chromo3 = new Chromosome(0, -5, 5, 6, "y");

            IDesignPoint designPoint = new DesignPoint(1, 1, new FuncCalculatorBasic("x+y"), chromo, chromo1);//6
            IDesignPoint designPoint1 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo2, chromo1);//7
            IDesignPoint designPoint2 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo, chromo3);//8
            IDesignPoint designPoint3 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo2, chromo3);//9

            IEnumerable<IDesignPoint> designPoints = new List<IDesignPoint>
            {
                designPoint1, designPoint, designPoint3, designPoint2
            };

            var result = selectPoints.SelectPoints(4, designPoints).ToList();
            var expected = new List<IDesignPoint>
            {
                designPoint, designPoint, designPoint1, designPoint2
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SelectPoints_WithCoeff_2_2()
        {
            ISelectPoints selectPoints = new RangSelectPoints(2, 2);

            IChromosome chromo = new Chromosome(0, -5, 5, 2, "x");
            IChromosome chromo1 = new Chromosome(0, -5, 5, 4, "y");
            IChromosome chromo2 = new Chromosome(0, -5, 5, 3, "x");
            IChromosome chromo3 = new Chromosome(0, -5, 5, 6, "y");

            IDesignPoint designPoint = new DesignPoint(1, 1, new FuncCalculatorBasic("x+y"), chromo, chromo1);//6
            IDesignPoint designPoint1 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo2, chromo1);//7
            IDesignPoint designPoint2 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo, chromo3);//8
            IDesignPoint designPoint3 = new DesignPoint(1, 2, new FuncCalculatorBasic("x+y"), chromo2, chromo3);//9

            IEnumerable<IDesignPoint> designPoints = new List<IDesignPoint>
            {
                designPoint1, designPoint, designPoint3, designPoint2
            };

            var result = selectPoints.SelectPoints(4, designPoints).ToList();
            var expected = new List<IDesignPoint>
            {
                designPoint, designPoint, designPoint1, designPoint1
            };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
