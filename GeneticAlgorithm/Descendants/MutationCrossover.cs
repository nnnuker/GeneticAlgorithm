using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.Crossover;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Descendants
{
    public class MutationCrossover : IDescendants
    {
        public IEnumerable<IDesignPoint> GetDescendants(ICrossover crossover, double mutationCoeff)
        {
            throw new NotImplementedException();
        }
    }
}
