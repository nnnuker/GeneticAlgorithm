using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;

namespace TestsGA
{
    [TestClass]
    public class ChromosomeTest
    {
        [TestMethod]
        public void BinaryFormat()
        {
            Chromosome chromosome = new Chromosome(0.1, -4, 4, 5.5, "X");
            Assert.AreEqual("101010101", chromosome.Binary);
        }

        [TestMethod]
        public void BinaryFormatMinus()
        {
            Chromosome chromosome = new Chromosome(0.1, -4, 4, -5.5, "X");
            Assert.AreEqual("001010101", chromosome.Binary);
        }

        [TestMethod]
        public void BigNumber()
        {
            Chromosome chromosome = new Chromosome(0.1, -35, 4, -5.5, "X");
            Assert.AreEqual("00001010101", chromosome.Binary);
        }

        [TestMethod]
        public void Integer()
        {
            Chromosome chromosome = new Chromosome(0.1, -35, 4, 5, "X");
            Assert.AreEqual("10001010000", chromosome.Binary);
        }

        [TestMethod]
        public void ConvertToDouble()
        {
            Chromosome chromosome = new Chromosome(0.1, -12315, 534846, 42424, "X");
            Chromosome chromosome1 = new Chromosome(0.1, -35, 4, -5.5, "X");
            Chromosome chromosome2 = new Chromosome(0.1, -4, 4, 5.5, "X");
            Assert.AreEqual(42424, chromosome.GetValue());
            Assert.AreEqual(-5.5, chromosome1.GetValue());
            Assert.AreEqual(5.5, chromosome2.GetValue());
        }
    }
}
