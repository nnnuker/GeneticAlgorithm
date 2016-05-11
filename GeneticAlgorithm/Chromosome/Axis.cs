using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorithm.Chromosome
{
    public class Axis : IChromosome
    {
        public int Accuracy { get; set; }
        public bool IsCorrect => Value >= Left && Value <= Right;
        public double Left { get; set; }
        public double Right { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public IEnumerable<byte> Binary
        {
            get
            {
                List<byte> binary = new List<byte>();
                binary.Add((byte)Value);
                return binary;
            }
        }

        public Axis()
        {

        }

        public Axis(int accuracy, double left, double right, double value, string name)
        {
            if (left > right)
                throw new ArgumentOutOfRangeException();

            this.Name = name;
            this.Accuracy = accuracy;
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }


        public IChromosome Clone()
        {
            return new Axis
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
            if (other == null) return false;

            return this.Accuracy == other.Accuracy
                && this.Value.Equals(other.Value)
                && this.Left.Equals(other.Left)
                && this.Right.Equals(other.Right)
                && this.Name == other.Name
                && this.Binary.SequenceEqual(other.Binary);
        }
    }
}
