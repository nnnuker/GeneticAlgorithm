using System;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Chromosome;

namespace GeneticAlgorithm.FactoryPoint
{
    public class CreatePoint : IFactoryPoints
    {
        private readonly IFuncCalculator funcCalculator;

        public CreatePoint()
        {
            
        }

        public CreatePoint(IFuncCalculator funcCalculator)
        {
            if (funcCalculator == null) throw new ArgumentNullException(nameof(funcCalculator));

            this.funcCalculator = funcCalculator;
        }

        public IDesignPoint CreateFactoryPoint(int populationNumber, int id, IChromosome[] chromo)
        {
            if (chromo == null) throw new ArgumentNullException(nameof(chromo));
            return new Point(populationNumber, id, funcCalculator, chromo);
        }
    }
}
