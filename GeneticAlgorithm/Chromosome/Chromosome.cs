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
        private IBinary binary;

        #region Properties
        public int Accuracy { get; set; }
        public IEnumerable<byte> Binary {
            get
            {
                binary = new Binary(Value, Accuracy, Left, Right);
                return binary.BinaryValue;
            }
        }

        public double Value { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public string Name { get; set; }
        public bool IsCorrect => Value >= Left && Value <= Right;
        #endregion

        #region Constructors
        public Chromosome()
        {

        }

        public Chromosome(int accuracy, double left, double right, double value, string name)
        {
            if (accuracy < 0 || left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Value = value;
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
                binary = this.binary
            };
        }

        public void Update(IEnumerable<byte> binary)
        {
            if (binary == null)
                this.binary = new Binary(Value, Accuracy, Left, Right);

            Value = this.binary.Update(binary);
        }

        #endregion
    }
}
