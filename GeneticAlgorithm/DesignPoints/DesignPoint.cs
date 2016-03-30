using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;

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

        #endregion

        public DesignPoint()
        {

        }

        public DesignPoint(int populationNumber, int id, params IChromosome[] x)
        {
            if (x == null)
                throw new ArgumentNullException();

            if (populationNumber < 0 || id < 0)
                throw new ArgumentOutOfRangeException();

            this.PopulationNumber = populationNumber;
            this.ID = id;
            this.X = new List<IChromosome>(x);
            this.FunctionValue = CalculateFunc(x);
            this.X1X2 = GetBinary(x);
        }

        private double CalculateFunc(params IChromosome[] x)
        {
            //throw new NotImplementedException();
            return 0;
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
    }
}
