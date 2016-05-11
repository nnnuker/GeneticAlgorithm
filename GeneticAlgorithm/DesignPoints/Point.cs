using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.FuncCalculator;

namespace GeneticAlgorithm.DesignPoints
{ 
    public class Point : IDesignPoint
    {
        public IEnumerable<IDesignPoint> AllPoints { get; set; }

        public bool IsAlive
        {
            get
            {
                return X.All(item => item.IsCorrect);
            }
        }

        public bool IsMutate { get; set; }
        public IEnumerable<byte> X1X2 { get; set; }

        public IFuncCalculator FuncCalculator { get; set; }

        public double FunctionValue { get; set; }
        public int ID { get; set; }
        public int PopulationNumber { get; set; }
        public List<IChromosome> X { get; set; }



        public Point()
        {

        }

        public Point(int populationNumber, int id, IFuncCalculator funcCalculator, params IChromosome[] x) : this()
        {
            if (x == null)
                throw new ArgumentNullException();

            if (populationNumber < 0)
                throw new ArgumentOutOfRangeException();

            this.PopulationNumber = populationNumber;
            this.ID = id;
            this.X = new List<IChromosome>(x);
            this.FuncCalculator = funcCalculator;
            this.FunctionValue = funcCalculator.CalculateFunc(x);
            
        }

        public IDesignPoint Clone()
        {
            return new Point
            {
                FunctionValue = this.FunctionValue,
                FuncCalculator = this.FuncCalculator,
                X = this.X,
                PopulationNumber = this.PopulationNumber,
                X1X2 = this.X1X2,
                ID = this.ID
            };
        }

        public void Update(IEnumerable<byte> s)
        {
            
        }

        public bool Equals(IDesignPoint other)
        {
            if (other == null) return false;

            return this.FunctionValue.Equals(other.FunctionValue)
                   && this.ID == other.ID
                   && this.PopulationNumber == other.PopulationNumber
                   && this.IsMutate == other.IsMutate
                   && this.FuncCalculator.Equals(other.FuncCalculator)
                   && this.X.SequenceEqual(other.X);
        }
    }
}
