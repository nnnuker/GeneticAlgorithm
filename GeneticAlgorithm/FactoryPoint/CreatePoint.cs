using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.FuncCalculator.TruncationAlgorithm;

namespace GeneticAlgorithm.FactoryPoint
{
    class CreatePoint : IFactoryPoints
    {
        public IDesignPoint CreateFactoryPoint(int populationNumber, IFuncCalculator funcCalculator, IChromosome[] chromo)
        {
            return new Point(populationNumber, funcCalculator, chromo);
        }
    }
}
