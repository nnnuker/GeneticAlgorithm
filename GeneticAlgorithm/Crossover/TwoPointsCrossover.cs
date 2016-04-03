using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;

namespace GeneticAlgorithm.Crossover
{
    public class TwoPointsCrossover : ICrossover
    {
        public IEnumerable<IDesignPoint> Crossover(IEnumerable<IPair> pairs)
        {
            return null;
        }

        public IEnumerable<IDesignPoint> Crossover(IPair pair)
        {
            return null;
        }
    }
}
