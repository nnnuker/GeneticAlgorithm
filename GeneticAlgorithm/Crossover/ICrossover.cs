using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;
using System.Collections.Generic;

namespace GeneticAlgorithm.Crossover
{
    public interface ICrossover
    {
        IEnumerable<IDesignPoint> Crossover(IPair pair);
        IEnumerable<IDesignPoint> Crossover(IEnumerable<IPair> pairs);
    }
}
