using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Population
{
    public class RandomPopulation : IPopulation
    {
        public IEnumerable<IDesignPoint> GetPopulation(int N, double accuracy, params IChromosome[] chromosomes)
        {
            throw new NotImplementedException();
        }
    }
}
