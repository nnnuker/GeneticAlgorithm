using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Mutation
{
    public interface IMutation
    {
        IEnumerable<IDesignPoint> Mutate(IEnumerable<IDesignPoint> designPoints);
    }
}