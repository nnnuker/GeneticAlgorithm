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
        public double FunctionValue
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string X1X2
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int ID
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int PopulationNumber
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public List<IChromosome> X
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }



        #endregion

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
            throw new NotImplementedException();
        }

        private string GetBinary(params IChromosome[] x)
        {
            throw new NotImplementedException();
        }
    }
}
