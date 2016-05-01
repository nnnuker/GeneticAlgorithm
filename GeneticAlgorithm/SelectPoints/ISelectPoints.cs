using System.Collections.Generic;
using GeneticAlgorithm.DesignPoints;

namespace GeneticAlgorithm.SelectPoints
{
    public interface ISelectPoints
    {
        IEnumerable<IDesignPoint> SelectPoints(int n, IEnumerable<IDesignPoint> designPoints);
    }
}
