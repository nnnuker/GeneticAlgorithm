using System;
using System.Collections.Generic;
using System.Linq;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.FuncCalculator;

namespace GeneticAlgorithm.DesignPoints
{
    public class DesignPoint : IDesignPoint
    {
        #region Properties
        public double FunctionValue { get; set; }
        public IEnumerable<byte> X1X2 { get; set; }
        public int ID { get; set; }
        public int PopulationNumber { get; set; }
        public List<IChromosome> X { get; set; }
        public bool IsAlive
        {
            get
            {
                return X.All(item => item.IsCorrect);
            }
        }
        public bool IsMutate { get; set; }
        public IFuncCalculator FuncCalculator { get; set; }

        #endregion

        #region Constructors

        static DesignPoint()
        {

        }

        public DesignPoint()
        {
        }

        public DesignPoint(int populationNumber, int id, IFuncCalculator funcCalculator, params IChromosome[] x) : this()
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
            this.X1X2 = GetBinary(x);
            this.IsMutate = false;
        }

        #endregion

        #region Public methods

        public void Update(IEnumerable<byte> crossover)
        {
            this.X1X2 = crossover;
            var lengthPreviousX = 0;
            var newChromosomes = new List<IChromosome>();
            var list = crossover.ToList();
            foreach (var item in X)
            {
                var newChromo = item.Clone();
                var lengthCurrentX = item.Binary.Count();

                var binaryChromosome = list.GetRange(lengthPreviousX, lengthCurrentX);
                newChromo.Update(binaryChromosome);
                newChromosomes.Add(newChromo);
                lengthPreviousX += lengthCurrentX;
            }
            this.X = newChromosomes;
            this.FunctionValue = FuncCalculator.CalculateFunc(X.ToArray());
        }

        public IDesignPoint Clone()
        {
            return new DesignPoint
            {
                FunctionValue = this.FunctionValue,
                FuncCalculator = this.FuncCalculator,
                X = this.X,
                PopulationNumber = this.PopulationNumber,
                X1X2 = this.X1X2,
                ID = this.ID,
                IsMutate = this.IsMutate
            };
        }

        #endregion

        #region Private methods

        private IEnumerable<byte> GetBinary(params IChromosome[] x)
        {
            var list = new List<byte>();
            foreach (var chromosome in x)
                list.AddRange(chromosome.Binary);
            return list;
        }

        #endregion
    }
}
