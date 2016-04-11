using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Chromosome
{
    public class Chromosome : IChromosome
    {
        #region Properties
        public int Accuracy { get; set; }
        public IBinary Binary { get; private set; }

        public double Value
        {
            get { return Binary.Value; }
            set { }
        }

        public double Left { get; set; }
        public double Right { get; set; }
        public string Name { get; set; }
        public bool IsCorrect => Value >= Left && Value <= Right;
        #endregion

        #region Constructors
        public Chromosome()
        {

        }

        public Chromosome(int accuracy, double left, double right, string name, IBinary binary)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Binary = binary.GetBinary();
        }

        public Chromosome(int accuracy, double left, double right, double value, string name, IBinary binary)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Value = value;
            this.Binary = binary.GetBinary();
        }
        #endregion

        #region Public methods

        public IChromosome Clone()
        {
            return new Chromosome
            {
                Accuracy = this.Accuracy,
                Left = this.Left,
                Right = this.Right,
                Name = this.Name,
                Value = this.Value,
                Binary = this.Binary
            };
        }

        #endregion


        
    }
}
