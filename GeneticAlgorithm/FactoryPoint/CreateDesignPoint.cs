using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using System;

namespace GeneticAlgorithm.FactoryPoint
{
    public class CreateDesignPoint : IFactoryPoints
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

        public IDesignPoint CreateFactoryPoint(int populationNumber, int id, IChromosome[] chromo)
        {
            if (chromo == null) throw new ArgumentNullException(nameof(chromo));
            return new DesignPoint(populationNumber, id, funcCalculator, chromo);
        }
    }
}
