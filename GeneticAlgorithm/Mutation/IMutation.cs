using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Mutation
{
    public interface IMutation
    {
        int PopulationNumber { get; set; }

        IEnumerable<IDesignPoint> Mutate(IEnumerable<IDesignPoint> designPoints);
    }
}