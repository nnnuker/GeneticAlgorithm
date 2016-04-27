using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Mutation
{
    public interface IMutation
    {
        int PopulationNumber { get; set; }
        List<IDesignPoint> AllDesignPoints  { get; set; }
        List<IDesignPoint> MutateDesignPoints  { get; set; }
        
        void Mutate(IEnumerable<IDesignPoint> designPoints);
    }
}