using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using Bestcode.MathParser;
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
        public static int Count { get; set; } = 0;
        public IFuncCalculator FuncCalculator { get; set; }
        #endregion

        #region Constructors

        static DesignPoint()
        {

        }

        public DesignPoint()
        {
            Count++;
        }

        public DesignPoint(int populationNumber, IFuncCalculator funcCalculator, params IChromosome[] x) : this()
        {
            if (x == null)
                throw new ArgumentNullException();

            if (populationNumber < 0)
                throw new ArgumentOutOfRangeException();

            this.PopulationNumber = populationNumber;
            this.ID = Count;
            this.X = new List<IChromosome>(x);
            this.FuncCalculator = funcCalculator;
            this.FunctionValue = funcCalculator.CalculateFunc(x);
            this.X1X2 = GetBinary(x);
        }

        #endregion

        #region Public methods

        public void Update(IEnumerable<byte> crossover)
        {
            this.X1X2 = crossover;
            var lengthPreviousX = 0;
            var newChromosomes = new List<IChromosome>();
            foreach (var item in X)
            {
                var newChromo = item.Clone();
                var lengthCurrentX = item.Binary.Count();
                var list = crossover.ToList();
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
                ID = Count
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
