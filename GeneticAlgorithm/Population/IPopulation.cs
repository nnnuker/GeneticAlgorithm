using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.Population
{
    public interface IPopulation
    {
        IEnumerable<IDesignPoint> GetPopulation();
    }
}
