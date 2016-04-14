using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FactoryPoint;
using GeneticAlgorithm.FuncCalculator;

namespace GeneticAlgorithm.Population
{
    public class NetPopulation : IPopulation
    {
        public IEnumerable<IDesignPoint> GetPopulation(IFactoryPoints factoryPoint, int N, int populationNumber, params IChromosome[] chromosomes)
        {
            throw new NotImplementedException();
        }
    }
}
