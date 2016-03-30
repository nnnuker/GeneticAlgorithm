using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Chromosome
{
    public class Chromosome : IChromosome
    {
        #region Properties
        public double Accuracy { get; set; }
        public string Binary { get; }
        public double Value { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors
        public Chromosome(double accuracy, double left, double right, string name)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Binary = GetBinary();
        }

        public Chromosome(double accuracy, double left, double right, double value, string name)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Value = value;
            this.Binary = GetBinary();
        }
        #endregion

        private string GetBinary()
        {
            throw new NotImplementedException();
            
        }
    }
}
