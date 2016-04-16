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
        private readonly Random random;
        private readonly IFactoryPoints factoryPoint;
        private readonly int N;
        private readonly int populationNumber;
        private readonly IChromosome[] chromosomes;

        public NetPopulation()
        {
            random = new Random(DateTime.Today.Millisecond);
        }

        public NetPopulation(IFactoryPoints factoryPoint, int N, int populationNumber = 1, params IChromosome[] chromosomes):this()
        {
            this.factoryPoint = factoryPoint;
            this.N = N;
            this.populationNumber = populationNumber;
            this.chromosomes = chromosomes;
        }

        public IEnumerable<IDesignPoint> GetPopulation()
        {
            throw new NotImplementedException();
        }
    }
}
