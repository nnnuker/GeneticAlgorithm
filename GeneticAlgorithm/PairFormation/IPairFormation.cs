using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.PairFormation
{
    public interface IPairFormation
    {
        IEnumerable<IPair> FormatPairs(IEnumerable<IDesignPoint> designPoints);
    }
}
