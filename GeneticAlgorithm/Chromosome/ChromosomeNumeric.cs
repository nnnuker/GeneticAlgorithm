using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm.Chromosome
{
    public class ChromosomeNumeric : IChromosome
    {       
        public bool IsCorrect => Value >= Left && Value <= Right;

        public int Accuracy { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public IEnumerable<byte> Binary
        {
            get
            {
                var binary = new List<byte>();
                binary.Add((byte)Value);
                return binary;
            }
        }

        public ChromosomeNumeric()
        {

        }

        public ChromosomeNumeric(double left, double right, double value, string name)
        {
            if (left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = 0;
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }

        public IChromosome Clone()
        {
            return new ChromosomeNumeric
            {
                Accuracy = this.Accuracy,
                Left = this.Left,
                Right = this.Right,
                Name = this.Name,
                Value = this.Value
            };
        }

        public void Update(IEnumerable<byte> binary)
        {
            Value = binary.ElementAt(0);
        }

        public bool Equals(IChromosome other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            return this.Accuracy == other.Accuracy
                && this.Value.Equals(other.Value)
                && this.Left.Equals(other.Left)
                && this.Right.Equals(other.Right)
                && this.Name == other.Name
                && this.Binary.SequenceEqual(other.Binary);
        }
    }
}
