using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Chromosome;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.FuncCalculator;

namespace GeneticAlgorithm.Population
{
    public class NetPopulation : IPopulation
    {
        public IEnumerable<IDesignPoint> GetPopulation(int N, IFuncCalculator funcExpression, params IChromosome[] chromosomes)
        {
            throw new NotImplementedException();
        }
    }
}
