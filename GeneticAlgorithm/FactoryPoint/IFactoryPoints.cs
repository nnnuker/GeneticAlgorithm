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
    public interface IFactoryPoints
    {
        IDesignPoint CreateFactoryPoint(int populationNumber, IFuncCalculator funcCalculator, IChromosome[] chromo);
    }
}
