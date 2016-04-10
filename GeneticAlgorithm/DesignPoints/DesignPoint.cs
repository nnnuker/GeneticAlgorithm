using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using Bestcode.MathParser;

namespace GeneticAlgorithm.DesignPoints
{
    public class DesignPoint : IDesignPoint
    {
        #region Properties
        public double FunctionValue { get; set; }
        public string X1X2 { get; set; }
        public int ID { get; set; }
        public int PopulationNumber { get; set; }
        public List<IChromosome> X { get; set; }
        public bool IsAlive
        {
            get
            {
                foreach (var item in X)
                {
                    if (!item.IsCorrect)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static int Count { get; set; } = 0;
        public string FuncExpression { get; set; }

        #endregion

        static DesignPoint()
        {

        }

        public DesignPoint()
        {
            Count++;
        }

        public DesignPoint(int populationNumber, string funcExpression, params IChromosome[] x) : this()
        {
            if (x == null)
                throw new ArgumentNullException();

            if (populationNumber < 0)
                throw new ArgumentOutOfRangeException();

            this.PopulationNumber = populationNumber;
            this.ID = Count;
            this.X = new List<IChromosome>(x);
            this.FuncExpression = funcExpression;
            this.FunctionValue = CalculateFunc(x);
            this.X1X2 = GetBinary(x);

        }

        private double CalculateFunc(params IChromosome[] x)
        {
            try
            {
                MathParser parser = new MathParser();
                for (int i = 0; i < x.Length; i++)
                {
                    parser.SetVariable(x[i].Name, x[i].Value, null);
                }
                parser.Expression = FuncExpression;
                return parser.ValueAsDouble;
            }
            catch (ParserException e)
            {
                return 0;
            }
        }

        private string GetBinary(params IChromosome[] x)
        {
            string result = string.Empty;
            foreach (var item in x)
            {
                result += item.Binary;
            }
            return result;
        }

        public void Update(string crossover)
        {
            this.X1X2 = crossover;
            var lengthPreviousX = 0;
            var newChromosomes = new List<IChromosome>();
            foreach (var item in X)
            {
                var lengthCurrentX = item.Binary.Length;
                var binaryChromosome = crossover.Substring(lengthPreviousX, lengthCurrentX);
                newChromosomes.Add(new Chromosome.Chromosome(item.Accuracy, item.Left, item.Right, binaryChromosome, item.Name));
                lengthPreviousX += lengthCurrentX;
            }
            this.X = newChromosomes;
            this.FunctionValue = CalculateFunc(X.ToArray());
        }

        public IDesignPoint Copy()
        {
            return new DesignPoint
            {
                FunctionValue = this.FunctionValue,
                X = this.X,
                PopulationNumber = this.PopulationNumber,
                X1X2 = this.X1X2,
                ID = Count
            };
        }
    }
}
