using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Chromosome;

namespace TestsGA
{
    [TestClass]
    public class ChromosomeTest
    {
        [TestMethod]
        public void BinaryFormat()
        {
            IChromosome chromosome = new Chromosome(1, -5, 5, 2.2, "x");
            List<byte> expected = new List<byte> { 1, 0, 0, 1, 0, 0, 0, 1, 0 };
            CollectionAssert.AreEqual(expected, chromosome.Binary.ToList());
        }

        [TestMethod]
        public void BinaryFormatMinus()
        {
            IChromosome chromosome = new Chromosome(1, -6, 5, -5.5, "X");
            List<byte> expected = new List<byte> { 0, 0, 1, 0, 1, 0, 1, 0, 1 };

            CollectionAssert.AreEqual(expected, chromosome.Binary.ToList());
        }

        [TestMethod]
        public void BigNumber()
        {
            IChromosome chromosome = new Chromosome(1, -35, 4, -5.5, "X");
            List<byte> expected = new List<byte> { 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1 };

            CollectionAssert.AreEqual(expected, chromosome.Binary.ToList());
        }

        [TestMethod]
        public void Integer()
        {
            IChromosome chromosome = new Chromosome(1, -35, 4, 5, "X");
            List<byte> expected = new List<byte> { 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, chromosome.Binary.ToList());
        }

        [TestMethod]
        public void AccuracyNull()
        {
            IChromosome chromosome = new Chromosome(0, -35, 4, 5, "X");
            List<byte> expected = new List<byte> { 1, 0, 0, 0, 1, 0, 1};

            CollectionAssert.AreEqual(expected, chromosome.Binary.ToList());
        }

        [TestMethod]
        public void IsCorrect()
        {
            IChromosome chromosome = new Chromosome(0, -35, 4, 4, "X");

            IChromosome chromosome1 = new Chromosome(0, -35, 4, 5, "X");

            Assert.AreEqual(true, chromosome.IsCorrect);
            Assert.AreEqual(false, chromosome1.IsCorrect);
        }

        [TestMethod]
        public void UpdateBinary()
        {
            IChromosome chromosome = new Chromosome(1, -35, 4, 4, "X");

            chromosome.Update(new List<byte> { 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0 });

            Assert.AreEqual(10.2, chromosome.Value);
        }

        [TestMethod]
        public void UpdateBinary_NumericValue()
        {
            IChromosome chromosome = new Chromosome(1, -35, 4, 4.7, "X");

            chromosome.Update(new List<byte> { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 });

            Assert.AreEqual(10, chromosome.Value);
        }

        [TestMethod]
        public void NumericChromosome_Binary()
        {
            IChromosome chromosome = new ChromosomeNumeric(1, 20, 10, "N");
            List<byte> expected = new List<byte> { 10 };
            CollectionAssert.AreEqual(expected, chromosome.Binary.ToList());
        }
    }
}
