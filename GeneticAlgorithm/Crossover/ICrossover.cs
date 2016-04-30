using GeneticAlgorithm.DesignPoints;
using GeneticAlgorithm.PairFormation;
using System.Collections.Generic;

namespace GeneticAlgorithm.Crossover
{
    public interface ICrossover
    {
        int PopulationNumber { get; set; }
        int PopulationId { get; set; }

        IEnumerable<IDesignPoint> Crossover(IPair pair);
        IEnumerable<IDesignPoint> Crossover(IEnumerable<IPair> pairs);
    }
}
