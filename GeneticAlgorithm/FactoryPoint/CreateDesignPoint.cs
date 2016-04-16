using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.FactoryPoint
{
    public class CreateDesignPoint
    {
        private readonly IFuncCalculator funcCalculator;

        public CreateDesignPoint()
        {
            
        }

        public CreateDesignPoint(IFuncCalculator funcCalculator)
        {
            if (funcCalculator == null) throw new ArgumentNullException(nameof(funcCalculator));
            this.funcCalculator = funcCalculator;
        }

        public IDesignPoint CreateFactoryPoint(int populationNumber, IChromosome[] chromo)
        {
            if (chromo == null) throw new ArgumentNullException(nameof(chromo));
            return new DesignPoint(populationNumber, funcCalculator, chromo);
        }
    }
}
